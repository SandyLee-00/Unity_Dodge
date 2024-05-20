using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterDamaged : MonoBehaviour
{
    private MonsterStateController state;
    protected Rigidbody2D rigidbody;
    private float healthChangeDelay = 0.01f;
    private float timeSinceLastChange = float.MaxValue;
    private void Start()
    {
        state = GetComponent<MonsterStateController>();
        rigidbody = GetComponent<Rigidbody2D>();
        state.onDamage += Damaged;
        state.onDamage += ChangeHealth;
        timeSinceLastChange = 0f;
    }
    private void FixedUpdate()
    {
        timeSinceLastChange += Time.deltaTime;

    }

    void Damaged(float damage)
    {
        float AlphaChange = (damage / state.stat.maxHealth) / 1.5f;
        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {

            Color color = renderer.color;
            color.a += AlphaChange;
            renderer.color = color;
        }
    }
    void ChangeHealth(float change)
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            return;
        }
        timeSinceLastChange = 0f;
        state.CurrentHealth += change;
        state.CurrentHealth = Mathf.Clamp(state.CurrentHealth, 0, state.MaxHealth);

        if (state.CurrentHealth <= 0f)
        {
            Debug.Log("사망");

        }
        Debug.Log(state.CurrentHealth);
    }
}