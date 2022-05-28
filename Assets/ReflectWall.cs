using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectWall : MonoBehaviour
{


    private void Update()
    {
        if (IsTouchWall())
        {

            GetComponent<ReflectLimit>().OnPlayerReflect(ReflectPointControll.instance.GetDisantce(transform.position));
            ReflectPointControll.instance.UpdateReflectPoint(transform.position);
            ReBoundWall();
            CameraShake.shakeAmount += 0.2f;
            CameraShake.shakeDuration += 0.15f;
        }
    }

    void ReBoundWall()
    {
        Vector2 reflectedPosition = Vector2.Reflect(transform.up, new Vector2(IsTouchRightWall() ? -1 : 1, 0));
        Vector2 dir = (reflectedPosition).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle - 90f);
    }

    bool IsTouchRightWall()
    {
        return (transform.position.x >= WallControll.instance.GetMapRadius());
    }

    bool IsTouchWall()
    {
        return (IsTouchRightWall() || transform.position.x <= -WallControll.instance.GetMapRadius());
    }

}