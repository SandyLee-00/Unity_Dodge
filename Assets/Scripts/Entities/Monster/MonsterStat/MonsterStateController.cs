using System;
using Unity.VisualScripting;
using UnityEngine;

partial class MonsterStateController : MonsterController
{
    
    private float timeSinceLastAttack = float.MaxValue;

    public event Action onDeath;
    public event Action onDamage;
    public event Action<AttackSO> onAttack;
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
            animatorCharacter.SetTrigger("Hit");
            CallDamage();
            isCollidingwithTarget = false;
        }
        if (CurrentHealth == 0)
        {
            animatorCharacter.SetBool("Dead", true);
            CallDeath();
        }
        if(timeSinceLastAttack > stat.attackSO.delay&& DistanceToTarget().magnitude<=5.0f)
        {
            IsAttacking = true;
            CallAttack(stat.attackSO);
            animatorWeapon.SetTrigger("Attack");
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
    private void CallAttack(AttackSO attackSO)
    {
        onAttack?.Invoke(stat.attackSO);
    }
}