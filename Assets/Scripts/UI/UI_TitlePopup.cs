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

        // �÷��� ������ �̵��ϱ�
        StartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Play");
        });

        // ���� �����ϱ�
        ExitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        // �ɼ� �˾� ����
        OptionButton.onClick.AddListener(() =>
        {
            // TODO : Managers�� UI �Ŵ��� �߰��ϱ� 
            // Managers.UI.ShowPopup<UI_OptionPopup>();
        });
    }

}
