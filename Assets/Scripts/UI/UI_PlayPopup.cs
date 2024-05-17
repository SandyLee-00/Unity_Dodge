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
        OptionButton = transform.Find("OptionButton").GetComponent<Button>();
        ScoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        LeftTimeText = transform.Find("LeftTimeText").GetComponent<TextMeshProUGUI>();

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
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/UI_OptionPopup");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : UI/UI_OptionPopup");
            return;
        }

        GameObject gameObject = Instantiate(prefab);
    }
}
