using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CharacterAnimationController : MonoBehaviour
{
    PlayerInputController playerController;
    Animator animator;

    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    private static readonly int Attack = Animator.StringToHash("Attack");

    private readonly float magnituteThreshold = 0.5f;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        // 공격하거나 움직일 때 애니메이션이 같이 반응하도록 구독
        playerController.OnAttackEvent += Attacking;
        playerController.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > magnituteThreshold);
    }

    private void Attacking()
    {
        animator.SetTrigger(Attack);
    }

    // 아직 피격부분은 없지만 곧 할 것이기 때문에 일단 둡니다.
    private void Hit()
    {
        animator.SetBool(IsHit, true);
    }

    // 아직 피격부분은 없지만 곧 할 것이기 때문에 일단 둡니다.
    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);
    }
}
