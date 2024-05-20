using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;

    private PlayerInputController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        playerController.OnLookEvent += OnAim;
    }

    void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
