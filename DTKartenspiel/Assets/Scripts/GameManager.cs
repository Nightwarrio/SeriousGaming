﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxPoints = 700; //TODO:: auf 500 senken?
    public GameObject playerPrefab;
    public GameObject startScreen;

    [HideInInspector] public Team team1, team2;
    [HideInInspector] public Player currentPlayer;
    [HideInInspector] public bool gameInProgress; //set by the startScreen "OK"-Button

    void Start()
    {
        if (instance == null) instance = this;

        team1 = new Team(1);
        team2 = new Team(2);

        gameObject.GetComponent<Test>().StartTest();
    }

    /// <summary>
    /// called when the dice is thrown for the first time
    /// </summary>
    public void SelectStarterTeam()
    {
        int num = DiceCheckZoneScript.instance.diceNumber;

        if(num % 2 == 0)
        {
            startScreen.GetComponent<StartScreen>().SetTeamNumber(1);
            currentPlayer = team1.teamMembers[0];
            team1.playerOneActive = true;
        }
        else
        {
            startScreen.GetComponent<StartScreen>().SetTeamNumber(2);
            currentPlayer = team2.teamMembers[0];
            team1.playerOneActive = true;
        }

        UI.instance.ShowStartScreen();
        UI.instance.SetCurrentPlayer(currentPlayer.playerName, currentPlayer.playerTeam.teamNumber);
    }
    
    /// <summary>
    /// is called at the end on every turn
    /// </summary>
    public void NewTurn()
    {
        Debug.Log("A new turn has started.");
        NextPlayerInOrder();
        UI.instance.SetCurrentPlayer(currentPlayer.playerName, currentPlayer.playerTeam.teamNumber);
    }

    /// <summary>
    /// set the next currentPlayer in order
    /// </summary>
    private void NextPlayerInOrder()
    {
        if (currentPlayer.playerTeam.teamNumber == 1) //next player should be from team2
        {
            if (team2.playerOneActive) //member 2 war zuletzt an der reihe
            {
                currentPlayer = team2.teamMembers[1];
                team2.playerOneActive = false;
            }
            else //member 1 war zuletzt an der reihe
            {
                currentPlayer = team2.teamMembers[1];
                team2.playerOneActive = true;
            }
        }

        else if (currentPlayer.playerTeam.teamNumber == 2) //next player should be from team1
        {
            if (team1.playerOneActive) 
            {
                currentPlayer = team1.teamMembers[1];
                team1.playerOneActive = false;
            }
            else 
            {
                currentPlayer = team1.teamMembers[1];
                team1.playerOneActive = true;
            }
        }
    }

    /// <summary>
    /// returns, if the game is finished by reaching the maxPoints
    /// Set gameInProgress = false, if the game is completed
    /// </summary>
    /// <returns>true, wenn das Spiel durch erreichen der maxPoints beendet wurde</returns>
    public bool GameFinishedRecord()
    {
        bool gameFinished = false;

        if (team1.teamPoints >= maxPoints || team2.teamPoints >= maxPoints)
        {
            gameFinished = true;
            gameInProgress = false;
        }
            
        return gameFinished;
    }

    /// <summary>
    /// called when the cardStack is empty
    /// </summary>
    public void EndGame()
    {
        gameInProgress = false;
        UI.instance.ShowWinScreen();
    }
}