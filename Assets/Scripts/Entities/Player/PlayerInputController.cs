using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private Camera _camera;
    private float timeSinceLastAttack = float.MaxValue;
    private bool isAttacking;

    public bool isAlive;
    public bool tapFirstSkill;
    public bool tapSecondSkill;

    protected CharacterStatHandler stats { get; private set; }
    PlayerSkill playerSkill;

    private void Awake()
    {
        _camera = Camera.main;
        stats = GetComponent<CharacterStatHandler>();
        playerSkill = GetComponent<PlayerSkill>();
    }

    private void Update()
    {
        if (isAlive)
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
        if (isAlive)
        {
            Vector2 newAim = value.Get<Vector2>();
            Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

            newAim = (worldPos - (Vector2)transform.position).normalized;


            CallLookEvent(newAim);
        }
    }
    private void OnFire(InputValue value)
    {
        isAttacking = value.isPressed;
    }

    private void OnFirstSkill(InputValue value)
    {
        tapFirstSkill = value.isPressed;
    }

    private void OnSecondSkill(InputValue value)
    {
        tapSecondSkill = value.isPressed;
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
