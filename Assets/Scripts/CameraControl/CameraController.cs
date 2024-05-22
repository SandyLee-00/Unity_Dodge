using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Managers.Game.IsGameEnd)
        {
            return;
        }

        Vector3 targetPosition = Managers.Game.Player.transform.position;
        targetPosition.z = transform.position.z;

        // transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
    }
}
