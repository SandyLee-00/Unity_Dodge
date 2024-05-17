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

        SoundOff = Resources.Load<Sprite>("Sprites/GameIcon_16");
        SoundOn = Resources.Load<Sprite>("Sprites/GameIcon_5");

        SoundButton.onClick.AddListener(() =>
        {
            Debug.Log("SoundButton Clicked");

            // TODO : 사운드 Manager 만들기
            /*if (Managers.Sound.IsOn)
            {
                Managers.Sound.IsOn = false;
                SoundButton.GetComponent<Image>().sprite = SoundOff;
            }
            else
            {
                Managers.Sound.IsOn = true;
                SoundButton.GetComponent<Image>().sprite = SoundOn;
            }*/
            
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
        /*if (Managers.Sound.IsOn)
            SoundButton.GetComponent<Image>().sprite = SoundOn;
        else
            SoundButton.GetComponent<Image>().sprite = SoundOff;*/

    }

    void Update()
    {

    }
}
