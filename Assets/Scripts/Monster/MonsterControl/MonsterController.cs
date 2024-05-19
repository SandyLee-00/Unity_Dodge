using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MonsterController : MonoBehaviour
{   
    protected GameObject target;
    protected Vector3 mousePos;
    protected Rigidbody2D movementRigidbody;
    protected event Action<Vector2> OnMoveEvent; 
    public event Action<Vector2> OnLookEvent;
    protected Animator animator;
    public MonsterStat stat;

    protected bool IsAttacking { get; set; }

    protected virtual void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        target = GameObject.FindWithTag("Player"); 
    }

    protected virtual void Start()
    {
        
    }
    protected virtual void FixedUpdate()
    {
        CallLookEvent(DistanceToTarget());
        CallMoveEvent(DistanceToTarget());

    }


    public Vector2 DistanceToTarget()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //return mousePos - transform.position;
        return target.transform.position - transform.position;
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    protected void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }


}
