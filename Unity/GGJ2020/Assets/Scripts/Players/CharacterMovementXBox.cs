using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementXBox : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;
    private Vector2 MovementVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
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
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
       // MovementVector = new Vector2 (horizontal, vertical);

        rb.velocity = MovementVector * runSpeed;
    }
    public void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Change the runSpeed for a lot    
        }
    }
}
