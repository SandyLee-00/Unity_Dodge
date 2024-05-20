using System;
using Unity.VisualScripting;
using UnityEngine;

partial class MonsterStateController : MonsterController
{
    
    private float timeSinceLastAttack = float.MaxValue;

    public event Action onDeath;
    public event Action<float> onDamage;
    public event Action onAttack;
    public float CurrentHealth { get;  set; }
    public float MaxHealth => stat.maxHealth;

    protected override void Awake()
    {
        base.Awake();
        stat = GetComponent<CharacterStat>();
        CurrentHealth = MaxHealth;
    }

    protected  void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Hit");
            CallDamage();
        }
        if (CurrentHealth == 0)
        {
            animator.SetBool("Dead", true);
            CallDeath();
        }
    }

    private void CallDeath()
    {
        onDeath?.Invoke();
    }
    private void CallDamage()
    {
        onDamage?.Invoke(-stat.attackSO.power);
    }
}