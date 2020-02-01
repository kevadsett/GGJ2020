using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    PlayerControls controls;
    // Start is called before the first frame update
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float BaseRunSpeed = 5.0f;
    public float MaxDashOffset = 5.0f;
    private float runSpeed = 5.0f;
    private Vector2 MovementVector;

    private float dashTime;

    [SerializeField]
    private float timer;
    public AnimationCurve animationCurve;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 999;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        HandleMovement();

        timer += Time.deltaTime;
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
    }
    public void HandleMovement() {
        horizontal = vertical = 0;
       if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
    }
    public void HandleDash() {
        if (Input.GetKeyDown(KeyCode.Space)){
            timer = 0;
        }
    }
    
}
