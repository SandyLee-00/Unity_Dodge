using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayPopup : MonoBehaviour
{
    Button OptionButton;
    TextMeshProUGUI ScoreText;
    TextMeshProUGUI LeftTimeText;

    private void Awake()
    {
        OptionButton = transform.Find("HUD/OptionButton").GetComponent<Button>();
        ScoreText = transform.Find("HUD/ScoreText").GetComponent<TextMeshProUGUI>();
        LeftTimeText = transform.Find("HUD/LeftTimeText").GetComponent<TextMeshProUGUI>();

        OptionButton.onClick.AddListener(OnClickOptionButton);
    }


    void Start()
    {
        
    }

    void Update()
    {
        
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

        GameObject gameObject = Instantiate(prefab);
    }
}
