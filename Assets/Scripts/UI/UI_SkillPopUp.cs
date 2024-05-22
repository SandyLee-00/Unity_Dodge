using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillPopUp : MonoBehaviour
{
    [SerializeField] Image[] skills;

    PlayerSkill playerSkill;

    public float[] skillFillAmounts = { 0f, 0f };

    private void Awake()
    {
        foreach(var skill in skills)
        {
            skill.fillAmount = 0;
        }
        playerSkill = FindAnyObjectByType<PlayerSkill>();
    }

    private void Update()
    {
        ViewSkillCoolDown();
    }

    void ViewSkillCoolDown()
    {
        for(int i = 0; i < skills.Length; i++)
        {
            if (skillFillAmounts[i] < 1f)
            {
                skillFillAmounts[i] += Time.deltaTime / playerSkill.coolDowns[i];
                skills[i].fillAmount = skillFillAmounts[i];
            }
            else if(skillFillAmounts[i] >= 1f)
            {
                skills[i].fillAmount = 1f;
                playerSkill.skillAvailablity[i] = true;
            }
            else
            {
                skills[i].fillAmount = skillFillAmounts[i];
                skillFillAmounts[i] += Time.deltaTime / playerSkill.coolDowns[i];
            }
        }
    }
}
