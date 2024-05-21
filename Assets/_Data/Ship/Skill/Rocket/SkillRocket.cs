using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRocket : SkillAbstract
{
    private static SkillRocket instance;
    public static SkillRocket Instance => instance;

    [SerializeField] protected bool locked = true;

    [SerializeField] private float timeDelaySkill = 0f;
    public float GetTimeDelaySkill => timeDelaySkill;
    [SerializeField] private float timeCD = 8f;

    [SerializeField] private GameObject canvasLock;
    [SerializeField] private GameObject canvasUnLock;

    protected override void Awake()
    {
        base.Awake();
        SkillRocket.instance = this;
    }

    protected override void Start()
    {
        canvasLock.SetActive(true);
        canvasUnLock.SetActive(false);
    }

    private void Update()
    {
        if(this.locked) return;
        if (Input.GetMouseButtonDown(1))
        {
            this.FireRocket();
        }
    }

    public void UnLock()
    {
        this.locked = false;
        canvasLock.SetActive(false);
        canvasUnLock.SetActive(true);
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
