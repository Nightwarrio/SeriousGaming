﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public GameObject team1, team2;

    private void Start()
    {
        if (instance == null) instance = this;   
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
            team1.GetComponent<Text>().text = "Team 1: " + GameManager.instance.currentPlayer.playerTeam.teamPoints;
        }
        else if (GameManager.instance.currentPlayer.playerTeam.teamNumber == 2) //Team 2
        {
            team2.GetComponent<Text>().text = "Team 2: " + GameManager.instance.currentPlayer.playerTeam.teamPoints;
        }
        else
            Debug.Log("There is no team!");
    }
}