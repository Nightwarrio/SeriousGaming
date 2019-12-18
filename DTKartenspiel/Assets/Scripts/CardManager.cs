using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public Card card;
    Texture2D tex = null;
    byte[] fileData;
    String[] easyCardFiles, mediumCardFiles, hardCardFiles, actionCardFiles, taskFiles;
    public List<QuestionCard> easyCardSet, mediumCardSet, hardCardSet;
    public List<ActionCard> actionCardSet;
    public List<CardSnippetTask> taskSet;

    void Start()
    {
        if (instance == null)  instance = this;

        LoadCards();
        GameObject.Find("CardStack").GetComponent<CardStack>().enabled = true;
    }

    #region private Methods
    private void LoadCards()
    {
        String root = Directory.GetCurrentDirectory();
        easyCardFiles = Directory.GetFiles(root + "/Assets/QuestionCards/Easy");
        mediumCardFiles = Directory.GetFiles(root + "/Assets/QuestionCards/Medium");
        hardCardFiles = Directory.GetFiles(root + "/Assets/QuestionCards/Hard");
        actionCardFiles = Directory.GetFiles(root + "/Assets/ActionCards");
        taskFiles = Directory.GetFiles(root + "/Assets/ActionCards/Tasks");

        FillEasyCardSet();
        FillMediumCardSet();
        FillHardCardSet();
        FillActionCardSet();
        FillTaskSet();
    }
    private void FileToTex(string s)
    {
        fileData = File.ReadAllBytes(s);
        tex = new Texture2D(2, 2); //Die Werte hier sind egal
        tex.LoadImage(fileData); //passt die TexturGröße automatisch an
    }

    private void FillEasyCardSet()
    {
        easyCardSet = new List<QuestionCard>();

        foreach (string s in easyCardFiles)
        {
            if (!s.EndsWith("meta"))
            {
                FileToTex(s);
                QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.EASY, tex);
                easyCardSet.Add(c);
                tex = null;
            }
        }
    }
    private void FillMediumCardSet()
    {
        mediumCardSet = new List<QuestionCard>();
        foreach (string s in mediumCardFiles)
        {
            if (!s.EndsWith("meta"))
            {
                FileToTex(s);
                QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.MEDIUM, tex);
                mediumCardSet.Add(c);
                tex = null;
            }
        }
    }
    private void FillHardCardSet()
    {
        hardCardSet = new List<QuestionCard>();
        foreach (string s in hardCardFiles)
        {
            if (!s.EndsWith("meta"))
            {
                FileToTex(s);
                QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.HARD, tex);
                hardCardSet.Add(c);
                tex = null;
            }
        }
    }
    private void FillActionCardSet()
    {
        actionCardSet = new List<ActionCard>();
        foreach (string s in actionCardFiles)
        {
            if (!s.EndsWith("meta"))
            {
                FileToTex(s);
                ActionCard c = new ActionCard(SplitID(s), tex);
                actionCardSet.Add(c);
                tex = null;
            }
        }
    }

    private void FillTaskSet()
    {
        taskSet = new List<CardSnippetTask>();
        foreach (string s in taskFiles) //Lädt erst die Karten 1, 10, 11, 12, 13, 14, 15 und anschließen 2-9 rein
        {
            if (!s.EndsWith("meta"))
            {
                FileToTex(s);
                CardSnippetTask snippet = new CardSnippetTask(SplitID(s), tex);
                //Debug.Log("Snippet " + SplitID(s));
                taskSet.Add(snippet);
                tex = null;
            }
        }
    }

    private string SplitID(string s)
    {
        string[] tmp = s.Split('\\');
        return tmp[tmp.Length - 1];
    }
    #endregion
}
