using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRocket : SkillAbstract
{
    [SerializeField] private float timeDelaySkill = 0f;
    [SerializeField] private float timeCD = 20f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            this.FireRocket();
        }
    }

    protected virtual void FireRocket()
    {
        if (this.timeDelaySkill > 0) return;
        this.timeDelaySkill = this.timeCD;
        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.rocket, spawnPos, rotation);
        if (newBullet == null)
            return;

        newBullet.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        this.timeDelaySkill -= Time.fixedDeltaTime;
        if (this.timeDelaySkill <= 0) this.timeDelaySkill = 0;
    }
}
