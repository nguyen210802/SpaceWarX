using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : NguyenMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (points.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }

    public virtual Transform GetRanDom()
    {
        int rand = Random.Range(0, points.Count);
        return points[rand];
    }
}
