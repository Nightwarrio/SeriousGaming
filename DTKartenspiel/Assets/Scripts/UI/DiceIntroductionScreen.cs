using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceIntroductionScreen : Screen
{
    public GameObject dice;

    public override void CloseScreen()
    {
        base.CloseScreen();
        dice.SetActive(true);
    }
}
