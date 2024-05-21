using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// UI 처리하기
/// </summary>
public class UIManager
{
    private GameObject _uiRoot = null;

    public void Init()
    {
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

    public T ShowPopupUI<T>(string name) where T : MonoBehaviour
    {
        // Resources/Prefabs/UI/Popup/Name 불러오기
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/Popup/{name}");
        if (prefab == null)
        {
            prefab = Resources.Load<GameObject>($"Prefabs/UI/{name}");
        }
        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab : UI/{name}");
            return default(T);
        }

        GameObject go = GameObject.Instantiate(prefab, _uiRoot.transform);
        T popup = go.GetOrAddComponent<T>();

        return popup;
    }
}
