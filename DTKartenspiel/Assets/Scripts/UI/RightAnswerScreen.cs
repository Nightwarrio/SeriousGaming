using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightAnswerScreen : Screen
{
    public GameObject pointText;

    public override void CloseScreen()
    {
        base.CloseScreen();
        ScreenCard.instance.EndTurn();
    }

    public override void ShowScreen()
    {
        SetText();
        base.ShowScreen();
    }

    private void SetText()
    {
        pointText.GetComponent<Text>().text = "You earn " + GameCard.instance.points + " points!";
    }
}
