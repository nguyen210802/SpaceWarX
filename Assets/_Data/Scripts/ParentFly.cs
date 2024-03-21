using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : NguyenMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
