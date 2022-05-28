using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDispenser : MonoBehaviour
{
    public void Init()
    {
        SetPosY();
        RandomPosX();
        Destroy(this);
    }

    void SetPosY()
    {
        //float Y = CubeControll.instance.GetCurrentSpawnY();
        //transform.position = new Vector3(transform.position.x, Y, transform.position.z);
    }

    void RandomPosX()
    {
        float mapRadius = WallControll.instance.GetMapRadius() * 0.85f;
        transform.position = new Vector3(Random.Range(-mapRadius, mapRadius), transform.position.y, transform.position.z);
    }

}
