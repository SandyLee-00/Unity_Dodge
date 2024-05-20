using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ?깃??댁쑝濡?寃뚯엫 ?댁뿉???ъ슜?섎뒗 紐⑤뱺 留ㅻ땲??ㅼ쓣 愿由?
/// </summary>
public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { Init(); return s_instance; } }

    private static UIManager s_uiManager = new UIManager();
    private static SoundManager s_soundManager = new SoundManager();
    private static GameManager s_gameManager = new GameManager();

    public static UIManager UI { get { Init(); return s_uiManager; } }
    public static SoundManager Sound { get { Init(); return s_soundManager; } }
    public static GameManager Game { get { Init(); return s_gameManager; } }


    void Start()
    {

    }

    void Update()
    {

    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject managers = GameObject.Find("@Managers");
            if (managers == null)
            {
                managers = new GameObject { name = "@Managers" };
            }

            s_instance = managers.GetOrAddComponent<Managers>();
            DontDestroyOnLoad(managers);

            s_soundManager.Init();

            Application.targetFrameRate = 60;
        }
    }
}
