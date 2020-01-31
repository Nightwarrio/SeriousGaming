using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GateEditorManager : MonoBehaviour
{
    public static GateEditorManager instance;
    public GameObject gratulationPanel, chooseEntry, solutionPanel, falsePanel, UIObject;
    public PointsNumber pointsNumber;

    private void Start()
    {
        if(instance == null) instance = this;
    }

    /// <summary>
    /// Close and Clear all used Panels and go Back to Game
    /// </summary>
    public void BackToGame()
    {
        gameObject.SetActive(false);
        gratulationPanel.SetActive(false);
        chooseEntry.SetActive(false);
        CraftingPanel.instance.ClearPanel();
    }

    /// <summary>
    /// if a gatter is right positioned, the paceholder call this method.
    /// The Points shown up and will be set on the scoreboard
    /// </summary>
    /// <param name="placeToSpwan">The right positioned gatter</param>
    public void ShowPoints(GameObject placeToSpwan)
    {
        var tmp = Instantiate(pointsNumber, placeToSpwan.transform.position, placeToSpwan.transform.rotation);
        tmp.transform.SetParent(placeToSpwan.transform);
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
    /// set the gateEditor active
    /// </summary>
    public void ShowUp()
    {
        gameObject.SetActive(true);
    }
}
