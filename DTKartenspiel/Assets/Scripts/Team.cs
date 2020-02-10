using System.Collections.Generic;

/// <summary>
/// This Class represents the Team for a Player. There are two Teams in the Game. The GameManager initialize the Teams.
/// </summary>
public class Team 
{
    public int teamPoints;
    public List<Player> teamMembers;

    /// <summary>
    /// This can be 1 or 2 (only two Teams allowed)
    /// </summary>
    public int teamNumber; 

    /// <summary>
    /// Helps to set an Order. If PlayerOne is not active, now it is his Turn.
    /// </summary>
    public bool playerOneActive; 

    public Team(int teamNumber)
    {
        this.teamNumber = teamNumber;
        teamMembers = new List<Player>();
        teamPoints = 0;
        playerOneActive = false;
    }
}