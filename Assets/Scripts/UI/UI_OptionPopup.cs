using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OptionPopup : MonoBehaviour
{
    Button SoundButton;
    Button CloseButton;

    Sprite SoundOn;
    Sprite SoundOff;

    void Awake()
    {
        SoundButton = transform.Find("SoundButton").GetComponent<Button>();
        CloseButton = transform.Find("CloseButton").GetComponent<Button>();

        SoundButton.onClick.AddListener(() =>
        {
            Debug.Log("SoundButton Clicked");

            Managers.Sound.IsOn = !Managers.Sound.IsOn;

            if (Managers.Sound.IsOn)
            {
                SoundButton.GetComponent<Image>().sprite = SoundOn;
            }
            else
            {
                SoundButton.GetComponent<Image>().sprite = SoundOff;
            }
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

    void Start()
    {
        // TODO : 사운드 상태에 따라 이미지 변경
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/GameIcon");

        // 스프라이트 배열에서 원하는 스프라이트 찾기
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "GameIcon_16")
            {
                SoundOff = sprite;
            }
            else if (sprite.name == "GameIcon_5")
            {
                SoundOn = sprite;
            }
        }

        // 사운드 상태에 따라 버튼 이미지 변경
        if (Managers.Sound.IsOn)
        {
            SoundButton.GetComponent<Image>().sprite = SoundOn;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundOff;
        }
    }

    void Update()
    {

    }
}
