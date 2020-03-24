using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// Manages what happenings in the StartMenu Scene
/// </summary>
public class Menu : MonoBehaviour
{

    #region Variablen
    [Tooltip("The Prefab of a Player")] public GameObject playerPrefab;
    [Tooltip("The PlayerWindows")] public GameObject[] playerRegistrationField;

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
    private GameObject playerButton, cancelButton, currentPlayer;
    private GameObject player1, player2, player3, player4;
    #endregion

    public void SelectPlayerWindow() 
    {
        startWindow.SetActive(false);
        playerSelect.SetActive(true);
    }

    /// <summary>
    /// Check which PlayerField was selected. Instantiate or Destroy the Player. 
    /// </summary>
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

                if (playerButton.activeInHierarchy)
                {
                    playerButton.SetActive(false);
                    cancelButton.SetActive(true);

                    if (InstantiatePlayer(playerNumber))
                    {
                        registerdPlayers += 1;
                    }
                    else
                    {
                        playerButton.SetActive(true);
                        cancelButton.SetActive(false);
                    }
                }

                else if (cancelButton.activeInHierarchy)
                {
                    cancelButton.SetActive(false);
                    playerButton.SetActive(true);

                    DestroyPlayer(playerNumber);
                    registerdPlayers -= 1;
                } 
                break;
            }
        }
    }

    /// <summary>
    /// Check if the required Amount of Players are registered.
    /// In case of two Players, they have to be in differnt Teams.
    /// </summary>
    public void StartGameButton()
    { 
        if ((registerdPlayers == 2 || registerdPlayers == 4) &&
            GameManager.instance.team1.teamMembers.Count != 0 && GameManager.instance.team2.teamMembers.Count != 0) 
                SceneManager.LoadScene("Game");
        else
            unableToStart.SetActive(true);
    }

    public void UnableToStartButton()
    {
      unableToStart.SetActive(false);
    }

    #region private Methods

    /// <summary>
    /// Check which Player have to be instantiate.
    /// </summary>
    /// <param name="playerNumber">The PlayerNumber</param>
    private bool InstantiatePlayer(char playerNumber)
    {
        switch (playerNumber)
        {
            case '1':
                return InstantiatePlayer1();
            case '2':
                return InstantiatePlayer2();
            case '3':
                return InstantiatePlayer3();
            case '4':
                return InstantiatePlayer4();
        }
        return false;
    }

    private bool InstantiatePlayer1()
    {
        if (inputText1.GetComponent<Text>().text.Equals("")) //No name entered
        {
            return false;
        }

        player1 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player1.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team1.teamMembers.Add(player1.GetComponent<Player>());

        player1.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player1.GetComponent<Player>().playerName = inputText1.GetComponent<Text>().text;
        player1.GetComponent<Player>().playerNumber = 1;

        return true;
    }

    private bool InstantiatePlayer2()
    {
        if (inputText2.GetComponent<Text>().text.Equals("")) //No name entered
        {
            return false;
        }

        player2 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player2.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team1.teamMembers.Add(player2.GetComponent<Player>());

        player2.GetComponent<Player>().playerTeam = GameManager.instance.team1;
        player2.GetComponent<Player>().playerName = inputText2.GetComponent<Text>().text;
        player2.GetComponent<Player>().playerNumber = 2;

        return true;
    }

    private bool InstantiatePlayer3()
    {
        if (inputText3.GetComponent<Text>().text.Equals("")) //No name entered
        {
            return false;
        }

        player3 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player3.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team2.teamMembers.Add(player3.GetComponent<Player>());

        player3.GetComponent<Player>().playerTeam = GameManager.instance.team2;
        player3.GetComponent<Player>().playerName = inputText3.GetComponent<Text>().text;
        player3.GetComponent<Player>().playerNumber = 3;

        return true;
    }

    private bool InstantiatePlayer4()
    {
        if (inputText4.GetComponent<Text>().text.Equals("")) //No name entered
        {
            return false;
        }

        player4 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player4.transform.SetParent(gameObject.transform, true);
        GameManager.instance.team2.teamMembers.Add(player4.GetComponent<Player>());

        player4.GetComponent<Player>().playerTeam = GameManager.instance.team2;
        player4.GetComponent<Player>().playerName = inputText4.GetComponent<Text>().text;
        player4.GetComponent<Player>().playerNumber = 4;

        return true;
    }

    /// <summary>
    /// Check which Player have to be destroyed.
    /// </summary>
    /// <param name="playerNumber">The PlayerNumber</param>
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
        inputText1.GetComponent<Text>().text = "";
        Destroy(player1.gameObject);
    }

    private void RemovePlayer2()
    {
        var player = player2.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        inputText2.GetComponent<Text>().text = "";
        Destroy(player2.gameObject);
    }

    private void RemovePlayer3()
    {
        var player = player3.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        inputText3.GetComponent<Text>().text = "";
        Destroy(player3.gameObject);
    }

    private void RemovePlayer4()
    {
        var player = player4.GetComponent<Player>();
        player.playerTeam.teamMembers.Remove(player);
        inputText4.GetComponent<Text>().text = "";
        Destroy(player4.gameObject);
    }
    #endregion
}