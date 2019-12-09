using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GatterEditorManager : MonoBehaviour
{
    public static GatterEditorManager instance;

    private void Start()
    {
        if(instance == null) instance = this;
    }

    public void BackToGame()
    {
        gameObject.SetActive(false);
    }
}
