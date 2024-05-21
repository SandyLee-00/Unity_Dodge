using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public float LeftSecond { get; set; } = 0.0f;
    public bool IsWin { get; set; } = false;
    public bool IsGameEnd { get; set; } = false;

    GameObject player;

    PlayerInputController playerController;

    const float MAXGAMEPLAYTIME = 60f;

    // action으로 게임 끝나면 실행할 함수를 등록
    public event Action<bool> OnGameEnd;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        player = Resources.Load<GameObject>("Prefabs/Player/Player");
        Instantiate(player);

        Time.timeScale = 1.0f;

        Score = 0;
        LeftSecond = MAXGAMEPLAYTIME;
        IsWin = false;
        IsGameEnd = false;
    }

    private void Update()
    {
        UpdateLeftSecond();
    }

    private void UpdateLeftSecond()
    {
        if (LeftSecond > 0)
        {
            LeftSecond -= Time.deltaTime;

            playerController = player.GetComponent<PlayerInputController>();

            // TODO : 플레이어 체력 < 0 이면 게임 종료
            if (!playerController.isAlive && !IsGameEnd)
            {
                IsWin = false;
                IsGameEnd = true;
                OnGameEnd?.Invoke(IsWin);
            }
        }
        else if (LeftSecond <= 0 && !IsGameEnd)
        {
            LeftSecond = 0;
            IsWin = true;
            IsGameEnd = true;
            OnGameEnd?.Invoke(IsWin);
        }
    }
}
