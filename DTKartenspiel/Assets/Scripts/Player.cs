using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerPoints = 0;
    public string playerName;
    public Team playerTeam;
    public GameObject cameraPointConnector;

    [HideInInspector] public int playerNumber;
    private GameObject camera;

    public void SetCamera()
    {
        camera = GameObject.Find("CustomCamera");
        GameObject cameraPoint = cameraPointConnector.transform.GetChild(playerNumber-1).gameObject;
        camera.transform.position = cameraPoint.transform.position;
        camera.transform.rotation = cameraPoint.transform.rotation;
    }

    /// <summary>
    /// set the points tp the player and also to his team
    /// </summary>
    public void SetPoints(int points)
    {
        playerPoints += points;
        playerTeam.teamPoints += points;
    }
}

public class CopyOfPlayer : MonoBehaviour
{
    public int playerPoints = 0;
    public string playerName;
    public Team playerTeam;
    public GameObject cameraPointConnector;

    [HideInInspector] public int playerNumber;
    private GameObject camera;

    public void SetCamera()
    {
        camera = GameObject.Find("CustomCamera");
        GameObject cameraPoint = cameraPointConnector.transform.GetChild(playerNumber - 1).gameObject;
        camera.transform.position = cameraPoint.transform.position;
        camera.transform.rotation = cameraPoint.transform.rotation;
    }

    /// <summary>
    /// set the points tp the player and also to his team
    /// </summary>
    public void SetPoints(int points)
    {
        playerPoints += points;
        playerTeam.teamPoints += points;
    }
}
