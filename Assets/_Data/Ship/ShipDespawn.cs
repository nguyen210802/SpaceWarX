using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.despawnAudioClip);
        transform.parent.gameObject.SetActive(false);
    }
}
