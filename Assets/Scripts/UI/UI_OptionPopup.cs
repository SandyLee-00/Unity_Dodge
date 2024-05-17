using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OptionPopup : MonoBehaviour
{
    Button SoundButton;
    Button CloseButton;

    void Awake()
    {
        
    }

    void Start()
    {
        SoundButton = transform.Find("SoundButton").GetComponent<Button>();
        CloseButton = transform.Find("CloseButton").GetComponent<Button>();

        if (SoundButton == null || CloseButton == null)
        {
            Debug.Log("Failed to load Button");
            return;
        }

        SoundButton.onClick.AddListener(() =>
        {
            Debug.Log("SoundButton Clicked");
            // TODO : 사운드 뮤트
        });

        CloseButton.onClick.AddListener(() =>
        {
            Debug.Log("CloseButton Clicked");
            Destroy(gameObject);

            // TODO : Managers에 UI 매니저 추가하기
            // Managers.UI.ClosePopupUI(this);

            // 게임 시간 다시 시작
            Time.timeScale = 1;
        });
    }

    void Update()
    {
        
    }
}
