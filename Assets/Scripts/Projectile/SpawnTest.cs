using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawnPointTest;

    float timer;

    private void Awake()
    {
        spawnPointTest = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            MonsterSpawnTest();
            timer = 0f;
        }
    }

    private void MonsterSpawnTest()
    {
        GameObject monsterTest = Instantiate(monsterPrefab);
        
        if (monsterTest != null )
        {
            Transform spawnPoint = spawnPointTest[Random.Range(1, spawnPointTest.Length)];
            monsterTest.transform.position = spawnPoint.position;
            Destroy(monsterTest, 3f);
        }
    }
}
