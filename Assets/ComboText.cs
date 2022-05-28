using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboText : CommonUIText
{
    [SerializeField] ReflectLimit ReflectLimit;
    [SerializeField] ComboScale comboScale;
    [SerializeField] ComboAlpha comboAlpha;
    public override void UpdateText()
    {
        text.text = ScoreCounter.instance.GetComboVal() + "x";
        text.color = ReflectLimit.GetCurrentColor();
        comboScale.AddScale();
        comboAlpha.RecoverAlpha();
    }


}
