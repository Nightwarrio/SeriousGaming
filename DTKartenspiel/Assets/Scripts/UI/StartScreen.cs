using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject text;

    /// <summary>
    /// Set the text in the StartScreen
    /// </summary>
    public void SetTeamNumber(int teamNumber)
    {
        text.GetComponent<Text>().text = "Team " + teamNumber + " starts!";
    }

    /// <summary>
    /// called by pressing the "OK"-Button
    /// </summary>
    public void StartGame()
    {
        Debug.Log("Game is ready. CardStack can be pressed.");
        gameObject.SetActive(false);
        GameManager.instance.gameInProgress = true;
        //TODO:: Start music!
    }
}
