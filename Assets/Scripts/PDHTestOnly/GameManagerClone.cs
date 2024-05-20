using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerClone : MonoBehaviour
{
    public static GameManagerClone instance;

    public ObjectPool objectPool;

    void Awake()
    {
        instance = this;
        objectPool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
