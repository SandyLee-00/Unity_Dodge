using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
