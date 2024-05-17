using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

class MonsterBehaviorController : MonsterController
{
    private MonsterController controller;
    private Rigidbody2D movementRigidbody;
    [SerializeField] private SpriteRenderer characterRender;

    [SerializeField] float speed;
    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<MonsterController>();

    }
    protected override void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnLookEvent += Look;
    }

    private void Look(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        characterRender.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void Move(Vector2 direction)
    {
        movementRigidbody.velocity = direction.normalized * speed;
    }
}