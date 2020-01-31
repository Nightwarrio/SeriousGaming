using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public GameObject team1PointsText, team2PointsText, winner;
    /// <summary>
    /// Initialize, so that the earned points shown up to the corresponding teams
    /// </summary>
    public void UpdateScreen()
    {
        int team1Points = GameManager.instance.team1.teamPoints;
        int team2Points = GameManager.instance.team2.teamPoints;

        team1PointsText.GetComponent<Text>().text = "Team 1: " + team1Points;
        team2PointsText.GetComponent<Text>().text = "Team 2: " + team2Points;

        if (team1Points > team2Points)
            winner.GetComponent<Text>().text = "Team 1 wins!!!";
        else if(team2Points > team1Points)
            winner.GetComponent<Text>().text = "Team 1 wins!!!";
        else
            winner.GetComponent<Text>().text = "Both team wins!!!";
    }
}
