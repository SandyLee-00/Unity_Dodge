using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public ObjectPoolTest pool;

    public Transform[] spawnPointTest;

    float timerTest;

    private void Awake()
    {
        spawnPointTest = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timerTest += Time.deltaTime;

        if (timerTest > 1f)
        {
            MonsterSpawnTest();
            timerTest = 0f;
        }
    }

    private void MonsterSpawnTest()
    {
        GameObject monsterTest = pool.Get(0);
        monsterTest.transform.position = spawnPointTest[Random.Range(1, spawnPointTest.Length)].position;
    }
}
