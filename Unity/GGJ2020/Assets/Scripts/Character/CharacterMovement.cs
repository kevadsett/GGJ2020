using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMovement : MonoBehaviour
{
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
    public bool isDashing;

    [SerializeField]
    private float timer;
    public AnimationCurve animationCurve;
    [Space]
    private Vector2 i_movement;

    PlayerControls controls;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 999;
        //controls.Gameplay.Movement.canceled += context => OnMovementCancelled();


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

        timer += Time.deltaTime;
        if (timer >= 0.2f) isDashing = false;
        runSpeed = BaseRunSpeed + animationCurve.Evaluate(timer) * MaxDashOffset;
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
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) && this.GetComponent<PlayerId>().Id == 1 ))
        {
            timer = 0;
            isDashing = true;
            AudioPlayer.PlaySound ("SFX_Dash", this.transform.position);

        } else if(Input.GetKeyDown(KeyCode.Space) && this.GetComponent<PlayerId>().Id == 0)
        {
            timer = 0;
            isDashing = true;
            AudioPlayer.PlaySound ("SFX_Dash", this.transform.position);
        }
       
    }
    public void OnMovement(InputValue value)
    {

        i_movement = value.Get<Vector2>();
    }

    public void OnDash(InputValue val)
    {
        timer = 0;
        isDashing = true;
    }
    public void Movement()
    {
        horizontal = i_movement.x;
        vertical = i_movement.y;
    }


}
