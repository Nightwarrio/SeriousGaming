using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class manages the RightAnswerScreen UI Element
/// </summary>
public class RightAnswerScreen : Screen
{
    [Tooltip("The UI Text Element of this Screen")] public GameObject pointText;

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
