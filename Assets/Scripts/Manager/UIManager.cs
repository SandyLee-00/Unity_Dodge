using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI 처리하기
/// </summary>
public class UIManager
{
    private GameObject _uiRoot = null;

    public void Init()
    {
        /*if (_soundRoot == null)
        {
            _soundRoot = GameObject.Find("@SoundRoot");
            if (_soundRoot == null)
            {
                _soundRoot = new GameObject { name = "@SoundRoot" };
                UnityEngine.Object.DontDestroyOnLoad(_soundRoot);

                string[] soundTypeNames = System.Enum.GetNames(typeof(Define.Sound));
                for (int count = 0; count < soundTypeNames.Length - 1; count++)
                {
                    GameObject go = new GameObject { name = soundTypeNames[count] };
                    _audioSources[count] = go.AddComponent<AudioSource>();
                    go.transform.parent = _soundRoot.transform;
                }

                _audioSources[(int)Define.Sound.Bgm].loop = true;
            }
        }*/

        if (_uiRoot == null)
        {
            _uiRoot = GameObject.Find("@UIRoot");
            if (_uiRoot == null)
            {
                _uiRoot = new GameObject { name = "@UIRoot" };
                _uiRoot.transform.SetParent(GameObject.Find("@Managers").transform);
            }
        }
    }
}
