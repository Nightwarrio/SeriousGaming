using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerPoints = 0;
    public string playerName;
    public Team playerTeam;

    public int playerNo;
    public GameObject cameraPointConnector;

    void Start()
    {
        if (gameObject.transform.GetChild(1) != null)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    /*public override void OnStartLocalPlayer()
    {
       
        // Player Camera
        GameObject cameraPoint = cameraPointConnector.transform.GetChild(playerNo).gameObject;
        gameObject.transform.GetChild(1).transform.position = cameraPoint.transform.position;
        gameObject.transform.GetChild(1).transform.rotation = cameraPoint.transform.rotation;
    }*/

    /// <summary>
    /// set the points tp the player and also to his team
    /// </summary>
    /// <param name="points"></param>
    public void SetPoints(int points)
    {
        playerPoints += points;
        playerTeam.teamPoints += points;
    }
}
