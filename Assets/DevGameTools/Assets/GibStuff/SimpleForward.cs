using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleForward : MonoBehaviour
{
    [SerializeField] float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -WallControll.instance.GetMapRadius(), WallControll.instance.GetMapRadius()), transform.position.y, transform.position.z);
    }
}
