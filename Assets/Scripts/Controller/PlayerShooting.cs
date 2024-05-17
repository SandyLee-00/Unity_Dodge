using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    PlayerInputController playerController;
    private Vector2 aimDirection = Vector2.right;
    [SerializeField] private Transform projectileSpawnPosition;

    public GameObject bulletPrefab;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
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

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.position = projectileSpawnPosition.position;
    }
}
