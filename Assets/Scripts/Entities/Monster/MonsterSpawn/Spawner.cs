using System.Collections.Generic;
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
    private GameObject monsterPrefab;
    [SerializeField] 
    private float monsterSpawnInterval = 2;

    [SerializeField]
    List<GameObject> itemPrefab;
    [SerializeField]
    private float itemSpawnInterval = 3;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        InvokeRepeating("SpawnMonster", 0f, monsterSpawnInterval);

        InvokeRepeating("SpawnItem", 0f, itemSpawnInterval);
    }

    private void SpawnMonster()
    {
        Instantiate(monsterPrefab, transform);
        
        monsterPrefab.transform.position = GetRandomSpawnPosition(player.position, 20, 10);
    }

    private void SpawnItem()
    {
        // random item
        int randomIndex = random.Next(0, itemPrefab.Count);
        GameObject item = itemPrefab[randomIndex];
        string itemName = item.name;

        Debug.Log(itemName);
        GameObject spawnedItem = pool.SpawnFromPool(itemName);

        // random position
        spawnedItem.transform.position = GetRandomSpawnPosition(player.position, 5, 1);
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