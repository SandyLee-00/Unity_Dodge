using System;
using UnityEngine;

public class MonsterShootingTest : MonoBehaviour
{
    public GameObject MosterBulletPrefab;
    public Transform firePoint;

    //ObjectPool pool;

    public float MonsterBulletSpeedTest = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootMonsterBullet();
        }
    }

    private void ShootMonsterBullet()
    {
        GameObject MonsterBullet = Instantiate(MosterBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = MonsterBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * MonsterBulletSpeedTest;
        }
    }
}
