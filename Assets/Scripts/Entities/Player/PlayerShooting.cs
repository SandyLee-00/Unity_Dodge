using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour
{
    PlayerInputController playerController;
    private Vector2 aimDirection = Vector2.right;
    [SerializeField] private Transform projectileSpawnPosition;

    public GameObject bulletPrefab;

    ObjectPool pool;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
        pool = FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        playerController.OnLookEvent += OnAim;
        playerController.OnAttackEvent += OnShoot;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO RangedAttackSO = attackSO as RangedAttackSO;
        float projectilesAngleSpace = RangedAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = RangedAttackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * RangedAttackSO.multipleProjectilesAngle;


        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-RangedAttackSO.spread, RangedAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(RangedAttackSO, angle);
        }
    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
        GameObject obj = pool.SpawnFromPool(rangedAttackSO.bulletNameTag);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), rangedAttackSO);
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}

