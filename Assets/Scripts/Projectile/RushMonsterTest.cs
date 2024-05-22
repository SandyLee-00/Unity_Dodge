using System;
using TreeEditor;
using UnityEngine;

public class RushMonsterTest : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private ObjectPool objPool;

    private GameObject player;
    private Vector3 targetDir;
    private bool isRushing = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        objPool = FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {   
        if (player != null)
        {
            targetDir = (player.transform.position - transform.position);
            isRushing = true;

            if (targetDir.x < 0)
            {
                FlipSprite(true);
            }
        }
    }


    private void Update()
    {
        if (isRushing)
        {
            transform.position += targetDir * speed * Time.deltaTime;
        }
    }
    
    private void FlipSprite(bool v)
    {
        Vector3 scale = transform.localScale;
        scale.x = v ? -1 : 1;
        transform.localScale = scale;
    }
}
