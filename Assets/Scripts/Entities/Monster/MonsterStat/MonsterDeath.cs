using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterDeath: MonoBehaviour
{
    private MonsterStateController state;
    protected new Rigidbody2D rigidbody;
    private UI_PlayPopup pppup;
    [SerializeField] int monsterScore;
    GameManager gameManager;
    private void Start()
    {
        state = GetComponent<MonsterStateController>();
        rigidbody = GetComponent<Rigidbody2D>();
        state.onDeath += OnDeath;
        pppup = GetComponent<UI_PlayPopup>();
        gameManager = GetComponent<GameManager>();
    }

    void OnDeath()
    {
        Managers.Game.Score += 100;
        rigidbody.velocity = Vector3.zero;
        foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            if(!(behaviour is Animator))
            behaviour.enabled = false;
        } 
        Destroy(gameObject,2f);
    }
}