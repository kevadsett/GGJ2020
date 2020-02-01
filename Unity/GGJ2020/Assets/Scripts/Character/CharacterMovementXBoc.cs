using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementXbBoc : MonoBehaviour
{
    PlayerControls controls;
    // Start is called before the first frame update
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;
    private Vector2 MovementVector;

    private float dashTime;

    [SerializeField]
    private float timer=0;
    public AnimationCurve animationCurve;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.movement.performed += ctx => MovementVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.movement.canceled += ctx => MovementVector = Vector2.zero;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
       

        timer += Time.deltaTime;
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
        
        rb.velocity = MovementVector * runSpeed;
        

        

    }
   
    public void HandleDash() {
        if (Input.GetKeyDown(KeyCode.Space)){
            //Change the runSpeed for a lot 
            
           // runSpeed = runSpeed + animationCurve.Evaluate(timer) ;
            Debug.Log("runSpeed= " + animationCurve.Evaluate(timer));
            
        }
    }
    public void Grow()
    {
        //transform.localScale *= 1.1f;
        Debug.Log("controls:" + controls.Gameplay.movement.ReadValueAsObject().ToString());
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
