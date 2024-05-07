using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLaser : SkillAbstract
{
    private static SkillLaser instance;
    public static SkillLaser Instance => instance;

    [SerializeField] protected GameObject laser;
    public GameObject GetLaser => laser;

    [SerializeField] protected GameObject objShooting;

    [SerializeField] private float timeIndex = 0f;
    [SerializeField] private float timeFireLaser = 5f;

    [SerializeField] private float timeDelaySkill = 0f;
    [SerializeField] private float timeCD = 20f;

    protected override void Awake()
    {
        base.Awake();
        SkillLaser.instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && this.timeDelaySkill <= 0)
        {
            this.timeDelaySkill = this.timeCD;
            this.timeIndex = this.timeFireLaser;
            this.StartFire();
            Invoke("StopFire", this.timeFireLaser);
        }
    }

    private void FixedUpdate()
    {
        this.timeDelaySkill -= Time.fixedDeltaTime;
        if (this.timeDelaySkill <= 0) this.timeDelaySkill = 0;

        this.timeIndex -= Time.fixedDeltaTime;
        if (this.timeIndex <= 0) this.timeIndex = 0;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLaser();
        this.LoadObjShooting();
    }

    protected virtual void LoadLaser()
    {
        if (laser != null) return;
        laser = transform.Find("Laser").gameObject;
        laser.SetActive(false);
    }
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = transform.parent.parent.Find("ObjShooting").gameObject;
        //Debug.Log(transform.name, ": LoadObjShooting", gameObject);
    }

    protected virtual void StartFire()
    {
        this.laser.SetActive(true);
        this.objShooting.SetActive(false);
        skillCtrl.GetSkillInvisible.GetInvisible.StopInvisible();
    }

    public virtual void StopFire()
    {
        laser.gameObject.SetActive(false);
        this.objShooting.SetActive(true);
    }
}
