using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : SingletonMonoBehavior<PlayerControll>
{
    [SerializeField]
    GameObject PlayerObject;
    [SerializeField]
    GameObject Arrow;
    [SerializeField]
    SimpleForward PlayerForward;
    [SerializeField] ComboText comboText;
    bool OnLand = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            if (OnLand)
            {
                OnPlayerClickMove();
            }
        }
    }

    public void OnPlayerLose()
    {
        StatusControll.ToNewStatus(new GameoverStatus());
        Destroy(PlayerObject.gameObject);
    }

    void OnPlayerClickMove()
    {
        GetPlayerObject().AddComponent<ReflectWall>();
        ReflectPointControll.instance.UpdateReflectPoint(GetPlayerObject().transform.position);
        OnLand = false;
        CubeControll.instance.ClearFirst();
        PlayerObject.transform.parent = null;
        PlayerForward.enabled = true;
        Arrow.gameObject.SetActive(false);
        StartColliderListen();
        comboText.UpdateText();
    }

    public void OnPlayerInhaled(Suction Who)
    {
        Destroy(GetPlayerObject().GetComponent<ReflectWall>());
        OnLand = true;
        ReflectSoundSpawner.Spawn();
        PlayerScale.instance.ResetPlayerScale();
        ScoreCounter.instance.OnPlayerGetScore(50, GetPlayerObject().transform.position);
        PlayerObject.GetComponent<ReflectLimit>().OnPlayerLand(Who.gameObject);
        Who.gameObject.AddComponent<PlayerOverridedRotate>();
        CubeControll.instance.OnPlayerLand(Who.gameObject);
        BlockControll.instance.OnPlayerLand(Who.gameObject);
        PlayerObject.transform.parent = Who.transform;
        PlayerForward.enabled = false;

        CameraShake.shakeAmount += 0.3f;
        CameraShake.shakeDuration += 0.04f;

        Arrow.gameObject.SetActive(true);
        CloseColliderListen();
    }

    public GameObject GetPlayerObject()
    {
        return PlayerObject;
    }

    void StartColliderListen()
    {
        GetPlayerObject().AddComponent<ReflectCollider>();
    }

    void CloseColliderListen()
    {
        Destroy(GetPlayerObject().GetComponent<ReflectCollider>());
    }
}
