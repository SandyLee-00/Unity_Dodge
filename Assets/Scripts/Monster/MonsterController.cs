using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MonsterController : MonoBehaviour
{   //get MonsterInfo
    //[SerializeField] protected GameObject Target;
    protected Vector3 mousePos;
    protected Rigidbody2D movementRigidbody;
    protected event Action<Vector2> OnMoveEvent; 
    protected event Action<Vector2> OnLookEvent;
    protected Animator animator;
    public MonsterStat stat;

    protected bool IsAttacking { get; set; }

    protected virtual void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {
        
    }
    protected virtual void FixedUpdate()
    {

    }
    
    
    protected Vector2 DistanceToTarget()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos - transform.position;
        //return Target.position - transfom.position
    }
    protected void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    protected void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

}
