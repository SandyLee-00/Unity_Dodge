using System.Runtime.CompilerServices;
using System.Security.Claims;
using UnityEngine;

public class MonsetAim : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private bool isRange;
    //[SerializeField] private Vector3 flipPivotPosition;
    //[SerializeField] private Vector3 originPosition;
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
    Vector2 flipPivotPosition = new Vector2(-0.432f, 0.04f);
    Vector2 originPosition = new Vector2(0.531f,-0.025f);
    private void ApplyLook(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        characterRenderer.flipX = (rotZ) < 0f ;
    }
    private void RotateWeapon(Vector2 direction)
    {
         float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
         characterRenderer.flipX = Mathf.Abs(rotZ) < 90f;
    }
    private void FlipWeapon(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool flip =Mathf.Abs(rotZ) > 90f;
        if (flip)
        {
            armPivot.rotation = Quaternion.Euler(new Vector3(0,0,51f));
            Debug.Log(direction);
            armRenderer.flipX = true;
            Debug.Log(armPivot.rotation);
            armPivot.localPosition = flipPivotPosition;
            //armRenderer.transform.localRotation = Quaternion.Euler(0, 0, 60f);
        }
        else
        {
            armPivot.rotation = Quaternion.Euler(Vector3.zero);
            armRenderer.flipX = false;
            armPivot.localPosition = originPosition;
            //armRenderer.transform.localRotation = Quaternion.Euler(0, 0, -22f);

        }
    }
}