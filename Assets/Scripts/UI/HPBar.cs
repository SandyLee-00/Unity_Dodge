using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] CharacterStat characterStat;

    public bool IsInvincible = false;

    float maxHP;
    float nowHP;

    private void Awake()
    {
        maxHP = characterStat.maxHealth;
        nowHP = maxHP;
    }
    public bool DecreaseHP(float amount)
    {
        if (nowHP <= 0)
        {
            nowHP = 0;
            return false;
        }

        if (IsInvincible)
        {
            return true;
        }

        nowHP -= amount;
        fillBar.fillAmount = (nowHP - amount) / maxHP;

        return true;
    }

    public bool IncreaseHP(float amount)
    {
        if (nowHP >= maxHP)
        {
            nowHP = maxHP;
            return true;
        }

        nowHP += amount;
        fillBar.fillAmount = (nowHP + amount) / maxHP;
        return true;
    }

}
