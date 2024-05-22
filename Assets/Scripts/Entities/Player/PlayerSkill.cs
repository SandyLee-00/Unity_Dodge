using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    PlayerInputController playerController;

    [SerializeField] UI_SkillPopUp skillPopUp;

    public bool[] skillAvailablity = { false, false };

    public float[] coolDowns = { 5f, 10f };

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
    }
    private void Update()
    {
        if (playerController.tapFirstSkill)
        {
            UseSkill(Define.SkillType.SpeedUp);
        }

        if (playerController.tapSecondSkill)
        {
            UseSkill(Define.SkillType.Invincibility);
        }
    }

    public void UseSkill(Define.SkillType skillType)
    {
        // 누른 스킬이 사용 가능한 상태일 때
        if (skillAvailablity[(int)skillType])
        {
            // 스킬 사용 구현

            ApplySkillColldown(skillType);

            Debug.Log("클릭");
        }
    }
    void ApplySkillColldown(Define.SkillType skillType)
    {
        skillPopUp.skillFillAmounts[(int)skillType] = 0f;
    }
}
