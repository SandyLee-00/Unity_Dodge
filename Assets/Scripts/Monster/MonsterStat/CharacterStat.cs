using System;
using UnityEngine;

<<<<<<<< HEAD:Assets/Scripts/Controller/CharacterStat.cs
public enum StatsChangeType
{
    Add, // 0
    Multiple, // 1
    Override, // 2
}

[Serializable]
public class CharacterStat :MonoBehaviour
========
public enum StatsChangeType 
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStat : MonoBehaviour
>>>>>>>> main:Assets/Scripts/Monster/MonsterStat/CharacterStat.cs
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}