using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GatterEditorManager : MonoBehaviour
{
    public static GatterEditorManager instance;
    public GameObject gratulationPanel, chooseEntry;

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
}
