using System.Runtime.CompilerServices;
using System.Security.Claims;
using UnityEngine;

public class MonsetAim : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Vector3 flipPivotPosition;
    [SerializeField] private Vector3 originPosition;
    private MonsterController controller;

    private void Awake()
    {
        controller = GetComponent<MonsterController>();
        controller.OnLookEvent += OnAim;
    }
    private void OnAim(Vector2 direction)
    {
        if (controller.isRange)
        {
            ApplyLook(direction);
            RotateWeapon(direction);
        }
        else
        {
            ApplyLook(direction);
            FlipWeapon(direction);
        }
        
    }
    //Enemy0 flip,origin Vector2(-0.432f, 0.04f)/(0.531f,-0.025f);
    //Enemy3 flip,origin Vector2(-0.33,-0.24)/ (0.4,-0.24)
    private void ApplyLook(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        characterRenderer.flipX = (rotZ) < 0f ;
    }
    private void RotateWeapon(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        bool flip = Mathf.Abs(rotZ) > 90f;
        armRenderer.flipY = flip;
        if (flip)
            armPivot.localPosition = flipPivotPosition;
        else
            armPivot.localPosition = originPosition;
    }
    private void FlipWeapon(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool flip =Mathf.Abs(rotZ) > 90f;
        if (flip)
        {
            armPivot.rotation = Quaternion.Euler(new Vector3(0,0,51f));
            armRenderer.flipX = true; 
            armPivot.localPosition = flipPivotPosition;
        }
        else
        {
            armPivot.rotation = Quaternion.Euler(Vector3.zero);
            armRenderer.flipX = false;
            armPivot.localPosition = originPosition;
        }
    }
}