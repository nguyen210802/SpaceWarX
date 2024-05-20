using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] protected float speed;
    private void FixedUpdate()
    {
        this.Movement();
    }

    protected void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f);

        //transform.parent.Translate(movement * this.speed);
        transform.parent.position += movement * speed; 
    }
}
