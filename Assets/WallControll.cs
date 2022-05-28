using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControll : SingletonMonoBehavior<WallControll>
{
    [SerializeField] float MapRadius;
    [SerializeField] Transform LeftWall;
    [SerializeField] Transform RightWall;
    // Start is called before the first frame update
    void Start()
    {
        SetUpWall(LeftWall, true);
        SetUpWall(RightWall, false);
    }

    void SetUpWall(Transform WallTrans, bool IsLeft)
    {
        WallTrans.position = new Vector3(MapRadius * (IsLeft ? -1 : 1), WallTrans.position.y, WallTrans.position.z);
    }

    public float GetMapRadius()
    {
        return MapRadius;
    }
}
