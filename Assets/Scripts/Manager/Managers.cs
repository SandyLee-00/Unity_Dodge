using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Managers has UI, Sound, Game
/// </summary>
public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { Init(); return s_instance; } }

    private static UIManager s_uiManager;
    private static SoundManager s_soundManager;
    private static GameManager s_gameManager;

    public static UIManager UI { get { Init(); return s_uiManager; } }
    public static SoundManager Sound { get { Init(); return s_soundManager; } }
    public static GameManager Game { get { Init(); return s_gameManager; } }


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        Init();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드될 때마다 호출되는 로직
        CreateGameManager();
    }
    private void CreateGameManager()
    {
        if (s_gameManager == null)
        {
            GameObject gameManager = new GameObject("GameManager", typeof(GameManager));
            gameManager.transform.parent = transform;
            s_gameManager = gameManager.GetComponent<GameManager>();
        }
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
            
            //GameObject gameManager = new GameObject("GameManager");
            //gameManager.transform.SetParent(managers.transform);
            //gameManager.AddComponent<GameManager>();
            //s_gameManager = gameManager.GetComponent<GameManager>();


            s_soundManager = new SoundManager();
            s_soundManager.Init();

            s_uiManager = new UIManager();
            s_uiManager.Init();

            Application.targetFrameRate = 60;

        }
    }
}
