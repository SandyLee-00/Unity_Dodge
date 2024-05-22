using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BackgroundMovement : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        if(Managers.Game.IsGameEnd)
        {
            return;
        }

        Vector3 playerPos = Managers.Game.Player.transform.position;
        Vector3 myPos = transform.position;

        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffx = Mathf.Abs(dirX);
        float diffy = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;


        if (transform.tag == "Ground")
        {
            if (diffx >= diffy)
            {
                transform.Translate(Vector3.right * dirX * 40);
            }
            else
            {
                 transform.Translate(Vector3.up * dirY * 40);
            }
        }
    }

}
