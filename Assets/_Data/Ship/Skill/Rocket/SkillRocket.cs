﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRocket : SkillAbstract
{
    private static SkillRocket instance;
    public static SkillRocket Instance => instance;

    [SerializeField] private float timeDelaySkill = 0f;
    public float GetTimeDelaySkill => timeDelaySkill;
    [SerializeField] private float timeCD = 8f;

    protected override void Awake()
    {
        base.Awake();
        SkillRocket.instance = this;
    }

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
        Transform newRocket = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.rocket, spawnPos, rotation);
        if (newRocket == null)
            return;
        RocketFly rocketCtrl = newRocket.transform.GetComponentInChildren<RocketFly>();
        rocketCtrl.SetPosStart(transform.parent.parent.position);
        newRocket.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        this.timeDelaySkill -= Time.fixedDeltaTime;
        if (this.timeDelaySkill <= 0) this.timeDelaySkill = 0;
    }
}
