using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : NguyenMonoBehaviour
{
    [SerializeField] protected Transform target;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;

        transform.position = target.position;
    }
}
