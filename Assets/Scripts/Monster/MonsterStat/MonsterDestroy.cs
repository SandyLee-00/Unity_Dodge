using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterDestroy: MonoBehaviour
{
    private MonsterStateController state;
    protected Rigidbody2D rigidbody;

    private void Start()
    {
        state = GetComponent<MonsterStateController>();
        rigidbody = GetComponent<Rigidbody2D>();
        state.onDeath += OnDeath;
    }

    void OnDeath()
    {
        rigidbody.velocity = Vector3.zero;
        
        foreach(Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            if(!(behaviour is Animator))
            behaviour.enabled = false;
        } 
        Destroy(gameObject,2f);
    }
}