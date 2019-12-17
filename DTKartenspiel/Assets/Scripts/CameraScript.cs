using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	GameObject[] cameraPoints = new GameObject[4];
	public GameObject cameraPointConnector;
	//array auffüllen
	// Start is called before the first frame update
	private int players;
	private int team;
	void Start()
	{
		int i;
		for (i = 0; i < 4; i++)
		{
			cameraPoints[i] = cameraPointConnector.transform.GetChild(i).gameObject;
		}
		// player abhängig vom networking/ multiplayer abhängig
		// player einer zahl 0-3
		players = 0;
		gameObject.transform.position = cameraPoints[players].transform.position;
		gameObject.transform.rotation = cameraPoints[players].transform.rotation;

		if (players == 0 || players == 1)
		{
			team = 0;
		}
		else {
			team = 1;
		}

	}
	public int getPlayerNumber()
	{
		return players;
	}
	public int getTeam() {
		return team;
	}
}