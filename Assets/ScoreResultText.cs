using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreResultText : CommonUIText
{

    [SerializeField] float CurrentScoreView;
    [SerializeField] float TargetScore;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke("UpdateDelay", 1f);
        TargetScore = ScoreCounter.instance.Score;
        UpdateText();
    }

    void UpdateDelay()
    {
        globalUpdateManager.instance.registerUpdateDg(UpdateScore);
    }

    public override void UpdateText()
    {
        text.text = "Score : " + CurrentScoreView.ToString();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        CurrentScoreView =Mathf.Lerp(CurrentScoreView, TargetScore, Time.deltaTime * 3);
     
         if (CurrentScoreView / TargetScore >= 0.9f)
        {
            CurrentScoreView = TargetScore;
        }
        text.text = "Score : " +  ((int)CurrentScoreView).ToString();
    }

    private void OnDestroy()
    {
        globalUpdateManager.instance.UnregisterUpdateDg(UpdateScore);
    }
}
