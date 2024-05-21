using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        transform.gameObject.SetActive(false);
    }
}
