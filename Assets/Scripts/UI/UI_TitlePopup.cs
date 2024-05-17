using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_TitlePopup : MonoBehaviour
{
    Button StartButton;
    Button ExitButton;
    Button OptionButton;

    private void Awake()
    {
        StartButton = transform.Find("StartButton").GetComponent<Button>();
        ExitButton = transform.Find("ExitButton").GetComponent<Button>();
        OptionButton = transform.Find("OptionButton").GetComponent<Button>();

        // 플레이 씬으로 이동하기
        StartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Play");
        });

        // 게임 종료하기
        ExitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        // 옵션 팝업 띄우기
        OptionButton.onClick.AddListener(() =>
        {
            // TODO : Managers에 UI 매니저 추가하기 
            // Managers.UI.ShowPopup<UI_OptionPopup>();
        });
    }

}
