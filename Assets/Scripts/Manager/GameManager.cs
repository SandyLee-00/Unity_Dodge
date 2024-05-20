using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인게임 로직 처리하기
/// Game에서 필요한 데이터 관리하기
/// 조작은 필요한 부분에서 가져다 쓰기 
/// </summary>
public class GameManager :MonoBehaviour
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
