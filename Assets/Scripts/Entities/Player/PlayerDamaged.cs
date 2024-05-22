using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] HPBar HPBar;
    PlayerInputController playerController;
    public event Action OnHittedEvent;

    BoxCollider2D playerCollider;

    [SerializeField] float healthChangeDelay = 0.3f;
    private float timeSinceLastChange = float.MaxValue;

    PlayerAnimationController playerAniController;
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Sprite deadSprite;

    private void Awake()
    {
        playerController = GetComponent<PlayerInputController>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAniController = GetComponent<PlayerAnimationController>();
    }

    private void Start()
    {
        OnHittedEvent += PlayerHitted;
    }

    private void Update()
    {
        timeSinceLastChange += Time.deltaTime;
    }
    private void PlayerHitted()
    {
        if (healthChangeDelay < timeSinceLastChange)
        {
            ChangeHealth();
        }
    }

    void ChangeHealth()
    {
        if (!HPBar.DecreaseHP(1f))
        {
            playerSprite.sprite = deadSprite;

            playerController.isAlive = false;
            playerCollider.enabled = false;

            playerAniController.Dead();
        }
        timeSinceLastChange = 0f;
    }

    private void CallHittedEvent()
    {
        OnHittedEvent?.Invoke();
    }

    public bool GetInvincibleStatus()
    {
        return HPBar.IsInvincible;
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            if (timeSinceLastChange < healthChangeDelay)
            {
                return;
            }

            CallHittedEvent();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MonsterBullet")
        {
            if (timeSinceLastChange < healthChangeDelay)
            {
                return;
            }

            CallHittedEvent();
        }
    }
}
