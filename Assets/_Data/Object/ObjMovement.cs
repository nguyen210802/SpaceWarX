using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjMovement : NguyenMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance;
    [SerializeField] protected float minDistance = 2f;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected virtual void Moving()
    {
        if(string.Equals(transform.parent.name, "Ship"))
        {
            this.distance = Vector2.Distance(transform.position, InputManager.Instance.GetMouseWorldPos);
            if (this.distance < this.minDistance) return;
        }
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}
