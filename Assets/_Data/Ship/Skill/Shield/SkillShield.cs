using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShield : SkillAbstract
{
    private static SkillShield instance;
    public static SkillShield Instance => instance;

    [SerializeField] protected GameObject shield;
    public GameObject GetShield => shield;

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;

    [SerializeField] private float timeDelaySkill = 0f;
    public float GetTimeDelaySkill => timeDelaySkill;

    [SerializeField] private float timeCD = 12f;

    protected override void Awake()
    {
        base.Awake();
        SkillShield.instance = this;
    }

    private void Update()
    {
        if (this.timeDelaySkill <= 0)
        {
            this.ActivateShield();
        }
        this.ActiveDamageReceiver();
    }

    private void FixedUpdate()
    {
        this.timeDelaySkill -= Time.fixedDeltaTime;
        if (this.timeDelaySkill <= 0)
            this.timeDelaySkill = 0;
    }

    protected virtual void ActivateShield()
    {
        this.shield.SetActive(true);
    }

    protected virtual void ActiveDamageReceiver()
    {
        if (shield.activeSelf)
            this.shipDamageReceiver.SetShield(true);
        else
            this.shipDamageReceiver.SetShield(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShield();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadShield()
    {
        if (this.shield != null) return;
        shield = transform.Find("Shield").gameObject;
        Debug.Log(transform.name + ": LoadShield", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if(this.shipDamageReceiver != null) return;
        GameObject damageReceiver = transform.parent?.parent?.Find("DamageReceiver").gameObject;
        this.shipDamageReceiver = damageReceiver.GetComponent<ShipDamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    public virtual void TimeDespawn()
    {
        this.timeDelaySkill = this.timeCD;
    }
}
