using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : Screen
{
    public GameObject text;

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
