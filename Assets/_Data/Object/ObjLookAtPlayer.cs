using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjLookAtPlayer : ObjLookAtTarget
{
    [Header("Look At Player")]
    [SerializeField] protected GameObject player;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadObjectAppearing", gameObject);
    }

    protected virtual void GetMousePosition()
    {
        if (this.player == null) return;
        this.targetPosition = player.transform.position;
        this.targetPosition.z = 0;
    }
}
