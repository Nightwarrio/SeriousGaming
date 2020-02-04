﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Reflection;

public class FileReader : MonoBehaviour
{
    public static FileReader instance;
    [HideInInspector] public string[] gatterSprites, easyCardFiles, mediumCardFiles, hardCardFiles, actionCardFiles, taskFiles;

    public Texture2D[] actionCards;
    public Texture2D[] taskSnippets;
    public Texture2D[] easyCards;
    public Texture2D[] mediumCards;
    public Texture2D[] hardCards;

    private string root;

    void Start()
    {
        if(instance == null) instance = this;
        UI.instance.SetCurrentPlayer(root, 1);
        root = Directory.GetCurrentDirectory();
        UI.instance.SetCurrentPlayer(root, 1);
        ReadGatterSprites();
        UI.instance.SetCurrentPlayer("FileReader: Cards loaded 1", 1);
        ReadEasyCardFiles();
        UI.instance.SetCurrentPlayer("FileReader: Cards loaded 2", 1);
        ReadMediumCardFiles();
        UI.instance.SetCurrentPlayer("FileReader: Cards loaded 3", 1);
        ReadHardCardFiles();
        UI.instance.SetCurrentPlayer("FileReader: Cards loaded 4", 1);
        ReadActionCardFiles();
        UI.instance.SetCurrentPlayer("FileReader: Cards loaded 5", 1);
        ReadTaskFiles();
        UI.instance.SetCurrentPlayer("FileReader: Cards loaded 6", 1);
        GameObject.Find("CardManager").GetComponent<CardManager>().enabled = true;
    }

    /// <summary>
    /// Compilea a file to an Texture2D
    /// </summary>
    /// <param name="s">the path where the file can be found</param>
    /// <returns>Texture2D of the file</returns>
    public Texture2D FileToTex(string s)
    {
        byte[] fileData = File.ReadAllBytes(s);
        Texture2D tex = new Texture2D(2, 2); //Die Werte hier sind egal
        tex.LoadImage(fileData); //passt die TexturGröße automatisch an
        return tex;
    }

    /// <summary>
    /// Compilea a file to an Sprite
    /// </summary>
    /// <param name="s">the path where the file can be found</param>
    /// <returns>Sprite of the file</returns>
    public Sprite FileToSprite(string s)
    {
        Texture2D tex = FileToTex(s);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        return sprite;
    }

    #region private Methods
    private void ReadEasyCardFiles()
    {
        easyCardFiles = Directory.GetFiles(root + "/Assets/QuestionCards/Easy");
        easyCardFiles = easyCardFiles.Where(s => !s.EndsWith("meta")).ToArray();
    }

    private void ReadMediumCardFiles()
    {
        mediumCardFiles = Directory.GetFiles(root + "/Assets/QuestionCards/Medium");
        mediumCardFiles = mediumCardFiles.Where(s => !s.EndsWith("meta")).ToArray();
    }

    private void ReadHardCardFiles()
    {
        hardCardFiles = Directory.GetFiles(root + "/Assets/QuestionCards/Hard");
        hardCardFiles = hardCardFiles.Where(s => !s.EndsWith("meta")).ToArray();
    }

    private void ReadActionCardFiles()
    {
        actionCardFiles = Directory.GetFiles(root + "/Assets/ActionCards");
        actionCardFiles = actionCardFiles.Where(s => !s.EndsWith("meta")).ToArray();
    }

    private void ReadTaskFiles()
    {
        taskFiles = Directory.GetFiles(root + "/Assets/ActionCards/Tasks");
        taskFiles = taskFiles.Where(s => !s.EndsWith("meta")).ToArray();
    }

    private void ReadGatterSprites()
    {
        gatterSprites = Directory.GetFiles(root + "/Assets/Materials/GatterSprites");
        gatterSprites = gatterSprites.Where(s => !s.EndsWith("meta")).ToArray();
    }
    #endregion 
}
