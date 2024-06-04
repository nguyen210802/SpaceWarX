using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Line : NguyenMonoBehaviour
{
    [SerializeField] protected LineRenderer line;
    [SerializeField] protected GameObject player;
    [SerializeField] protected SniperShooting sniperShooting;

    private Vector3 startPoint;
    private Vector3 endPoint;

    [SerializeField] protected float timeLine;
    [SerializeField] protected float timeDelayLine = 2f;

    [SerializeField] protected float timeShoot;
    [SerializeField] protected float timeDelayShoot = 5f;

    [SerializeField] protected float minDistance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLineRenderer();
        this.LoadPlayer();
        this.LoadSniperShooting();
    }

    protected virtual void LoadLineRenderer()
    {
        if (this.line != null) return;
        this.line = transform.GetComponent<LineRenderer>();
        Debug.Log(transform.name + ": LoadLineRenderer", gameObject);
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
    protected virtual void LoadSniperShooting()
    {
        if (this.sniperShooting != null) return;
        this.sniperShooting = transform.GetComponent<SniperShooting>();
        Debug.Log(transform.name + ": LoadSniperShooting", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        line.positionCount = 2;

        line.startWidth = 0.04f;
        line.endWidth = 0.04f;

        this.timeLine = this.timeDelayLine;
        this.timeShoot = this.timeDelayShoot;
    }

    private void FixedUpdate()
    {
        this.startPoint = transform.parent.position;
        this.endPoint = player.transform.position;

        this.Shoot();
    }

    protected virtual void Shoot()
    {
        this.timeShoot -= Time.fixedDeltaTime;

        if (this.timeShoot <= 0)
            this.timeShoot = 0;

        if (this.timeShoot > 0) return;

        line.enabled = true;
        this.LineA();
    }

    protected virtual void LineA()
    {
        this.timeLine -= Time.fixedDeltaTime;
        if (this.timeLine <= 0)
            this.timeLine = 0;

        if (this.timeLine > 0)
        {
            line.SetPosition(0, startPoint);
            line.SetPosition(1, endPoint);
        }
        else
        {
            line.enabled = false;

            this.timeLine = this.timeDelayLine;
            this.timeShoot = this.timeDelayShoot;

            Invoke("Shooting", 0.5f);
        }
    }

    protected virtual void Shooting()
    {
        Vector3 pos = transform.parent.position;

        Vector3 diff = this.player.transform.position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(0, 0, rot_z);

        this.sniperShooting.Shoot(pos, rot);
    }
}
