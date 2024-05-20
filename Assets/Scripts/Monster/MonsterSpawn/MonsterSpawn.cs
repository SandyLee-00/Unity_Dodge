using UnityEngine;
using Random = System.Random;

class MonsterSpawn : MonoBehaviour
{
    Random random = new Random();
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private float spawnInterval;

    void Start()
    {
        // 일정 시간 간격으로 SpawnMonster 메서드를 호출
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    private void Spawn()
    {
        Instantiate(monsterPrefab);
        int signX = random.Next(0, 2) == 0 ? 1: -1;
        float rdPosX = random.Next(10, 20) * signX;
        int signY = random.Next(0, 2) == 0 ? 1 : -1;
        float rdPosY = random.Next(10, 20)* signY;
        monsterPrefab.transform.position =new Vector2(Player.position.x + rdPosX,Player.position.y +rdPosY);
    }
}