using System.Collections;
using UnityEngine;
using static Define;

public class PlayerSkill : MonoBehaviour
{
    PlayerInputController playerController;

    UI_SkillPopUp skillPopUp;

    public bool[] skillAvailablity = { false, false };

    public float[] coolDowns = { 5f, 10f };

    float[] skillDurations = { 2f, 3f };

    float oriSpeed;

    [SerializeField] HPBar HPBar;

    CharacterStatHandler characterStat;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
        characterStat = GetComponent<CharacterStatHandler>();
        skillPopUp = FindAnyObjectByType<UI_SkillPopUp>();  
    }

    private void Start()
    {
        oriSpeed = characterStat.CurrentStat.speed;
    }

    private void Update()
    {
        if (playerController.tapFirstSkill)
        {
            UseSkill(Define.SkillType.SpeedUp);
            playerController.tapFirstSkill = false;
        }

        if (playerController.tapSecondSkill)
        {
            UseSkill(Define.SkillType.Invincibility);
            playerController.tapSecondSkill = false;
        }

        ResetInput();
        //Debug.Log(skillAvailablity[0]);
    }

    public void UseSkill(Define.SkillType skillType)
    {
        if (skillAvailablity[(int)skillType])
        {
            ApplySkillCooldown(skillType);

            StartCoroutine(ApplySkillDuration(skillType, skillDurations[(int)skillType]));
        }
    }
    void ApplySkillCooldown(Define.SkillType skillType)
    {
        skillPopUp.skillFillAmounts[(int)skillType] = 0f;
    }

    void ResetInput()
    {
        playerController.tapFirstSkill = false;
        playerController.tapSecondSkill = false;
    }

    IEnumerator ApplySkillDuration(Define.SkillType type, float delayTime)
    {
        switch(type)
        {
            case SkillType.SpeedUp:
                characterStat.CurrentStat.speed = 10f;
                break;
            case SkillType.Invincibility:
                HPBar.IsInvincible = true;
                break;
        }
     
        yield return new WaitForSeconds(delayTime);

        switch (type)
        {
            case SkillType.SpeedUp:
                characterStat.CurrentStat.speed = oriSpeed;
                break;
            case SkillType.Invincibility:
                HPBar.IsInvincible = false;
                break;
        }
    }
}
