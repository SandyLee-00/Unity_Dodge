using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

class MonsterBehaviorController : MonsterController
{
    private MonsterStateController state;
    [SerializeField] private SpriteRenderer characterRender;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    protected override void Start()
    {
        OnMoveEvent += ApplyMove;
        OnLookEvent += ApplyLook;
    }
    protected override void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ApplyKnockback(transform, stat.attackSO.knockbackPower, stat.attackSO.knockbackTime);
        }
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
        CallMoveEvent(DistanceToTarget());
        CallLookEvent(DistanceToTarget());
    }
    private void ApplyLook(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        characterRender.flipX = (rotZ) < 0f;
    }

    private void ApplyMove(Vector2 direction)
    {
        direction = direction.normalized * stat.speed;
        if (knockbackDuration > 0.0f)
        {
            direction += knockback;
        }
        movementRigidbody.velocity = direction;
        
    }
    private void ApplyKnockback(Transform Other,float power,float duration)
    {
        knockbackDuration = duration;
        knockback = -(mousePos - transform.position).normalized * power;
        
    }
}
