using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerScreen : Screen
{
    public override void CloseScreen()
    {
        base.CloseScreen();
        ScreenCard.instance.EndTurn();
    }
}
