using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverridedRotate : MonoBehaviour
{
    Transform PlayerTran;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTran = PlayerControll.instance.GetPlayerObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTran.eulerAngles.z > 90 && PlayerTran.eulerAngles.z < 180)
        {
            GetComponent<SimpleRotate>().ChangeSpeed();
            PlayerTran.eulerAngles = new Vector3(0, 0, 90);
        }

        if (PlayerTran.eulerAngles.z < 270 && PlayerTran.eulerAngles.z > 180)
        {
            GetComponent<SimpleRotate>().ChangeSpeed();
            PlayerTran.eulerAngles = new Vector3(0, 0, 270);
        }


    }
}
