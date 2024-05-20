using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// ?멸쾶??濡쒖쭅 泥섎━?섍린
/// Game?먯꽌 ?꾩슂???곗씠??愿由ы븯湲?
/// 議곗옉? ?꾩슂??遺遺꾩뿉??媛?몃떎 ?곌린 
/// </summary>
public class GameManager :MonoBehaviour
{
    public int Score { get; set; } = 0;
    public float LeftSecond { get; set; } = 0.0f;

    GameObject player;

    const float MAXGAMEPLAYTIME = 60.0f;

    public void Init()
    {
        player = Resources.Load<GameObject>("Prefabs/Player/Player");
        Instantiate(player);
        Score = 0;
        LeftSecond = MAXGAMEPLAYTIME;
    }
}
