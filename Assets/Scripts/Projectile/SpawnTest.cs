using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    //public ObjectPool pool;
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

        if (timer > 4f)
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
            //monsterTest.transform.position = spawnPointTest[Random.Range(1, spawnPointTest.Length)].position;
            Transform spawnPoint = spawnPointTest[Random.Range(1, spawnPointTest.Length)];
            monsterTest.transform.position = spawnPoint.position;
            //Invoke("DestroyMonster", 3f);
            Destroy(monsterTest, 3f);
        }
    }

    //private void DestroyMonster()
    //{
    //    GameObject[] monsters = GameObject.FindGameObjectsWithTag("MonsterBullet");

    //    foreach (GameObject monster in monsters)
    //    {
    //        Destroy(monster);
    //    }
    //}
}
