using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class Menu : MonoBehaviour
{

    #region Variablen
    public GameObject playerPrefab;
    public GameObject[] playerRegistrationField;

    [Header("Windows")]
    public GameObject unableToStart;
    public GameObject playerSelect;
    public GameObject startWindow;

    [Header("Player Names")]
    public GameObject inputText1;
    public GameObject inputText2;
    public GameObject inputText3;
    public GameObject inputText4;

    private int registerdPlayers = 0;
    private GameObject playerButton, cancelButton, currentPlayer, textField;
    private GameObject player1, player2, player3, player4;
    #endregion

    public void SelectPlayerWindow() 
    {
        startWindow.SetActive(false);
        playerSelect.SetActive(true);
    }

    public void PlayerWasSelected()
    {
        for (int i = 0; i < playerRegistrationField.Length; i++) 
        {
            var focusedObject = EventSystem.current.currentSelectedGameObject;
            var playerNumber = playerRegistrationField[i].name[playerRegistrationField[i].name.Length - 1];

            if (focusedObject.tag[focusedObject.tag.Length - 1].Equals(playerNumber))
            {
                currentPlayer = playerRegistrationField[i];

                playerButton = currentPlayer.transform.Find("PlayerButton").gameObject;
                cancelButton = currentPlayer.transform.Find("CancelButton").gameObject;
                textField = currentPlayer.transform.Find("InputField").GetChild(2).gameObject;

                if (playerButton.activeSelf)
                {
                    playerButton.SetActive(false);
                    cancelButton.SetActive(true);

                    InstantiatePlayer(playerNumber);
                    registerdPlayers += 1;
                }

                else if (cancelButton.activeSelf)
                {
                    cancelButton.SetActive(false);
                    playerButton.SetActive(true);

                    DestroyPlayer(playerNumber);
                    textField.GetComponent<Text>().text = " "; //TODO:: Not working
                    registerdPlayers -= 1;
                }

                break;
            }
        }
    }

    public void StartGameButton() 
    {
      if(registerdPlayers == 2 || registerdPlayers == 4) //es wird eine gerade Anzahl an Spielern benötigt
        SceneManager.LoadScene("Game");
      else
          unableToStart.SetActive(true);
    }

    public void UnableToStartButton()
    {
      unableToStart.SetActive(false);
    }

    #region private Methods
    private void InstantiatePlayer(char playerNumber)
    {
        switch (playerNumber)
        {
            case '1':
                InstantiatePlayer1();
                break;
            case '2':
                InstantiatePlayer2();
                break;
            case '3':
                InstantiatePlayer3();
                break;
            case '4':
                InstantiatePlayer4();
                break;
        }
    }

    private void InstantiatePlayer1()
    {
        player1 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player1.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team1.teamMembers.Add(player1.GetComponent<Player>());

        player1.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player1.GetComponent<Player>().playerName = inputText1.GetComponent<Text>().text;
        player1.GetComponent<Player>().playerNumber = 1;
    }

    private void InstantiatePlayer2()
    {
        player2 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player2.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team1.teamMembers.Add(player2.GetComponent<Player>());

        player2.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player2.GetComponent<Player>().playerName = inputText2.GetComponent<Text>().text;
        player2.GetComponent<Player>().playerNumber = 2;
    }

    private void InstantiatePlayer3()
    {
        player3 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player3.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team1.teamMembers.Add(player3.GetComponent<Player>());

        player3.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player3.GetComponent<Player>().playerName = inputText3.GetComponent<Text>().text;
        player3.GetComponent<Player>().playerNumber = 3;
    }

    private void InstantiatePlayer4()
    {
        player4 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player4.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team1.teamMembers.Add(player4.GetComponent<Player>());

        player4.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player4.GetComponent<Player>().playerName = inputText4.GetComponent<Text>().text;
        player4.GetComponent<Player>().playerNumber = 4;
    }

    private void DestroyPlayer(char playerNumber)
    {
        switch (playerNumber)
        {
            case '1':
                RemovePlayer1();
                break;
            case '2':
                RemovePlayer2();
                break;
            case '3':
                RemovePlayer3();
                break;
            case '4':
                RemovePlayer4();
                break;
        }
    }

    private void RemovePlayer1()
    {
        var player = player1.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        Destroy(player1.gameObject);
    }

    private void RemovePlayer2()
    {
        var player = player2.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        Destroy(player2.gameObject);
    }

    private void RemovePlayer3()
    {
        var player = player3.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        Destroy(player3.gameObject);
    }

    private void RemovePlayer4()
    {
        var player = player4.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        Destroy(player4.gameObject);
    }
    #endregion
}
