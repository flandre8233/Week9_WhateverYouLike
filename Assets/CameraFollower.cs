using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] float Speed;
    Transform TargetObjcet;

    // Start is called before the first frame update
    void Start()
    {


        TargetObjcet = PlayerControll.instance.GetPlayerObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControll.instance.GetPlayerObject())
        {
            Destroy(this);
            return;
        }

        GameObject NextCube = CubeControll.instance.GetNext();
        Vector3 WantedPos = TargetObjcet.position;
        float WantedY = Mathf.Clamp(WantedPos.y + 2, transform.position.y, NextCube.transform.position.y + 2);
        WantedPos = new Vector3(transform.position.x, WantedY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, WantedPos, Time.deltaTime * Speed);
    }
}
