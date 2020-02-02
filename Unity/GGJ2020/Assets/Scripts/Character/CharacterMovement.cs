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
    

    // Start is called before the first frame update
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float BaseRunSpeed = 5.0f;
    public float MaxDashOffset = 5.0f;
    private float runSpeed = 5.0f;
    private Vector2 MovementVector;

    public CharacterAnimator charAnimator;

    private float dashTime;
    

    [SerializeField]
    private float DashTimer;
    public AnimationCurve animationCurve;
    [Space]
    private Vector2 i_movement;
    public eState State { get; private set; }
    private float StunTimer;
    public float StunDuration = 1f;
    PlayerControls controls;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DashTimer = 999;

    }

    void Awake()
    {
        controls = new PlayerControls();
        //controls.Gameplay.Movement.performed += 
    }
    void Update()
    {
        // Gives a value between -1 and 1
        //HandleMovement(); //Keyboard-mode if you wanna work with this comment-out below also add a Player to the scene and disable Player Input Manager.
         Movement();

        switch (State)
        {
        case eState.Moving:
            runSpeed = BaseRunSpeed;
            break;
        case eState.Dashing:
            DashTimer += Time.deltaTime;
            if (DashTimer > 0.2f)
            {
                State = eState.Moving;
            }
            runSpeed = BaseRunSpeed + animationCurve.Evaluate(DashTimer) * MaxDashOffset;
            break;
        case eState.Stunned:
            runSpeed = 0;
            StunTimer += Time.deltaTime;
            if (StunTimer > StunDuration)
            {
                State = eState.Moving;
                ScreenRenderer.material = NormalMaterial;
            }
            break;
        }
        
        HandleDash();
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        MovementVector = new Vector2(horizontal, vertical);
        
        rb.velocity = MovementVector * runSpeed;

        // update visuals
        charAnimator.movementVec = MovementVector;
    }

    public void SetStunned()
    {
        if (State == eState.Stunned)
        {
            return;
        }
        State = eState.Stunned;
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
        
       //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
       // {
       //     vertical = 1;
       // }
       // if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
       // {
       //     vertical = -1;
       // }
       // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
       // {
       //     horizontal = -1;
       // }
       // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
       // {
       //     horizontal = 1;
       // }
    }
    public void HandleDash() {
        if (State == eState.Stunned)
        {
            return;
        }
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) && this.GetComponent<PlayerId>().Id == 1 ))
        {
            DashTimer = 0;
            State = eState.Dashing;
            AudioPlayer.PlaySound ("SFX_Dash", this.transform.position);
        } else if(Input.GetKeyDown(KeyCode.Space) && this.GetComponent<PlayerId>().Id == 0)
        {
            DashTimer = 0;
            State = eState.Dashing;
            AudioPlayer.PlaySound ("SFX_Dash", this.transform.position);
        }
       
    }
    public void OnMovement(InputValue value)
    {

        i_movement = value.Get<Vector2>();
    }

    public void OnDash(InputValue val)
    {
        if (State == eState.Stunned)
        {
            return;
        }
        DashTimer = 0;
        State = eState.Dashing;
    }
    public void Movement()
    {
        if (State == eState.Stunned)
        {
            horizontal = vertical = 0;
        }
        else
        {
            horizontal = i_movement.x;
            vertical = i_movement.y;
        }
    }


}
