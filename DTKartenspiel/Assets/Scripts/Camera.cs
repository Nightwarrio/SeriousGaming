using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject[] cameraPoints = new GameObject[4];
    public GameObject cameraPointConnector;
    //array auff�llen
    // Start is called before the first frame update
    int players;
    void Start()
    {
        int i;
        for (i = 0; i < 4; i++)
        {
            cameraPoints[i] = cameraPointConnector.transform.GetChild(i).gameObject;
        }
        // player abh�ngig vom networking/ multiplayer abh�ngig
        // player einer zahl 0-3
        players = 3;
        gameObject.transform.position = cameraPoints[players].transform.position;
        gameObject.transform.rotation = cameraPoints[players].transform.rotation;
    }
}