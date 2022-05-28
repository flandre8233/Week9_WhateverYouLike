using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestoryer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }


}
