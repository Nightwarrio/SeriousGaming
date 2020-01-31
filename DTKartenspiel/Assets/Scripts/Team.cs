using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team 
{
    public int teamPoints = 0;
    public int teamNumber; //Can be 1 or 2 (only two teams allowed)
    public Player[] teamMembers;

    public bool playerOneActive; //helps to set an order. If PlayerOne is not active, now it is his turn

    public Team(int teamNumber)
    {
        this.teamNumber = teamNumber;
        teamMembers = new Player[2];
        playerOneActive = false;
    }
}
