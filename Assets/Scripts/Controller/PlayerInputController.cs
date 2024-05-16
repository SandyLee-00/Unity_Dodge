using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private Camera camera;
    Rigidbody2D movementRigidbody;
    private Vector2 movementDirection = Vector2.zero;
    Animator playerAnimator;

    [SerializeField] float speed = 5.0f;

    private void Awake()
    {
        camera = Camera.main; // mainCamera태그 붙어있는 카메라 가져옴
        movementRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();  
    }

    private void FixedUpdate()
    {
        movementRigidbody.velocity = movementDirection * speed;
    }

    private void OnMove(InputValue value)  // 움직임을 처리 (Input Actions Send Messages)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        movementDirection = moveInput;
        playerAnimator.SetFloat("Speed", movementDirection.magnitude);
    }

    private void OnLook(InputValue value)   // 플레이어가 바라보는 방향을 처리 (Input Actions Send Messages)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;       // worldPos - 플레이어 위치 계산 시 해당 지점을 바라보는 벡터를 구할 수 있음.
    }
}
