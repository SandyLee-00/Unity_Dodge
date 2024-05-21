using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void Init()
    {
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

            if (playerController == null) return;
            
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerInputController>();
    }
}
