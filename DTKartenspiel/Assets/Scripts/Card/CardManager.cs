using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class contains all Textures of the GameCards and make them to GameObjects
/// </summary>
public class CardManager :  MonoBehaviour
{
    public static CardManager instance;

    //We need this because the CardStack-Script is inactive at the start of the game
    [Tooltip("CardStack GameObject")] public GameObject cardStack; 

    [Header("Textures")]
    [Tooltip("Textures of all ActionCards")] public Texture2D[] actionCards;
    [Tooltip("Textures of all ActionCard-Tasks")] public Texture2D[] taskSnippets;
    [Tooltip("Textures of all EasyCards")] public Texture2D[] easyCards;
    [Tooltip("Textures of all MediumCards")] public Texture2D[] mediumCards;
    [Tooltip("Textures of all HardCards")] public Texture2D[] hardCards;

    public List<QuestionCard> easyCardSet;
    public List<QuestionCard> mediumCardSet;
    public List<QuestionCard> hardCardSet;
    public List<ActionCard> actionCardSet;
    public List<CardSnippetTask> taskSet;

    public Card testCard;

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

    /// <summary>
    /// Converts Texture2D to Sprites
    /// </summary>
    /// <param name="tex">The Texture2D</param>
    /// <returns>The corresponding Sprite</returns>
    public Sprite TexToSprite(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        return sprite;
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

        //testCard = actionCardSet[5];
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
