using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suction : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControll.instance.GetPlayerObject())
        {
            Destroy(this);
            return;
        }

        if (IsPlayerNear())
        {
            OnPlayerInhaled();
        }

        if (IsPlayerFarNear())
        {
            Gravity();
        }
    }

    public void OnPlayerInhaled()
    {
        ChangeColor();
        PlayerControll.instance.OnPlayerInhaled(this);
        Destroy(this);
    }

    void ChangeColor()
    {
        GetComponentInChildren<MeshRenderer>().material.color = ReflectLimit.instance.GetCurrentColor();
    }

    bool IsPlayerNear()
    {
        return Vector3.Distance(transform.position, GetTargetPos()) <= transform.localScale.y / 1.6f;
    }

    bool IsPlayerFarNear()
    {
        return Vector3.Distance(transform.position, GetTargetPos()) <= transform.localScale.y / 0.8f;
    }

    void Gravity()
    {
        Vector3 difference = GetTargetPos() - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion WantedRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);
        PlayerControll.instance.GetPlayerObject().transform.rotation = Quaternion.Lerp(PlayerControll.instance.GetPlayerObject().transform.rotation, WantedRotation, Time.deltaTime * 2);
    }

    Vector3 GetTargetPos()
    {
        return PlayerControll.instance.GetPlayerObject().transform.position;
    }
}
