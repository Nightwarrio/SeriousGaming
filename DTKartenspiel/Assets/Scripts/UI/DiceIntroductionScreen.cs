using UnityEngine;

/// <summary>
/// Manages the DiceIntroductionScreen UI Element
/// </summary>
public class DiceIntroductionScreen : Screen
{
    [Tooltip("The Dice Game Object")] public GameObject dice;

    public override void CloseScreen()
    {
        base.CloseScreen();
        dice.SetActive(true);
    }
}
