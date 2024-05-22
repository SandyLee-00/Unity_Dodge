using System;
using TreeEditor;
using UnityEngine;

public class RushMonsterTest : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private GameObject player;
    private Vector3 targetDir;
    private bool isRushing = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
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
        scale.x = v ? -0.7f : 0.7f;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player"))
        {
            player.GetComponentInChildren<HPBar>().DecreaseHP(2);
            gameObject.SetActive(false);
        }
    }
}
