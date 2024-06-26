using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// monster : X spawn from pool, at Spawner
/// bullet : O spawn from pool, at PlayerShooting
/// item : O spawn from pool, at Spawner
/// </summary>
class Spawner : MonoBehaviour
{
    Random random = new Random();

    private Transform player;
    ObjectPool pool;

    [SerializeField]
    List<GameObject> monsterPrefabs;
    [SerializeField] 
    private float monsterSpawnInterval = 2;

    [SerializeField]
    List<GameObject> itemPrefabs;
    [SerializeField]
    private float itemSpawnInterval = 3;

    [SerializeField]
    List<GameObject> RushMonsterPrefabs;
    [SerializeField]
    private float RushSpawnInterval = 2;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        InvokeRepeating("SpawnMonster", 0f, monsterSpawnInterval);

        InvokeRepeating("SpawnItem", 0f, itemSpawnInterval);

        InvokeRepeating("SpawnRush", 0f, RushSpawnInterval);
    }

    private void SpawnMonster()
    {
        // random monster
        int randomIndex = random.Next(0, monsterPrefabs.Count);
        GameObject monster = monsterPrefabs[randomIndex];
        string monsterName = monster.name;

        Debug.Log(monsterName);

        Vector3 spawnPosition = GetRandomSpawnPosition(player.position, 20, 10);

        Instantiate(monster, spawnPosition, Quaternion.identity);
    }

    private void SpawnItem()
    {
        // random item
        int randomIndex = random.Next(0, itemPrefabs.Count);
        GameObject item = itemPrefabs[randomIndex];
        string itemName = item.name;

        Debug.Log(itemName);
        GameObject spawnedItem = pool.SpawnFromPool(itemName);

        // random position
        spawnedItem.transform.position = GetRandomSpawnPosition(player.position, 5, 1);
    }

    private void SpawnRush()
    {
        int randomIndex = random.Next(0, RushMonsterPrefabs.Count);
        GameObject rush = RushMonsterPrefabs[randomIndex];
        string rushName = rush.name;

        Debug.Log(rushName);

        Vector3 spawnPosition = GetRandomSpawnPosition(player.position, 20, 10);

        Instantiate(rush, spawnPosition, Quaternion.identity);
    }

    private Vector2 GetRandomSpawnPosition(Vector2 center, int maxRadius, int minRadius = 0)
    {
        // random angle
        float angle = random.Next(0, 360);
        Vector2 spawnDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        spawnDirection.Normalize();

        // random distance
        float randomDistance = random.Next(minRadius, maxRadius);
        Vector2 spawnPosition = center + spawnDirection * randomDistance;

        return spawnPosition;
    }
}