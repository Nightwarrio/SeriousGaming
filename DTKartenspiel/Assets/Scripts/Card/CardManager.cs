using System.Collections.Generic;
using UnityEngine;

public class CardManager :  MonoBehaviour
{
    public static CardManager instance;
    public Card card;
    public GameObject cardStack;
    public List<QuestionCard> easyCardSet, mediumCardSet, hardCardSet;
    public List<ActionCard> actionCardSet;
    public List<CardSnippetTask> taskSet;

    public Texture2D[] actionCards;
    public Texture2D[] taskSnippets;
    public Texture2D[] easyCards;
    public Texture2D[] mediumCards;
    public Texture2D[] hardCards;
    public Texture2D[] gatterSprites;


    public Sprite TexToSprite(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        return sprite;
    }

    void Start()
    {
        if (instance == null)  instance = this;
        FillEasyCardSet();
        FillMediumCardSet();
        FillHardCardSet();
        FillActionCardSet();
        FillTaskSet();
        //UI.instance.SetCurrentPlayer("CardManager: Cards ready!", 1);
        //GameObject.Find("CardStack").GetComponent<CardStack>().enabled = true;
        cardStack.GetComponent<CardStack>().enabled = true;
    }

    #region private Methods
    private void FillEasyCardSet()
    {
        easyCardSet = new List<QuestionCard>();
        /*foreach (string s in FileReader.instance.easyCardFiles)
        {
            QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.EASY, FileReader.instance.FileToTex(s));
            easyCardSet.Add(c);
        }*/
        foreach (Texture2D tex in easyCards)
        {
            QuestionCard c = new QuestionCard(tex.name, QuestionCard.Level.EASY, tex);
            easyCardSet.Add(c);
        }
    }

    private void FillMediumCardSet()
    {
        mediumCardSet = new List<QuestionCard>();
        /*foreach (string s in FileReader.instance.mediumCardFiles)
        {
            QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.MEDIUM, FileReader.instance.FileToTex(s));
            mediumCardSet.Add(c);
        }*/
        foreach (Texture2D tex in mediumCards)
        {
            QuestionCard c = new QuestionCard(tex.name, QuestionCard.Level.MEDIUM, tex);
            mediumCardSet.Add(c);
        }
    }

    private void FillHardCardSet()
    {
        hardCardSet = new List<QuestionCard>();
        /*foreach (string s in FileReader.instance.hardCardFiles)
        {
            QuestionCard c = new QuestionCard(SplitID(s), QuestionCard.Level.HARD, FileReader.instance.FileToTex(s));
            hardCardSet.Add(c);
        }*/
        foreach (Texture2D tex in hardCards)
        {
            QuestionCard c = new QuestionCard(tex.name, QuestionCard.Level.HARD, tex);
            hardCardSet.Add(c);
        }
    }

    private void FillActionCardSet()
    {
        actionCardSet = new List<ActionCard>();
        /*foreach (string s in FileReader.instance.actionCardFiles)
        {
            ActionCard c = new ActionCard(SplitID(s), FileReader.instance.FileToTex(s));
            actionCardSet.Add(c);
        }*/
        foreach (Texture2D tex in actionCards)
        {
            ActionCard c = new ActionCard(tex.name, tex);
            actionCardSet.Add(c);
        }
    }

    private void FillTaskSet()
    {
        taskSet = new List<CardSnippetTask>();
        /*foreach (string s in FileReader.instance.taskFiles) //Lädt erst die Karten 1, 10, 11, 12, 13, 14, 15 und anschließen 2-9 rein
        {
            CardSnippetTask snippet = new CardSnippetTask(SplitID(s), FileReader.instance.FileToTex(s));
            //Debug.Log("Snippet " + SplitID(s));
            taskSet.Add(snippet);
        }*/
        foreach (Texture2D tex in taskSnippets) //Lädt erst die Karten 1, 10, 11, 12, 13, 14, 15 und anschließen 2-9 rein
        {
            CardSnippetTask snippet = new CardSnippetTask(tex.name, tex);
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
