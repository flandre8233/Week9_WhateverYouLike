using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStatus : Status
{
    public override void Start()
    {
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StatusControll.ToNewStatus(new GameStatus());
        }
    }

    public override void ExitStatus()
    {
    }
}