using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DestroyOnDeath : MonoBehaviour
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
        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }
        
        foreach(Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            if(!(behaviour is Animator))
            behaviour.enabled = false;
        }
        // 2초뒤에 파괴
        Destroy(gameObject, 2f);
    }
}