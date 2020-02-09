using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOverScreen : Screen
{
    /// <summary>
    /// Closes the Window and the ScreenCard
    /// </summary>
    public override void CloseScreen()
    {
        base.CloseScreen();
        ScreenCard.instance.EndTurn();
    }
}
