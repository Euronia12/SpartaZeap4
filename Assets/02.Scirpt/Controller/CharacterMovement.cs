using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody2D movementRigidbody;
    
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }
    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction) 
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction;
    }
}