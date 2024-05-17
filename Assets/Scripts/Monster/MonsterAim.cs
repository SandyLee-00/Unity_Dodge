using System.Runtime.CompilerServices;
using System.Security.Claims;
using UnityEngine;

public class MonsetAim : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private bool isRange;
    private MonsterController controller;

    private void Awake()
    {
        controller = GetComponent<MonsterController>();
        controller.OnLookEvent += OnAim;
    }
    private void OnAim(Vector2 direction)
    {
        if (!isRange)
        {
            ApplyLook(direction);
            FlipWeapon(direction);
        }
        else
        {
            ApplyLook(direction);
            RotateWeapon(direction);
        }
        
    }
    private void ApplyLook(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        characterRenderer.flipX = (rotZ) < 0f ;
        Debug.Log("이벤트실행") ;
    }
    private void RotateWeapon(Vector2 direction)
    {
         float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    private void FlipWeapon(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool flip =Mathf.Abs(rotZ) > 90f;
        Debug.Log(rotZ);
        if (flip)
        {
            armPivot.rotation = Quaternion.Euler(0, 0, 142f);
            armRenderer.transform.rotation = Quaternion.Euler(0, 0, 60f);
        }
        else
        {
            armPivot.rotation = Quaternion.Euler(0, 0, -5f);
            armRenderer.transform.rotation = Quaternion.Euler(0, 0, -27f);

        }
    }
}