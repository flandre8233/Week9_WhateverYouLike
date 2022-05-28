using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorResultText : CommonUIText
{

    [SerializeField] float CurrentScoreView;
    [SerializeField] float TargetScore;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke("UpdateDelay", 1f);
        TargetScore = FloorControll.instance.GetCurrentFloor() - 3;
        UpdateText();
    }

    void UpdateDelay()
    {
        globalUpdateManager.instance.registerUpdateDg(UpdateScore);
    }

    public override void UpdateText()
    {
        text.text = "Floor : " + CurrentScoreView.ToString();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        CurrentScoreView = Mathf.Lerp(CurrentScoreView, TargetScore, Time.deltaTime * 3);
        if (CurrentScoreView / TargetScore >= 0.9f)
        {
            CurrentScoreView = TargetScore;
        }
        text.text = "Floor : " + ((int)CurrentScoreView).ToString();
    }

    private void OnDestroy()
    {
        globalUpdateManager.instance.UnregisterUpdateDg(UpdateScore);
    }
}
