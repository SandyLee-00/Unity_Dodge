using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

class MonsterMovement : MonsterController
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
        base .FixedUpdate();
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    protected void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            ApplyKnockback(target.transform, stat.attackSO.knockbackPower, stat.attackSO.knockbackTime);//stat of projectile
        }
    }
    
  

    private void ApplyMove(Vector2 direction)
    {
        direction =direction.normalized * stat.speed;
        if (knockbackDuration > 0.0f)
        {
            direction += knockback;
        }
        movementRigidbody.velocity = direction;
    }
    private void ApplyKnockback(Transform Other,float power,float duration)
    {
        knockbackDuration = duration;
        knockback = -(Other.position - transform.position).normalized * power;
        
    }
}
