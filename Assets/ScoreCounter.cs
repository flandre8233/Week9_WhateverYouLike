using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : SingletonMonoBehavior<ScoreCounter>
{
    public int Score;
    [SerializeField] ReflectLimit reflectLimit;

    [SerializeField] CommonUIText ScoreUI;
    [SerializeField] CommonUIText ComboUI;

    public int GetComboVal()
    {
        return reflectLimit.GetReflectTime() + 1;
    }

    public void OnPlayerGetScore(int AddScore, Vector3 AddScorePosition)
    {

        print("OnPlayerGetScore : " + GetComboVal());
        AddScore = (int)(AddScore * GetComboVal() * (1 + ((float)FloorControll.instance.GetCurrentFloor() / 10)));
        Score += AddScore;

        ScoreUI.UpdateText();
        ComboUI.UpdateText();
        CommectControll.instance.OnPlayerReflecting(AddScore, AddScorePosition);
    }

}
