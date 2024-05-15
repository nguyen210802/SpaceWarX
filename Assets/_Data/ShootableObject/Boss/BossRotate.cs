using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : NguyenMonoBehaviour
{
    [SerializeField] protected float speed = 10;

    private void Update()
    {
        transform.parent.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
