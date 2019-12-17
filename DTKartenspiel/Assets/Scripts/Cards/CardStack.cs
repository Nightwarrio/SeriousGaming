using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardStack : MonoBehaviour
{
    public static CardStack instance;
    public bool gameStart = true; //Soll zu GameManager
    public bool firstTurn;
    public GameObject gatterEditor;
    List<Card> cardStack;
    private System.Random randomizer = new System.Random();
    public GameObject cardInterface, cardsLeft;
    private GameObject[] buttons;
    private GameObject UIObject;

    void OnEnable()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(gameObject);

        firstTurn = true;
        BuildCardStack();
        Shuffle();
        //Debug.Log("Shuffle stack is not active!");

        UIObject = cardInterface;
        cardsLeft.GetComponent<Text>().text = "Cards Left: " + cardStack.Count;
        cardInterface = cardInterface.transform.GetChild(0).gameObject;
        buttons = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            buttons[i] = cardInterface.transform.GetChild(i).gameObject;
        }
        
    }

    #region privateFunctions
    private void OnMouseDown()
    {
        //Einmalig muss die Karte zu Beginn aufgedeckt werden
        if (gameStart)
        {
            GameCard.instance.Reveal();
            gameStart = false;
        }

        if (gatterEditor.activeInHierarchy) return;

        DrawCard();

        //if (UIObject.GetComponent<UI>().getAnswerGiven()) //TODO: Jonas macht das
        //{
            //press stack in the table
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
                    break;
                //TODO EndGame()
                default:
                    break;
            }
            //only for test 
            UsedCards.instance.Grow();
        //}
    }

    //private Methods
    private void DrawCard()
    {
        if (UIObject.GetComponent<UI>().getAnswerGiven())
        {
            if (cardStack.Count > 30) firstTurn = false;

            //Debug.Log(cardStack.Count);
            Card firstCard = cardStack[0];
            cardInterface.SetActive(true);
            if (firstCard is QuestionCard)
            {
                GameCard.instance.isActionCard = false;
                GameCard.instance.SetPoints(((QuestionCard)firstCard).GetPoints());
                GameCard.instance.SetSolution(((QuestionCard)firstCard).GetSolution());
                for (int i = 0; i < 3; i++)
                {
                    buttons[i].SetActive(true);
                }
                buttons[3].SetActive(false);
            }
            else //AcionCard
            {
                GameCard.instance.SetStatusToActionCard();
                for (int i = 0; i < 3; i++)
                {
                    buttons[i].SetActive(false);
                }
                buttons[3].SetActive(true);
            }
            GameCard.instance.SetMaterial(firstCard.tex);
            GameCard.instance.SetName(firstCard.id);
            cardStack.RemoveAt(0);
            cardsLeft.GetComponent<Text>().text = "Cards Left: " + cardStack.Count;
            UIObject.GetComponent<UI>().setanswerGivenFalse();
            Debug.Log(firstCard.id + " was drawn");

            if (cardStack.Count == 0) {
                UIObject.GetComponent<UI>().setWinScore();
                cardInterface.SetActive(false);
            }
        }

        else
        {
            UIObject.transform.GetChild(12).gameObject.SetActive(true);
        }

    }

    private void BuildCardStack() //Draw 30 out of 50
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
            {
                cardStack.Add(tmpCard);
                //Debug.Log(tmpCard.id);
            }
        }
        //Draw 9 out of MediumCardSet
        maxRandomNumber = CardManager.instance.mediumCardSet.Count;
        while (cardStack.Count < 15)
        {
            tmpCard = CardManager.instance.mediumCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
            {
                cardStack.Add(tmpCard);
                //Debug.Log(tmpCard.id);
            }
        }
        //Draw 6 out of HardCardSet
        maxRandomNumber = CardManager.instance.hardCardSet.Count;
        while (cardStack.Count < 21)
        {
            tmpCard = CardManager.instance.hardCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
            {
                cardStack.Add(tmpCard);
                //Debug.Log(tmpCard.id);
            }
        }
        //Draw 9 out of ActionCardSet
        maxRandomNumber = CardManager.instance.actionCardSet.Count;
        while (cardStack.Count < 30)
        {
            tmpCard = CardManager.instance.actionCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
            {
                cardStack.Add(tmpCard);
                //Debug.Log(tmpCard.id);
            }
        }
        //Only for test if action card works
        //cardStack[0] = CardManager.instance.actionCardSet[12];
    }

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
