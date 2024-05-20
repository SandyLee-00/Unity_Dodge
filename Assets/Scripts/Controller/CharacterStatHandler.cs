using UnityEngine;
using System.Collections.Generic;

public class CharacterStatHandler : MonoBehaviour
{
    // 湲곕낯 ?ㅽ꺈怨?踰꾪봽 ?ㅽ꺈?ㅼ쓽 ?λ젰移섎? 醫낇빀?댁꽌 ?ㅽ꺈??怨꾩궛?섎뒗 而댄룷?뚰듃
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        // statModifier瑜?諛섏쁺?섍린 ?꾪빐 baseStat??癒쇱? 諛쏆븘??
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        // TODO : 吏湲덉? 湲곕낯 ?λ젰移섎쭔 ?곸슜?섍퀬 ?덉?留? ?ν썑 ?λ젰移?媛뺥솕 湲곕뒫?깆씠 異붽???寃껋엫!
        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.maxHealth = baseStats.maxHealth;
        CurrentStat.speed = baseStats.speed;

    }
}
