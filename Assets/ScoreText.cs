using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : CommonUIText
{
    [SerializeField]
    ScoreScale ScoreScale;

    [SerializeField]
    float CurrentScore = 0;
    [SerializeField]
    float WantedScore = 0;
    public override void UpdateText()
    {
        WantedScore = ScoreCounter.instance.Score;
        ScoreScale.AddScale();
    }

    private void Update()
    {
        CurrentScore = Mathf.Lerp(CurrentScore, WantedScore, Time.deltaTime * 7);
        text.text = ((int)CurrentScore).ToString();
    }
}
