using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public Card card;
    public List<QuestionCard> easyCardSet, mediumCardSet, hardCardSet;
    public List<ActionCard> actionCardSet;
    public List<CardSnippetTask> taskSet;

    void Start()
    {
        if (instance == null)  instance = this;

        FillEasyCardSet();
        FillMediumCardSet();
        FillHardCardSet();
        FillActionCardSet();
        FillTaskSet();

        GameObject.Find("CardStack").GetComponent<CardStack>().enabled = true;
    }

    #region private Methods
    private void FillEasyCardSet()
    {
        easyCardSet = new List<QuestionCard>();
        foreach (string s in FileReader.instance.easyCardFiles)
        {
            QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.EASY, FileReader.instance.FileToTex(s));
            easyCardSet.Add(c);
        }
    }
    private void FillMediumCardSet()
    {
        mediumCardSet = new List<QuestionCard>();
        foreach (string s in FileReader.instance.mediumCardFiles)
        {
            QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.MEDIUM, FileReader.instance.FileToTex(s));
            mediumCardSet.Add(c);
        }
    }
    private void FillHardCardSet()
    {
        hardCardSet = new List<QuestionCard>();
        foreach (string s in FileReader.instance.hardCardFiles)
        {
            QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.HARD, FileReader.instance.FileToTex(s));
            hardCardSet.Add(c);
        }
    }
    private void FillActionCardSet()
    {
        actionCardSet = new List<ActionCard>();
        foreach (string s in FileReader.instance.actionCardFiles)
        {
            ActionCard c = new ActionCard(SplitID(s), FileReader.instance.FileToTex(s));
            actionCardSet.Add(c);
        }
    }

    private void FillTaskSet()
    {
        taskSet = new List<CardSnippetTask>();
        foreach (string s in FileReader.instance.taskFiles) //Lädt erst die Karten 1, 10, 11, 12, 13, 14, 15 und anschließen 2-9 rein
        {
            CardSnippetTask snippet = new CardSnippetTask(SplitID(s), FileReader.instance.FileToTex(s));
            //Debug.Log("Snippet " + SplitID(s));
            taskSet.Add(snippet);
        }
    }

    private string SplitID(string s)
    {
        string[] tmp = s.Split('\\');
        return tmp[tmp.Length - 1];
    }
    #endregion
}
