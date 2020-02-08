using System.Collections.Generic;
using UnityEngine;

public class CardManager :  MonoBehaviour
{
    public static CardManager instance;

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

    public Card Card
    {
        get => default;
        set
        {
        }
    }

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

        cardStack.GetComponent<CardStack>().enabled = true;
    }

    #region private Methods
    private void FillEasyCardSet()
    {
        easyCardSet = new List<QuestionCard>();

        foreach (Texture2D tex in easyCards)
        {
            QuestionCard c = new QuestionCard(tex.name, QuestionCard.Level.EASY, tex);
            easyCardSet.Add(c);
        }
    }

    private void FillMediumCardSet()
    {
        mediumCardSet = new List<QuestionCard>();

        foreach (Texture2D tex in mediumCards)
        {
            QuestionCard c = new QuestionCard(tex.name, QuestionCard.Level.MEDIUM, tex);
            mediumCardSet.Add(c);
        }
    }

    private void FillHardCardSet()
    {
        hardCardSet = new List<QuestionCard>();

        foreach (Texture2D tex in hardCards)
        {
            QuestionCard c = new QuestionCard(tex.name, QuestionCard.Level.HARD, tex);
            hardCardSet.Add(c);
        }
    }

    private void FillActionCardSet()
    {
        actionCardSet = new List<ActionCard>();

        foreach (Texture2D tex in actionCards)
        {
            ActionCard c = new ActionCard(tex.name, tex);
            actionCardSet.Add(c);
        }
    }

    private void FillTaskSet()
    {
        taskSet = new List<CardSnippetTask>();

        foreach (Texture2D tex in taskSnippets)
        {
            CardSnippetTask snippet = new CardSnippetTask(tex.name, tex);
            taskSet.Add(snippet);
        }
    }
    #endregion
}
