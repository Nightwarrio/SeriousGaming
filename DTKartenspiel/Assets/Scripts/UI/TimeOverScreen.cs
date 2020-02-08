using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOverScreen : Screen
{
    public override void CloseScreen()
    {
        base.CloseScreen();
        ScreenCard.instance.EndTurn();
    }
}
