using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the Score UI Element. Update the Score of the Teams and Handle the HealthBars.
/// </summary>
public class Score : MonoBehaviour
{
    public static Score instance;

    [Tooltip("The Team Scoreboards of the ScoreElement")] public GameObject team1, team2;
    [Tooltip("The ScoreBars of the Score Element")] public GameObject bar1, bar2;

    private void Start()
    {
        if (instance == null) instance = this;   
    }

    /// <summary>
    /// Called by the solutionPanel when all entrys and outputs are correct
    /// </summary>
    /// <param name="points">Amount of the Gates in this Task</param>
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

    /// <summary>
    /// Update the Team Scoreboards on the upper right Corner
    /// </summary>
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

    /// <summary>
    /// Updates the HealthBars of the Score
    /// </summary>
    /// <param name="team">The Team which HealthBar have to be updated</param>
    private void CalculateHealthBar(int team)
    {
        float barMultiplier = 1.0f / GameManager.instance.maxPoints;
        var standard = new Vector3(barMultiplier, 1f, 1f);
        int score = GameManager.instance.currentPlayer.playerTeam.teamPoints;

        if (team == 1)
        {
            var temp = bar1.transform.localScale;
            temp.x = standard.x * score;
            bar1.transform.localScale = temp;
        }
        else
        {
            var temp = bar2.transform.localScale;
            temp.x = standard.x * score;
            bar2.transform.localScale = temp;
        }
    }
}
