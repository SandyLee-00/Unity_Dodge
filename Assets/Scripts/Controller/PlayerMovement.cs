using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputController playerController;
    Rigidbody2D movementRigidbody;

    [SerializeField] float movementSpeed = 5f;

    Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerController.OnMoveEvent += Move;
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
        direction = direction * movementSpeed;
        movementRigidbody.velocity = direction;
    }
}