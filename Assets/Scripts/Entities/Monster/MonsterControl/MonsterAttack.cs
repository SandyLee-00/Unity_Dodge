using System;

class MonsterAttack : MonsterController
{
    public void Start()
    {
        OnAttackEvent += onAttack;
    }
    private void onAttack()
    {
        InvokeRepeating("Attack", 0f,3f);
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}