using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ResultPopup : MonoBehaviour
{
    Sprite survived;
    Sprite dead;
    Image SurvivedImage;

    Button TitleButton;

    TextMeshProUGUI ScoreText;
    

    void Awake()
    {
        SurvivedImage = transform.Find("SurvivedImage").GetComponent<Image>();

        TitleButton = transform.Find("TitleButton").GetComponent<Button>();

        TitleButton.onClick.AddListener(() =>
        {
            Debug.Log("TitleButton Clicked");
            SceneManager.LoadScene("Intro");
            Destroy(gameObject);
        });


    }

    void Start()
    {
        // 스프라이트 배열에서 원하는 스프라이트 찾기
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/UI");

        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == "Title 1")
            {
                survived = sprite;
            }
            else if (sprite.name == "Title 2")
            {
                dead = sprite;
            }
        }

        // 게임 결과에 따라 이미지 변경
        if (Managers.Game.IsWin)
        {
            SurvivedImage.GetComponent<Image>().sprite = survived;
            Managers.Sound.Play(Define.Sound.Effect, "Win");
        }
        else
        {
            SurvivedImage.GetComponent<Image>().sprite = dead;
            Managers.Sound.Play(Define.Sound.Effect, "Lose");
        }

        ScoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        ScoreText.text = $"{Managers.Game.Score:N0}점";
    }
}
