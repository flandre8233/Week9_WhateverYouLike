using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectLimit : SingletonMonoBehavior<ReflectLimit>
{
    [SerializeField] int MaxReflect;
    [SerializeField] int ReflectTime = 0;

    [SerializeField] MeshRenderer ViewRenderer;


    private void Start()
    {
        UpdateColorView();
    }

    public void OnPlayerReflect(float ReflectDistance)
    {
        ReflectTime++;
        if (IsOverLimit())
        {
            print("IsOverLimit");
            ResourcesSpawner.Spawn("Explosion", transform.position, 3f);
            PlayerControll.instance.OnPlayerLose();
        }
        UpdateColorView();
        print("ReflectDistance : " + ReflectDistance);
        ReflectSoundSpawner.Spawn();
        PlayerScale.instance.OnPlayerReflecting();
        ScoreCounter.instance.OnPlayerGetScore((int)ReflectDistance, transform.position);
    }

    bool IsOverLimit()
    {
        return ReflectTime > MaxReflect;
    }
    public void OnPlayerLand(GameObject Cube)
    {
        ReflectTime = 0;
        UpdateColorView();
    }

    void UpdateColorView()
    {
        ViewRenderer.material.color = GetCurrentColor();
    }

    public int GetReflectTime()
    {
        return ReflectTime;
    }

    public Color GetCurrentColor()
    {
        return GetColor(ReflectTime);
    }

    public Color GetColor(int ColorIndex)
    {
        float CurLerpT = (float)ColorIndex / (float)MaxReflect;
        Color NewColor = Color.Lerp(Color.cyan, Color.red, CurLerpT);
        return NewColor;
    }
}
