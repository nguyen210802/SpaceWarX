using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRocket : SkillAbstract
{
    private static TestRocket instance;
    public static TestRocket Instance => instance;

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] private float timeDelaySkill = 0f;
    public float GetTimeDelaySkill => timeDelaySkill;
    [SerializeField] private float timeCD = 8f;

    protected override void Awake()
    {
        base.Awake();
        TestRocket.instance = this;
    }

    private void Update()
    {
        this.targetPosition = InputManager.Instance.GetMouseWorldPos;
        this.targetPosition.z = 0;
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

        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion targetEuler = Quaternion.Euler(0, 0, rot_z);


        Transform newRocket = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.rocket, spawnPos, targetEuler);
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
