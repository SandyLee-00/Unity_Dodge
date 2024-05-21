using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimationController : MonoBehaviour
{
    PlayerInputController playerController;
    PlayerDamaged playerDamageController;
    Animator animator;

    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsHit = Animator.StringToHash("IsHit");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    private readonly float magnituteThreshold = 0.5f;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
        playerDamageController = GetComponent<PlayerDamaged>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        playerController.OnAttackEvent += Attacking;
        playerController.OnMoveEvent += Move;
        playerDamageController.OnHittedEvent += Hit;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > magnituteThreshold);
    }

    private void Attacking(AttackSO attakSO)
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetTrigger(IsHit);
    }

    public void Dead()
    {
        animator.SetBool(IsDead, true);
    }
}
