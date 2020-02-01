﻿using System.Collections;
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

    public float runSpeed = 5.0f;
    private Vector2 MovementVector;

    private float dashTime;

    [SerializeField]
    private float timer=0;
    public AnimationCurve animationCurve;

    private void Awake()
    {
        //controls = new PlayerControls();

        //controls.Gameplay.movement.performed += ctx => Grow();
    }
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
       //
       


    }
    public void HandleDash() {
        if (Input.GetKeyDown(KeyCode.Space)){
            //Change the runSpeed for a lot 
            
           // runSpeed = runSpeed + animationCurve.Evaluate(timer) ;
            Debug.Log("runSpeed= " + animationCurve.Evaluate(timer));
            
        }
    }
    
}
