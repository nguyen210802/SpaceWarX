using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : NguyenMonoBehaviour
{
    private static Invisible instance;
    public static Invisible Instance => instance;

    [SerializeField] protected SkillInvisible skillInvisible;

    private Renderer objectRenderer;
    [SerializeField] private float indexAlpha = 0.2f;

    [SerializeField] private float timeIndex = 0f;

    [SerializeField] private float timeInvisible = 5f;
    public float GetTimeInvisible => timeInvisible;

    [SerializeField] protected float critTimeBonus = 0f;
    public void SetCritTimeBonus(float value) { this.critTimeBonus = value; }

    [SerializeField] private float timeDelaySkill = 0f;
    public float GetTimeDelaySkill => timeDelaySkill;

    [SerializeField] private float timeCD = 8f;
    public float GetTimeCD => timeCD;

    [SerializeField] private bool invisible = false;
    public bool GetInvisible => invisible;

    protected override void Awake()
    {
        base.Awake();
        Invisible.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInvisibleCtrl();
    }

    protected virtual void LoadInvisibleCtrl()
    {
        if (this.skillInvisible != null) return;
        this.skillInvisible = transform.parent.GetComponent<SkillInvisible>();
        Debug.Log(transform.name + ": LoadInvisibleCtrl", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        objectRenderer = skillInvisible.GetSkillCtrl.GetShipCtrl.GetModel.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && this.timeDelaySkill <= 0)
        {
            float newTimeInvisible = this.timeInvisible * (1 + this.critTimeBonus);

            this.timeDelaySkill = this.timeCD;
            this.timeIndex = newTimeInvisible;
            this.StartInvisible();
            Invoke("StopInvisible", newTimeInvisible);
        }
    }

    private void FixedUpdate()
    {
        this.timeDelaySkill -= Time.fixedDeltaTime;
        if (this.timeDelaySkill <= 0) this.timeDelaySkill = 0;

        this.timeIndex -= Time.fixedDeltaTime;
        if (this.timeIndex <= 0) this.timeIndex = 0;
    }

    protected void StartInvisible()
    {
        invisible = true;

        Color objectColor = objectRenderer.material.color;
        objectColor.a = indexAlpha;
        objectRenderer.material.color = objectColor;

        skillInvisible.GetSkillCtrl.GetSkillLaser.StopFire();
    }

    public void StopInvisible()
    {
        this.invisible = false;
        Color objectColor = objectRenderer.material.color;
        objectColor.a = 1;
        objectRenderer.material.color = objectColor;
    }
}
