using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{   //get MonsterInfo
    protected Transform Target { get; private set; }
    public event Action<Vector2> OnMoveEvent; 
    public event Action<Vector2> OnLookEvent;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Target.position = Player.position 
    }

    
    protected virtual void FixedUpdate()
    {
        CallLookEvent(DistanceToTarget());
        CallMoveEvent(DistanceToTarget());
    }
    protected Vector2 DistanceToTarget()
    {
        return new Vector3(1000,1000,0) -transform.position;
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

}
