using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인게임 로직 처리하기
/// Model
/// </summary>
public class GameManager
{
    public int Score { get; set; } = 0;
    public float LeftSecond { get; set; } = 0.0f;

    const float MAXGAMEPLAYTIME = 60.0f;

    public void Init()
    {
        Score = 0;
        LeftSecond = MAXGAMEPLAYTIME;
    }
}
