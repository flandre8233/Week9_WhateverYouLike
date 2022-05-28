using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        Speed = Random.Range(25, 25 + (10 * FloorControll.instance.GetCurrentFloor()));
        Speed *= Random.Range(0, 100) <= 50 ? -1 : 1;
    }

    [SerializeField] float Speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * Speed));
    }

    public void ChangeSpeed()
    {
        Speed *= -1;
    }
}
