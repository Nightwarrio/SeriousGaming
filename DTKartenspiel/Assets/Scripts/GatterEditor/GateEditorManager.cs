using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GateEditorManager : MonoBehaviour
{
<<<<<<< HEAD:DTKartenspiel/Assets/Scripts/GatterEditor/GateEditorManager.cs
    public static GateEditorManager instance;
=======
    public static GatterEditorManager instance;
>>>>>>> 9978b265ef41a933eab6427ff41f7a0913265f3e:DTKartenspiel/Assets/Scripts/GatterEditor/GatterEditorManager.cs
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
    /// </summary>
    /// <param name="placeToSpwan">The right positioned gatter</param>
    public void ShowPoints(GameObject placeToSpwan)
    {
        var tmp = Instantiate(pointsNumber, placeToSpwan.transform.position, placeToSpwan.transform.rotation);
        tmp.transform.SetParent(placeToSpwan.transform);
        UIObject.GetComponent<UI>().gatterPoints();
    }

    /// <summary>
    /// is shown when a not correct placed gatter has dropped
    /// </summary>
    public void ShowFalse(GameObject placeToSpawn)
    {
        var tmp = Instantiate(falsePanel, placeToSpawn.transform.position, placeToSpawn.transform.rotation);
        tmp.transform.SetParent(placeToSpawn.transform);
        UIObject.GetComponent<UI>().removePoints();
    }

}
