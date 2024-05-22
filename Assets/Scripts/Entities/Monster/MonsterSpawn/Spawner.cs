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

    private Transform Player;
    ObjectPool pool;

    [SerializeField] 
    private GameObject monsterPrefab;
    [SerializeField] private float monsterSpawnInterval = 2;

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
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("SpawnMonster", 0f, monsterSpawnInterval);

        InvokeRepeating("SpawnItem", 0f, itemSpawnInterval);
    }

    private void SpawnMonster()
    {
        Instantiate(monsterPrefab, transform);
        int signX = random.Next(0, 2) == 0 ? 1 : -1;
        float rdPosX = random.Next(10, 20) * signX;
        int signY = random.Next(0, 2) == 0 ? 1 : -1;
        float rdPosY = random.Next(10, 20) * signY;
        monsterPrefab.transform.position = new Vector2(Player.position.x + rdPosX, Player.position.y + rdPosY);
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
        int signX = random.Next(0, 2) == 0 ? 1 : -1;
        float rdPosX = random.Next(3, 5) * signX;
        int signY = random.Next(0, 2) == 0 ? 1 : -1;
        float rdPosY = random.Next(3, 5) * signY;

        spawnedItem.transform.position = new Vector2(Player.position.x + rdPosX, Player.position.y + rdPosY);
    }
}