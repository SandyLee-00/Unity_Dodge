using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private Camera camera;
    Rigidbody2D movementRigidbody;
    private Vector2 movementDirection = Vector2.zero;
    [SerializeField] float speed = 5.0f;

    private void Awake()
    {
        camera = Camera.main; // mainCamera�±� �پ��ִ� ī�޶� ������
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movementRigidbody.velocity = movementDirection * speed;
    }

    private void OnMove(InputValue value)  // �������� ó�� (Input Actions Send Messages)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        movementDirection = moveInput;
    }

    private void OnLook(InputValue value)   // �÷��̾ �ٶ󺸴� ������ ó�� (Input Actions Send Messages)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;       // worldPos - �÷��̾� ��ġ ��� �� �ش� ������ �ٶ󺸴� ���͸� ���� �� ����.
    }
}
