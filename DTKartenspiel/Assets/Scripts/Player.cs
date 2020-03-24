using UnityEngine;

/// <summary>
/// This Class represents a Player. 
/// </summary>
public class Player : MonoBehaviour
{
    public int playerPoints = 0;
    public string playerName;
    public Team playerTeam;

    [Tooltip("Custom CameraPerspektive for this Player")] public GameObject cameraPointConnector;

    /// <summary>
    /// The Number of the Player. This can be 1, 2, 3 or 4.
    /// </summary>
    [HideInInspector] public int playerNumber;

    /// <summary>
    /// Set the Camera to the Position of the Player. Called in each NewTurn
    /// </summary>
    public void SetCamera()
    {
        GameObject camera = GameObject.Find("CustomCamera");
        GameObject cameraPoint = cameraPointConnector.transform.GetChild(playerNumber-1).gameObject;
        camera.transform.position = cameraPoint.transform.position;
        camera.transform.rotation = cameraPoint.transform.rotation;
    }

    /// <summary>
    /// Set the Points to the Player and to his Team
    /// </summary>
    /// <param name="points">The earned Points</param>
    public void SetPoints(int points)
    {
        playerPoints += points;
        playerTeam.teamPoints += points;
    }
}
