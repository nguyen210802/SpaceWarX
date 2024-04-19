using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearingBigger : ObjAppearing
{
    [Header("Object Appearing Bigger")]
    [SerializeField] protected float currentScale = 0;
    public float GetCurrentScale => currentScale;

    [SerializeField] protected float startScale = 0;
    [SerializeField] protected float maxScale = 1;
    [SerializeField] protected float speedScale = 0.01f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitScale();
    }

    protected override void Appearing()
    {
        this.currentScale += this.speedScale;
        transform.parent.localScale = new Vector3(this.currentScale, this.currentScale, this.currentScale);
        if (this.currentScale >= this.maxScale)
            this.Appear();
    }

    protected virtual void InitScale()
    {
        transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
    }

    public override void Appear()
    {
        base.Appear();
        this.transform.parent.localScale = new Vector3(this.maxScale, this.maxScale, this.maxScale);
    }
}
