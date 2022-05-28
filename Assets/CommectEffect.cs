using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommectEffect : MonoBehaviour
{
    float XForce;
    float Force;
    RectTransform Rect;
    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        Force = Random.Range(90, 120) * -1;
        Rect CommectRect = RectTransformToScreenSpace(Rect);
        Vector2 ViewPort = Camera.main.ScreenToViewportPoint(new Vector3(CommectRect.x, CommectRect.y, 0));
        XForce = (ViewPort.x <= 0 ? -200 : +200 );
    }

    // Update is called once per frame
    void Update()
    {
        Force += 9.8f * 1.35f;
        Vector2 WantedPos = new Vector2(Rect.anchoredPosition.x - (XForce*Time.deltaTime), Rect.anchoredPosition.y - (Force * Time.deltaTime));
        Rect.anchoredPosition = WantedPos;
    }

    public static Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
        return new Rect((Vector2)transform.position - (size * 0.5f), size);
    }
}
