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
            // TODO : ���� ��Ʈ
        });

        CloseButton.onClick.AddListener(() =>
        {
            Debug.Log("CloseButton Clicked");
            Destroy(gameObject);

            // TODO : Managers�� UI �Ŵ��� �߰��ϱ�
            // Managers.UI.ClosePopupUI(this);
        });
    }

    void Update()
    {
        
    }
}
