using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCollider : MonoBehaviour
{

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, (9.8f * Time.deltaTime));
        if (hit)
        {
            GetComponent<ReflectLimit>().OnPlayerReflect(ReflectPointControll.instance.GetDisantce(transform.position));
            ReflectPointControll.instance.UpdateReflectPoint(transform.position);
            ReBoundWall(hit);
            CameraShake.shakeAmount += 0.2f;
            CameraShake.shakeDuration += 0.15f;
        }
    }

    void ReBoundWall(RaycastHit2D hit)
    {
        Vector2 reflectedPosition = Vector2.Reflect(transform.up, hit.normal);
        Vector2 dir = (reflectedPosition).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle - 90f);
    }

}
