using System;

class MonsterAttack : MonsterStateController
{
    public void Start()
    {
        onAttack += OnAttack;
    }
    private void OnAttack()
    {
        Attack();
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}