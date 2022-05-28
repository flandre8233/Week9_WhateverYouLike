using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveLeftRight : MonoBehaviour
{
    [SerializeField]
    float TimeCounter;


    private void Start()
    {
        TimeCounter = Random.Range(0.01f, 0.99f);
    }

    // Update is called once per frame
    void Update()
    {
        float MapRadius = WallControll.instance.GetMapRadius();
        TimeCounter += Time.deltaTime * 0.5f;
        float WantedPosX = Mathf.Lerp(-MapRadius, +MapRadius, Mathf.PingPong(TimeCounter, 1) );

        transform.position = new Vector3(WantedPosX, transform.position.y, transform.position.z);
    }
}
