using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Diagnostics;
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

        // �÷��� ������ �̵��ϱ�
        StartButton.onClick.AddListener(() =>
        {
            Debug.Log("StartButton Clicked");
            SceneManager.LoadScene("Play");
        });

        // ���� �����ϱ�
        ExitButton.onClick.AddListener(() =>
        {
            Debug.Log("ExitButton Clicked");
            Application.Quit();
        });

        // TODO : Managers�� UI �Ŵ��� �߰��ϱ� 
        // Managers.UI.ShowPopup<UI_OptionPopup>();

        // �ɼ� �˾� ����
        OptionButton.onClick.AddListener(OnClickOptionButton);
    }   

    private void Start()
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
