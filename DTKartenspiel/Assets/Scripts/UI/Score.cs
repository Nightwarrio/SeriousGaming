using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public GameObject team1, team2;
    public GameObject bar1, bar2;

    private void Start()
    {
        if (instance == null) instance = this;   
    }

    /// <summary>
    /// Called by the solutionPanel when all entrys and outputs are correct
    /// </summary>
    /// <param name="points">is the amount of the gates in this task</param>
    public void SetExtraPoints(int points)
    {
        GameManager.instance.currentPlayer.SetPoints(points);
        UpdateScoreBoard();
    }

    /// <summary>
    /// Called when a Gate is correct placed in the GateEditor. 
    /// Set the points to the right player and his team.
    /// </summary>
    public void SetPointsRightGate()
    {
        GameManager.instance.currentPlayer.SetPoints(5);
        UpdateScoreBoard();
    }

    /// <summary>
    /// Called when a QuestionCard is correct answered. 
    /// Set the points to the right player and his team.
    /// </summary>
    public void SetPointsRightAnswer()
    {
        int earnedPoints = GameCard.instance.points;
        GameManager.instance.currentPlayer.SetPoints(earnedPoints);
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        if (GameManager.instance.currentPlayer.playerTeam.teamNumber == 1) //Team 1
        {
            team1.GetComponent<Text>().text = "Team 1: " + 
                GameManager.instance.currentPlayer.playerTeam.teamPoints;
            CalculateHealthBar(1);
        }
        else if (GameManager.instance.currentPlayer.playerTeam.teamNumber == 2) //Team 2
        {
            team2.GetComponent<Text>().text = "Team 2: " + 
                GameManager.instance.currentPlayer.playerTeam.teamPoints;
            CalculateHealthBar(2);
        }
        else
            Debug.Log("There is no team!");
    }

    private void CalculateHealthBar(int team)
    {
        float barMultiplier = 1 / (GameManager.instance.maxPoints / 100);
        var scaleBarVec = new Vector3(barMultiplier, 0f, 0f);
        int score = GameManager.instance.currentPlayer.playerTeam.teamPoints;

        if (team == 1)
        {
            bar1.gameObject.transform.localScale = new Vector3(0f, 1f, 1f);
            bar1.gameObject.transform.localScale += (scaleBarVec * score);
        }
        else
        {
            bar2.gameObject.transform.localScale = new Vector3(0f, 1f, 1f); 
            bar2.gameObject.transform.localScale += (scaleBarVec * score);
        }
    }
}
