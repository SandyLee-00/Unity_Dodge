using System;
using UnityEngine;

public class MonsterShootingTest : MonoBehaviour
{
    MonsterController monsterController;
    private Vector2 aimDirection = Vector2.right;
    [SerializeField] private Transform projectileSpawnPosition;

    public GameObject bulletPrefab;

    ObjectPool pool;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        pool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        
    }
}
