using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : SingletonMonoBehavior<PlayerScale>
{
    public void OnPlayerReflecting()
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, transform.localScale.z * 1.25f);
    }
    public void ResetPlayerScale()
    {
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
