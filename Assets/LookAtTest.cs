using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour
{
    [SerializeField]
    Transform Target1;

    [SerializeField]
    Transform Target2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Target1.position - Target2.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Quaternion WantedRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);
        Target1.rotation = Quaternion.Lerp(Target1.rotation, WantedRotation, Time.deltaTime * 20);
    }
}
