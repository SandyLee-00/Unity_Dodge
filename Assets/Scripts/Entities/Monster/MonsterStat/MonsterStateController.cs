using System;
using Unity.VisualScripting;
using UnityEngine;

partial class MonsterStateController : MonsterController
{
    
    private float timeSinceLastAttack = float.MaxValue;

    public event Action onDeath;
    public event Action onDamage;
    public event Action onAttack;
    public float CurrentHealth { get;  set; }
    public float MaxHealth => stat.maxHealth;
    public bool isCollidingwithTarget = false;

    protected override void Awake()
    {
        base.Awake();
        stat = GetComponent<CharacterStat>();
        CurrentHealth = MaxHealth;
        timeSinceLastAttack = 0f;
    }

    protected void Update()
    {
        if (isCollidingwithTarget)
        {
            animator.SetTrigger("Hit");
            CallDamage();
            isCollidingwithTarget = false;
        }
        if (CurrentHealth == 0)
        {
            animator.SetBool("Dead", true);
            CallDeath();
        }
        if(timeSinceLastAttack >3f&& DistanceToTarget().magnitude<=5.0f)
        {
            CallAttack();
            timeSinceLastAttack = 0f;
        }
    }
    protected override void FixedUpdate()
    { 
        base.FixedUpdate();
        timeSinceLastAttack += Time.deltaTime;
    }

    private void CallDeath()
    {
        onDeath?.Invoke();
    }
    private void CallDamage()
    {
        onDamage?.Invoke();
    }
    private void CallAttack()
    {
        onAttack?.Invoke();
    }
}