using UnityEngine;
using static ObjectPool;
using UnityEngine.UIElements;

class MonsterAttack : MonsterStateController
{
    public Transform meleePos;
    public Vector2 boxSize;
    ObjectPool pool;
    [SerializeField] private Transform projectileSpawnPosition;

    public new void Start()
    {
        onAttack += OnAttack;
        pool = FindObjectOfType<ObjectPool>();
    }
    private void OnAttack(AttackSO attackSO)
    {
        if (!isRange) CloseAttack(attackSO);
        else MOnShoot(attackSO);
        Invoke("Move", 2f);
    }
    private void CloseAttack(AttackSO attackSO)
    {
        Collider2D[] coliders2Ds = Physics2D.OverlapBoxAll(meleePos.position, boxSize, 0);
        foreach (Collider2D colider in coliders2Ds)
        {
            if(colider.tag == "player")
            {
                target.SendMessage("CallHittedEvent");
                
                Debug.Log(colider+"공격");
            }

        }
    }
    public void MOnShoot(AttackSO attackSO)
    {
        RangedAttackSO RangedAttackSO = attackSO as RangedAttackSO;
        float projectilesAngleSpace = RangedAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = RangedAttackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * RangedAttackSO.multipleProjectilesAngle;


        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-RangedAttackSO.spread, RangedAttackSO.spread);
            angle += randomSpread;
            MCreateProjectile(RangedAttackSO, angle);
        }
    }

    public void MCreateProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
        GameObject obj = pool.SpawnFromPool(rangedAttackSO.bulletNameTag);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(DistanceToTarget(), angle), rangedAttackSO);
    }
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(meleePos.position, boxSize);
    }
    private void Move()
    {
        IsAttacking = true;
    }
}