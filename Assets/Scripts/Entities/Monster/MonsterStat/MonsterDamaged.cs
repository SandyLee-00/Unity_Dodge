using System;
using System.Collections;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MonsterDamaged : MonoBehaviour
{
    private MonsterStateController state;
    protected new Rigidbody2D rigidbody;
    public TextMeshProUGUI DamageTxt;
    [SerializeField] [Range(0.1f, 0.3f)] float healthChangeDelay = 0.01f;
    private float timeSinceLastChange = float.MaxValue;
    private float attackDamage = 0f;
    private void Start()
    {
        state = GetComponent<MonsterStateController>();
        rigidbody = GetComponent<Rigidbody2D>();
        state.onDamage += Damaged;
        state.onDamage += ChangeHealth;
        state.onDamage += UpdateText;
        timeSinceLastChange = 0f;
    }

    private void FixedUpdate()
    {
        timeSinceLastChange += Time.deltaTime;
    }

    void Damaged()
    {
        float AlphaChange = (attackDamage / state.stat.maxHealth) / 4f;
        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {

            Color color = renderer.color;
            color.a -= AlphaChange;
            renderer.color = color;
        }
    }
    void ChangeHealth()
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            return;
        }
        timeSinceLastChange = 0f;
        state.CurrentHealth -= attackDamage;
        state.CurrentHealth = Mathf.Clamp(state.CurrentHealth, 0, state.MaxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            attackDamage = state.target.GetComponent<CharacterStatHandler>().CurrentStat.attackSO.power;
            state.isCollidingwithTarget = true;
        }
    }

    private void UpdateText()
    {
        DamageTxt.text = "<sprite=11>-"+ attackDamage.ToString();
        StartCoroutine(ClearTextAfterDelay(healthChangeDelay));
    }

    IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DamageTxt.text = "";
    }
}