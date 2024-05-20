using System;
using UnityEngine;

//public enum StatsChangeType
//{
//    Add, // 0
//    Multiple, // 1
//    Override, // 2
//}

// ?대옒?ㅺ? Serializable??硫ㅻ쾭濡쒕쭔 援ъ꽦?섏뼱 ?덉쑝硫?[Serializable]??遺숈뿬 ?먮뵒?곗뿉???뺤씤 媛?ν빐??
[Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}