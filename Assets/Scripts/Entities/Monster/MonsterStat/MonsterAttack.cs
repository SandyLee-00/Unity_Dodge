using UnityEngine;

class MonsterAttack : MonsterStateController
{
    public Transform pos;
    public Vector2 boxSize;
    public new void Start()
    {
        onAttack += OnAttack;
    }
    private void OnAttack()
    {
        if(!isRange)
        CloseAttack();
    }
    private void CloseAttack()
    {
        Collider2D[] coliders2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D colider in coliders2Ds)
        {
            if(colider.tag == "player")
            {
                target.SendMessage("CallHittedEvent");
                
                Debug.Log(colider+"공격");
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}