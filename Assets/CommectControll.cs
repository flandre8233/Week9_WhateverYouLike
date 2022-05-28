using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommectControll : SingletonMonoBehavior<CommectControll>
{
    [SerializeField] RectTransform CanvasRect;
    [SerializeField] GameObject SpawnPrefab;

    public void OnPlayerReflecting(int AddScore, Vector3 WorldPos)
    {
        Spawn(AddScore, WorldPos);
    }

    void Spawn(int AddScore, Vector3 WorldPos)
    {
        print(ScoreCounter.instance.GetComboVal());
        GameObject SpawnObject = Instantiate(SpawnPrefab, transform.parent);
        RectTransform SpawnRect = SpawnObject.GetComponent<RectTransform>();
        Destroy(SpawnObject, 5f);

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(WorldPos);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        SpawnRect.anchoredPosition = WorldObject_ScreenPosition;

        SpawnObject.GetComponent<CommectText>().ComboNumber = ScoreCounter.instance.GetComboVal();
        SpawnObject.GetComponent<CommectText>().Score = AddScore;
    }
}
