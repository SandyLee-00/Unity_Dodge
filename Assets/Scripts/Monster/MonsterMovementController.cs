using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

class MonsterMovementController : MonsterController
{
    private MonsterStateController state;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    protected override void Start()
    {
        base.Start();
        OnMoveEvent += ApplyMove;
    }
    protected override void FixedUpdate()
    {
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    private void Update()
    {
        
        CallMoveEvent(DistanceToTarget());
        CallLookEvent(DistanceToTarget());
        if (Input.GetMouseButtonDown(0))
        {
            ApplyKnockback(transform, stat.attackSO.knockbackPower, stat.attackSO.knockbackTime);
        }
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
