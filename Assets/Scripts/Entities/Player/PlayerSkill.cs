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
        // ?熬곣뱿?????꾪뀬???????띠럾??繞③뇡???⑤객臾????
        if (skillAvailablity[(int)skillType])
        {
            // ???꾪뀬 ??????뚮뿭寃?

            ApplySkillColldown(skillType);

            //Debug.Log("?????);
        }
    }
    void ApplySkillColldown(Define.SkillType skillType)
    {
        skillPopUp.skillFillAmounts[(int)skillType] = 0f;
    }
}
