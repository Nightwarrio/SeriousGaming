using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    // These are set in OnStartServer and used in OnStartClient
    [SyncVar]
    public int playerNo;
    public int playerTeam;
    public GameObject cameraPointConnector;

    void Start()
    {
        if (isLocalPlayer)
        {
            //Debug.Log(GetType().Name + " - Start() isLocalPlayer - " + gameObject.name);
        }
        else
        {
            // Network: Disable Components
            if (gameObject.transform.GetChild(1) != null)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }

            //Debug.Log(GetType().Name + " - Start() !isLocalPlayer - Disabled components - " + gameObject.name);
        }
    }

    // This fires on server when this player object is network-ready
    public override void OnStartServer()
    {
        base.OnStartServer();

        // Team Assignment
        playerNo = connectionToClient.connectionId;
        if (playerNo % 2 == 0)
        {
            playerTeam = 1;
        }
        else
        {
            playerTeam = 2;
        }
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
       
        // Player Camera
        GameObject cameraPoint = cameraPointConnector.transform.GetChild(playerNo).gameObject;
        gameObject.transform.GetChild(1).transform.position = cameraPoint.transform.position;
        gameObject.transform.GetChild(1).transform.rotation = cameraPoint.transform.rotation;
    }
}
