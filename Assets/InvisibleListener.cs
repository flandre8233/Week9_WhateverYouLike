using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleListener : MonoBehaviour
{
    private void Update()
    {
        Vector3 PlayerViewPortPoint = Camera.main.WorldToViewportPoint(PlayerControll.instance.GetPlayerObject().transform.position);
        if (PlayerViewPortPoint.y > 1.5f || PlayerViewPortPoint.y < -0.2f)
        {
            PlayerControll.instance.OnPlayerLose();
        }

    }

}
