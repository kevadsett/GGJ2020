using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        HandleMovement();

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
    public void HandleMovement() {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
       MovementVector.Set(horizontal, vertical);
       


    }
    public void HandleDash() {
        if (Input.GetKeyDown(KeyCode.Space)){
            //Change the runSpeed for a lot 
            
           // runSpeed = runSpeed + animationCurve.Evaluate(timer) ;
            Debug.Log("runSpeed= " + animationCurve.Evaluate(timer));
            
        }
    }
}
