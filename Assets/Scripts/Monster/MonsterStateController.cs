using System;
using Unity.VisualScripting;
using UnityEngine;

partial class MonsterStateController : MonsterController
{
    
    private float timeSinceLastAttack = float.MaxValue;
    private float timeSinceLastChange = float.MaxValue;
    private float healthChangeDelay = 0.01f;
    public bool isHit = false;
    public float MaxHealth => stat.maxHealth;
    public float CurrentHealth { get; private set; }
    public MonsterStateController Target;
    public event Action onDeath;
    public event Action<float> onDamage;
    public event Action onAttack;
    
    protected override void Awake()
    {
        base.Awake();
        stat = GetComponent<CharacterStat>();
        CurrentHealth = MaxHealth;
        timeSinceLastChange = 0f;
        onDamage += ChangeHealth;
    }
    protected override void FixedUpdate()
    {
        timeSinceLastChange += Time.deltaTime;
    }
    protected  void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CallDamage();
            animator.SetTrigger("Hit");
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

    private void ChangeHealth(float change)
    {
        if(timeSinceLastChange < healthChangeDelay)
        {
            return;
        }
        timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth,0,MaxHealth);

        if(CurrentHealth <= 0f)
        {
            Debug.Log("?щ쭩");
            
        }
        Debug.Log(CurrentHealth);
        isHit = true;
    }
}