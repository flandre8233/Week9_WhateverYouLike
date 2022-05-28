using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectPointControll : SingletonMonoBehavior<ReflectPointControll>
{
    public Vector3 PrevReflectPoint;

    public void OnPlayerClickMove()
    {
        UpdateReflectPoint(transform.position);
    }

    public void UpdateReflectPoint(Vector3 NewReflectPoint)
    {
        PrevReflectPoint = NewReflectPoint;
    }

    public float GetDisantce(Vector3 NewReflectPoint)
    {
        return Vector3.Distance(PrevReflectPoint, NewReflectPoint);
    }
}
