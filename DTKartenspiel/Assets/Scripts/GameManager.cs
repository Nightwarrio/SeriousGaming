using UnityEngine;

/// <summary>
/// This Script initialize the Teams and handles what happens in a new Turn.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Tooltip("The Points a Team needed to win the Game")] public int maxPoints = 500; 

    [HideInInspector] public Team team1, team2;
    [HideInInspector] public Player currentPlayer;

    /// <summary>
    /// Set true by the startScreen "OK"-Button
    /// Only if the gameInProgress a Card can be drawn.
    /// </summary>
    [HideInInspector] public bool gameInProgress; 

    void Start()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(gameObject);

        team1 = new Team(1);
        team2 = new Team(2);
    }

    /// <summary>
    /// Called when the Dice is thrown for the first Time.
    /// Select the StartetTeam and choose the currentPlayer.
    /// </summary>
    public void SelectStarterTeam()
    {
        int num = DiceCheckZoneScript.instance.diceNumber;
        int startingTeam;

        if(num % 2 == 0) //even number => team 1 starts
        {
            startingTeam = 1;
            currentPlayer = team1.teamMembers[0];
            team1.playerOneActive = true;
        }
        else
        {
            startingTeam = 2;
            currentPlayer = team2.teamMembers[0];
            team1.playerOneActive = true;
        }

        UI.instance.ShowStartScreen(startingTeam);
        SetCurrentPlayer();
    }
    
    /// <summary>
    /// Is called at the end on every Turn. Reactivate the CardStack, grow the UsedCards and choose the NextPlayerInOrder.
    /// </summary>
    public void NewTurn()
    {
        CardStack.instance.gameObject.SetActive(true); //CardStack was blocked during the Turn
        UsedCards.instance.Grow();
        NextPlayerInOrder();
    }

    /// <summary>
    /// Proofs if one Team reches the maxPoints.
    /// </summary>
    /// <returns>true, if one Team reaches the maxPoints</returns>
    //TODO: Wer ruft das auf? Wird EndGame() danach aufgerufen? ScreenCard oder?
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
    /// Called when the CardStack is empty or a Team reaches the maxPoints.
    /// </summary>
    public void EndGame()
    {
        gameInProgress = false;
        UI.instance.ShowWinScreen();
    }

    #region privatMethods
    /// <summary>
    /// Proofs if there is 1 vs 1 or 2 vs 2 and set the CurrentPlayer
    /// </summary>
    private void NextPlayerInOrder()
    {
        if (team1.teamMembers.Count == 1) //1 gegen 1
            NextPlayerInOrder_TwoPlayers();
        else if (team1.teamMembers.Count == 2) //2 gegen 2
            NextPlayerInOrder_FourPlayers();
        else
            Debug.Log("No valid player amount");

        SetCurrentPlayer();
    }

    private void NextPlayerInOrder_TwoPlayers()
    {
        if (currentPlayer.playerTeam.teamNumber == 1)
            currentPlayer = team2.teamMembers[0];

        else if (currentPlayer.playerTeam.teamNumber == 2)
            currentPlayer = team1.teamMembers[0];
    }

    private void NextPlayerInOrder_FourPlayers()
    {
        if (currentPlayer.playerTeam.teamNumber == 1) //next player should be from team2
        {
            if (team2.playerOneActive) //last Turn was member1 his Turn
            {
                currentPlayer = team2.teamMembers[1];
                team2.playerOneActive = false;
            }
            else 
            {
                currentPlayer = team2.teamMembers[0]; 
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
                currentPlayer = team1.teamMembers[0];
                team1.playerOneActive = true;
            }
        }
    }

    /// <summary>
    /// Update the UI display and set the CameraPosition.
    /// Called by NextPlayerInOrder
    /// </summary>
    private void SetCurrentPlayer()
    {
        UI.instance.SetCurrentPlayer(currentPlayer.playerName, currentPlayer.playerTeam.teamNumber);
        currentPlayer.SetCamera();
        UI.instance.ShowPlayerName(currentPlayer.playerName);
    }
    #endregion
}
