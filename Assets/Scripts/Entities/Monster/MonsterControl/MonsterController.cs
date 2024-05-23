using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MonsterController : MonoBehaviour
{   
    [NonSerialized]public GameObject target;
    [NonSerialized]public CharacterStat stat;
    protected Rigidbody2D movementRigidbody;
    protected event Action<Vector2> OnMoveEvent; 
    public event Action<Vector2> OnLookEvent;
    [SerializeField]internal Animator animatorCharacter;
    [SerializeField]internal Animator animatorWeapon;
    [SerializeField]internal bool isRange;
    protected bool IsAttacking { get; set; }

    protected virtual void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player"); 
        stat = GetComponentInChildren<CharacterStat>();
        
    }

    protected virtual void Start()
    {
        IsAttacking = false;
    }
    protected virtual void FixedUpdate()
    {
        CallLookEvent(DistanceToTarget());
        CallMoveEvent(DistanceToTarget());
    }


    public Vector2 DistanceToTarget()
    {
        return (target.transform.position - transform.position);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    protected void CallMoveEvent(Vector2 direction)
    {
        if(!IsAttacking)
            OnMoveEvent?.Invoke(direction);
    }


}
