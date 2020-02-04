using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject player1, player2, player3, player4;
    public void StartTest()
    {
        player1 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player2 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player3 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player4 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        player1.transform.SetParent(gameObject.transform, true);
        player2.transform.SetParent(gameObject.transform, true);
        player3.transform.SetParent(gameObject.transform, true);
        player4.transform.SetParent(gameObject.transform, true);

        GameManager.instance.team1.teamMembers[0] = player1.GetComponent<Player>();
        GameManager.instance.team1.teamMembers[1] = player2.GetComponent<Player>();
        GameManager.instance.team2.teamMembers[0] = player3.GetComponent<Player>();
        GameManager.instance.team2.teamMembers[1] = player4.GetComponent<Player>();

        player1.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player2.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player3.GetComponent<Player>().playerTeam = GameManager.instance.team2;
        player4.GetComponent<Player>().playerTeam = GameManager.instance.team2;

        player1.GetComponent<Player>().playerName = "Player1";
        player2.GetComponent<Player>().playerName = "Player2";
        player3.GetComponent<Player>().playerName = "Player3";
        player4.GetComponent<Player>().playerName = "Player4";

        Debug.Log("Spieler wurden erstellt.");
    }
}
