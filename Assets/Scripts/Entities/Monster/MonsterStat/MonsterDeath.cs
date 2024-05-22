using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterDeath: MonoBehaviour
{
    private MonsterStateController state;
    protected new Rigidbody2D rigidbody;
    [SerializeField] int monsterScore;
    public string deathSound;
    private void Start()
    {
        state = GetComponent<MonsterStateController>();
        rigidbody = GetComponent<Rigidbody2D>();
        state.onDeath += OnDeath;
    }

    void OnDeath()
    {
        Managers.Game.Score += monsterScore;
        Managers.Sound.Play(Define.Sound.Effect,$"{deathSound}");
        rigidbody.velocity = Vector3.zero;
        foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            if(!(behaviour is Animator))
            behaviour.enabled = false;
        } 
        Destroy(gameObject,2f);
    }
}