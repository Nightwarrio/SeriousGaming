using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GateEditorManager : MonoBehaviour
{
    public static GateEditorManager instance;
    public GameObject gratulationPanel, chooseEntry, solutionPanel, falsePanel, UIObject, points;
    public FadingObject pointsNumber;

    private void Start()
    {
        if(instance == null) instance = this;
    }

    /// <summary>
    /// Caled by gratulationPanel
    /// Close and Clear all used Panels and go Back to Game. Play the background music.
    /// </summary>
    public void BackToGame()
    {
        gameObject.SetActive(false);
        gratulationPanel.SetActive(false);
        chooseEntry.SetActive(false);

        CraftingPanel.instance.ClearPanel();
        points.GetComponent<Points>().Reset();

        ScreenCard.instance.EndTurn();
        AudioManager.instance.PlayBackgroundMusic();
    }

    /// <summary>
    /// if a gatter is right positioned, the paceholder call this method.
    /// The Points shown up and will be set on the scoreboard
    /// </summary>
    /// <param name="playeToSpawn">The right positioned gatter</param>
    public void ShowPoints(GameObject playeToSpawn)
    {
        var tmp = Instantiate(pointsNumber, playeToSpawn.transform.position, playeToSpawn.transform.rotation);
        tmp.transform.SetParent(playeToSpawn.transform);
        points.GetComponent<Points>().SetText();
        Score.instance.SetPointsRightGate();
    }

    /// <summary>
    /// is shown when a not correct placed gatter has dropped
    /// </summary>
    public void ShowFalse(GameObject placeToSpawn)
    {
        var tmp = Instantiate(falsePanel, placeToSpawn.transform.position, placeToSpawn.transform.rotation);
        tmp.transform.SetParent(placeToSpawn.transform);
    }

    /// <summary>
    /// set the gateEditor active and play the music
    /// </summary>
    public void ShowUp()
    {
        gameObject.SetActive(true);
        AudioManager.instance.PlayGateEditorMusic();
    }
}
