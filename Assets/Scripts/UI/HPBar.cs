using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;

    int maxHP;
    int nowHP;
    
    public void DecreaseHP(float amount)
    {
        fillBar.fillAmount = (nowHP - amount) / maxHP;
    }
}
