using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private Camera camera;
    private float timeSinceLastAttack = float.MaxValue;
    private bool isAttacking;

    protected CharacterStatHandler stats { get; private set; }

    private void Awake()
    {
        camera = Camera.main;
        stats = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (isAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);
    }

    private void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }
    private void OnFire(InputValue value)
    {
        isAttacking = value.isPressed;
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
