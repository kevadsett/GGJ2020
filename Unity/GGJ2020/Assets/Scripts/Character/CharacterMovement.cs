using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMovement : MonoBehaviour
{
    public enum eState
    {
        Moving,
        Dashing,
        Stunned
    }
    public MeshRenderer ScreenRenderer;
    public Material NormalMaterial;
    public Material StunnedMaterial;

    public TrailRenderer trail;
    public float trailTime;
    public float CarryingSlowdownMultiplier = 0.5f;
    public float CarryingSlowdownMultiplierDash = 0.2f;

    public float DashDuration = 0.2f;
    public float DashCooldownDuration = 0.5f;

    // Start is called before the first frame update
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    public float BaseRunSpeed = 5.0f;
    public float MaxDashOffset = 5.0f;
    private float runSpeed = 5.0f;
    public Vector2 MovementVector;

    public CharacterAnimator charAnimator;
    public FaceSelecta faceSelecta;

    private bool isDashReady;
    private float waitDashTimer;
    

    [SerializeField]
    private float DashTimer;
    public AnimationCurve animationCurve;
    [Space]
    private Vector2 i_movement;
    public eState State { get; private set; }
    private float StunTimer;
    public float StunDuration = 1f;
    private float dashWait = 0.5f;
    PlayerControls controls;
    private junkInteraction junkInteraction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DashTimer = 999;
        isDashReady = true;
        

        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;

        junkInteraction = GetComponent<junkInteraction>();

    }

    void Awake()
    {
        controls = new PlayerControls();
        //controls.Gameplay.Movement.performed += 
    }
    void Update()
    {
        DashTimer += Time.deltaTime;

        switch (State)
        {
        case eState.Moving:
            // Gives a value between -1 and 1
            HandleMovement(); //Keyboard-mode if you wanna work with this comment-out below also add a Player to the scene and disable Player Input Manager.
            Movement();

            if (trail.enabled== true)
            {
                if(trailTime > 0.3f)
                {
                    trail.enabled = false;
                    trailTime = 0;
                }
                trailTime += Time.deltaTime;
            }

            runSpeed = BaseRunSpeed * (junkInteraction.isCarrying ? CarryingSlowdownMultiplier : 1);
            break;
        case eState.Dashing:

            trail.enabled = true;
            
            trailTime += Time.deltaTime;

            if (DashTimer > DashDuration)
            {
                State = faceSelecta.state = eState.Moving;   
            }
            runSpeed = BaseRunSpeed + animationCurve.Evaluate(DashTimer) * (junkInteraction.isCarrying ? CarryingSlowdownMultiplierDash : 1) * MaxDashOffset;
            break;
        case eState.Stunned:
            runSpeed = 0;
            StunTimer += Time.deltaTime;
            if (StunTimer > StunDuration)
            {
                State = faceSelecta.state = eState.Moving;
                ScreenRenderer.material = NormalMaterial;
            }
            break;
        }
        
        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = Mathf.Clamp(vertical, -1f, 1f);
        
        HandleDash();

        waitDashTimer += Time.deltaTime;
        if (waitDashTimer > dashWait) isDashReady = true;
    }

    void FixedUpdate()
    {
        MovementVector = new Vector2(horizontal, vertical);
        
        rb.velocity = Vector3.ClampMagnitude(MovementVector * runSpeed, runSpeed);

        // update visuals
        charAnimator.movementVec = MovementVector * runSpeed;
    }

    public void SetStunned()
    {
        if (State == eState.Stunned)
        {
            return;
        }
        State = faceSelecta.state = eState.Stunned;
        StunTimer = 0;
        ScreenRenderer.material = StunnedMaterial;
    }

    public void HandleMovement() {

        horizontal = vertical = 0;

        if(this.GetComponent<PlayerId>().Id == 0)
        {
            if (Input.GetKey(KeyCode.W)) vertical = 1;
            if (Input.GetKey(KeyCode.S)) vertical = -1;
            if (Input.GetKey(KeyCode.A)) horizontal = -1;
            if (Input.GetKey(KeyCode.D)) horizontal = 1;
        } else if(this.GetComponent<PlayerId>().Id == 1){
            if (Input.GetKey(KeyCode.UpArrow)) vertical = 1;
            if (Input.GetKey(KeyCode.DownArrow)) vertical = -1;
            if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1;
            if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1;

        }
    }
    public void HandleDash() {
        if (State == eState.Stunned || !isDashReady)
        {
            return;
        }
        if (Mathf.Abs (horizontal) + Mathf.Abs (vertical) < 0.95f) // not touching joystick enough, you do not deserve to dash you lazy boy
        {
            return;
        }
        if (((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.M) )&& this.GetComponent<PlayerId>().Id == 1 ))
        {
            waitDashTimer = 0; isDashReady = false;
            DashTimer = 0;
            trailTime = 0;
            State = faceSelecta.state = eState.Dashing;
            AudioPlayer.PlaySound ("SFX_Dash", this.transform.position);
        } else if(Input.GetKeyDown(KeyCode.Space) && this.GetComponent<PlayerId>().Id == 0)
        {
            waitDashTimer = 0; isDashReady = false;
            DashTimer = 0;
            State = faceSelecta.state = eState.Dashing;
            AudioPlayer.PlaySound ("SFX_Dash", this.transform.position);
        }
       
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            i_movement = context.ReadValue<Vector2>();
        }

        if (context.canceled)
        {
            i_movement = Vector2.zero;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (State == eState.Stunned)
        {
            return;
        }

        if (DashTimer < DashDuration + DashCooldownDuration)
        {
            return;
        }

        if (Mathf.Abs (horizontal) + Mathf.Abs (vertical) < 0.95f) // not touching joystick enough, you do not deserve to dash you lazy boy
        {
            return;
        }

        if (context.performed)
        {
            DashTimer = 0;
            trailTime = 0;
            State = faceSelecta.state = eState.Dashing;
        }
    }
    public void Movement()
    {
        horizontal += i_movement.x;
        vertical += i_movement.y;
    }


}
