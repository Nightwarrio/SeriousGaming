using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class represents the CardStack in the Game. The Script is inactive at the start of the game and will be activated
/// after the CardManager build all CardSets.
/// </summary>
public class CardStack : MonoBehaviour
{
    public static CardStack instance;

    [Tooltip("The ScreenCard GameObject")] public GameObject screenCard;
    [Tooltip("The UI-Countdown Element")] public GameObject countdown;

    /// <summary>
    /// represents the 30 choosen cards in BuildCardStack()
    /// </summary>
    private List<Card> cardStack; 

    private System.Random randomizer = new System.Random();
    private GameObject[] buttons;
    private bool firstTurn;

    void Start()
    {
        if (instance == null) instance = this;

        firstTurn = true;

        BuildCardStack();
        Shuffle();

        UI.instance.UpdateCardsLeft(cardStack.Count);

        //TODO:: @Jonas, gehört das nicht in die ScreenCard Klasse?
        //Füge die Buttons für die vier Auswahlmöglichkeiten hinzu
        buttons = new GameObject[4];
        for (int i = 0; i < 4; i++)
            buttons[i] = screenCard.transform.GetChild(i).gameObject;
    }

    #region privateFunctions
    private void OnMouseDown()
    {
        if (GameManager.instance.gameInProgress)
        {
            //Blocks the CardStack during the turn. Is set active by NewTurn() in GameManager
            gameObject.SetActive(false);

            if (firstTurn)
                GameCard.instance.Reveal();

            DrawCard();
        }
    }

    /// <summary>
    /// Load the Card on the GameCard and remove it from the CardStack
    /// </summary>
    private void DrawCard()
    {
        Card firstCard = cardStack[0];
        screenCard.SetActive(true);

        if (firstCard is QuestionCard) //In case its a QuestionCard
        {
            countdown.GetComponent<CountdownScript>().StartCountdown(60); //Start Countdown

            GameCard.instance.isActionCard = false;
            GameCard.instance.SetPoints(((QuestionCard)firstCard).GetPoints());
            GameCard.instance.SetSolution(((QuestionCard)firstCard).GetSolution());

            //TODO:: Bitte den Code erklären @Jonas
            for (int i = 0; i < 3; i++)
            {
                if(buttons[i].gameObject.tag == "ActionButton")
                buttons[i].SetActive(true);
                else{
                buttons[3].SetActive(false);
                }
            }
        }
        else //In case its a AcionCard
        {
            GameCard.instance.SetStatusToActionCard();

            //TODO:: Bitte den Code erklären @Jonas
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i].gameObject.tag == "ActionButton")
                    buttons[i].SetActive(false);
                else
                {
                    buttons[3].SetActive(true);
                }
            }
        }

        GameCard.instance.SetMaterial(firstCard.tex);
        GameCard.instance.SetName(firstCard.id);

        cardStack.RemoveAt(0);
        PressStack();

        UI.instance.UpdateCardsLeft(cardStack.Count);
    }

    /// <summary>
    /// Press the CardStack down the table and end the game if the cards are empty
    /// </summary>
    private void PressStack()
    {
        Vector3 tmp = new Vector3(0, 0.0076f, 0);
        switch (cardStack.Count)
        {
            case 20:
                transform.position -= tmp;
                break;
            case 15:
                transform.position -= tmp;
                break;
            case 10:
                transform.position -= tmp;
                break;
            case 5:
                transform.position -= tmp;
                break;
            case 0:
                transform.position = new Vector3(transform.position.x, 0.91f, transform.position.z);
                GameManager.instance.EndGame();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Choose 30 Cards out of all Cards.
    /// </summary>
    private void BuildCardStack()
    {
        Card tmpCard;
        int maxRandomNumber;
        cardStack = new List<Card>();

        //Draw 6 out of EasyCardSet
        maxRandomNumber = CardManager.instance.easyCardSet.Count;
        while (cardStack.Count < 6)
        {
            tmpCard = CardManager.instance.easyCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
                cardStack.Add(tmpCard);
        }

        //Draw 9 out of MediumCardSet
        maxRandomNumber = CardManager.instance.mediumCardSet.Count;
        while (cardStack.Count < 15)
        {
            tmpCard = CardManager.instance.mediumCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
                cardStack.Add(tmpCard);
        }

        //Draw 6 out of HardCardSet
        maxRandomNumber = CardManager.instance.hardCardSet.Count;
        while (cardStack.Count < 21)
        {
            tmpCard = CardManager.instance.hardCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
                cardStack.Add(tmpCard);
        }

        //Draw 9 out of ActionCardSet
        maxRandomNumber = CardManager.instance.actionCardSet.Count;
        while (cardStack.Count < 30)
        {
            tmpCard = CardManager.instance.actionCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
                cardStack.Add(tmpCard);
        }
    }

    /// <summary>
    /// Shuffle the CardStack
    /// </summary>
    private void Shuffle()
    {
        int count = cardStack.Count;
        int last = count - 1;
        for (int i = 0; i < last; i++)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = cardStack[i];
            cardStack[i] = cardStack[r];
            cardStack[r] = tmp;
        }
    }
    #endregion
}
