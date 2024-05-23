using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float horizontalMovement;
    [SerializeField] protected float verticalMovement;
    private void FixedUpdate()
    {
        this.Movement();
    }

    protected void Movement()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f);

        //transform.parent.Translate(movement * this.speed);
        transform.parent.position += movement * speed;
        this.MoveLimit();
    }

    protected virtual void MoveLimit()
    {
        Vector3 limit = transform.parent.position;
        limit.x = Mathf.Clamp(limit.x, -MapCtrl.Instance.GetLimitX, MapCtrl.Instance.GetLimitX);
        limit.y = Mathf.Clamp(limit.y, -MapCtrl.Instance.GetLimitY, MapCtrl.Instance.GetLimitY);

        transform.parent.position = limit;
    }
}
