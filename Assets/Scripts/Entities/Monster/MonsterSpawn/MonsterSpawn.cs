using UnityEngine;
using Random = System.Random;

class MonsterSpawn : MonoBehaviour
{
    Random random = new Random();
    private Transform Player;
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float spawnInterval;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    private void Spawn()
    {
        Instantiate(monsterPrefab,transform);
        int signX = random.Next(0, 2) == 0 ? 1: -1;
        float rdPosX = random.Next(10, 20) * signX;
        int signY = random.Next(0, 2) == 0 ? 1 : -1;
        float rdPosY = random.Next(10, 20)* signY;
        monsterPrefab.transform.position =new Vector2(Player.position.x + rdPosX,Player.position.y +rdPosY);
    }
}