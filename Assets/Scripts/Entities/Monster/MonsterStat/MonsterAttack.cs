using System;

class MonsterAttack : MonsterStateController
{
    public new void Start()
    {
        onAttack += OnAttack;
    }
    private void OnAttack()
    {
        Attack();
    }
    private void Attack()
    {
        //animatorWeapon.SetTrigger("Attack");
    }
}