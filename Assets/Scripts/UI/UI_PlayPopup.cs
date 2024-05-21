using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 남은시간, 점수, 옵션 버튼을 관리하는 UI
/// GameManger의 LeftTime 여기서 더해주고 표시한다 
/// </summary>
public class UI_PlayPopup : MonoBehaviour
{
    Button OptionButton;
    public TextMeshProUGUI ScoreText;
    TextMeshProUGUI LeftTimeText;

    float leftSecond;

    // TODO: SceneManager에서 씬 
    // Restart 눌러서 게임 재시작
    public void Refresh()
    {
        Managers.Game.Init();
    }

    private void Awake()
    {
        OptionButton = transform.Find("HUD/OptionButton").GetComponent<Button>();
        ScoreText = transform.Find("HUD/ScoreText").GetComponent<TextMeshProUGUI>();
        LeftTimeText = transform.Find("HUD/LeftTimeText").GetComponent<TextMeshProUGUI>();

        OptionButton.onClick.AddListener(OnClickOptionButton);

        Managers.Game.OnGameEnd += ShowResultPopup;
    }

    void Start()    
    {
        Refresh();
    }

    void Update()
    {
        GetScoreText();
        GetLeftTimeText();
    }

    private void GetLeftTimeText()
    {
        leftSecond = Managers.Game.LeftSecond;
        TimeSpan timeSpan = TimeSpan.FromSeconds(leftSecond);
        LeftTimeText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }

    private void GetScoreText()
    {
        ScoreText.text = $"{Managers.Game.Score:N0}점";  
    }

    private void OnClickOptionButton()
    {
        // 게임 시간 멈추기
        Time.timeScale = 0;

        // 옵션 팝업 생성
        Debug.Log("OnClickOptionButton");

        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/UI_OptionPopup");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : UI/UI_OptionPopup");
            return;
        }

        GameObject UI_OptionPopup = Instantiate(prefab);
    }

    // 게임 종료시 결과 팝업 생성
    private void ShowResultPopup(bool isWin)
    {
        // BGM 정지
        Managers.Sound.Stop(Define.Sound.Bgm);
        // 게임 시간 멈추기
        Time.timeScale = 0;

        // 옵션 팝업 생성
        Debug.Log("ResultPopup");

        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/UI_ResultPopup");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : UI/UI_ResultPopup");
            return;
        }

        GameObject UI_ResultPopup = Instantiate(prefab);
    }

}
