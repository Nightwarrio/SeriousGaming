using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manges the StartScreen UI Element
/// </summary>
public class StartScreen : Screen
{
    [Tooltip("The Text Element of this Screen")] public GameObject text;

    private int teamNumber;
    public int TeamNumber { set { teamNumber = value; } }

    public override void CloseScreen()
    {
        base.CloseScreen();
        GameManager.instance.gameInProgress = true;
        AudioManager.instance.PlayBackgroundMusic();
    }

    public override void ShowScreen()
    {
        SetTeamNumber();
        base.ShowScreen();
    }

    /// <summary>
    /// Set the text in the StartScreen
    /// </summary>
    private void SetTeamNumber()
    {
        text.GetComponent<Text>().text = "Team " + teamNumber + " starts!";
    }
}
