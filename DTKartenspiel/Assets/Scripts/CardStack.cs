using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardStack : MonoBehaviour
{
    public static CardStack instance;
    public bool gameStart = true; //Soll zu GameManager
    List<Card> cardStack;
    private System.Random randomizer = new System.Random();

    void OnEnable()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        BuildCardStack();
    }

    private void OnMouseDown()
    {
        //Einmalig muss die Karte zu Beginn aufgedeckt werden
        if (gameStart)
        {
            GameCard.instance.Reveal();
            gameStart = false; //Bei End() wieder auf true setzen
        }

        DrawCard();

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
        Debug.Log(cardStack.Count);
        UsedCards.instance.Grow();
    }

    //private Methods
    private void DrawCard()
    {
        Debug.Log(cardStack.Count);
        Card firstCard = cardStack[0];
        if(firstCard is QuestionCard)
        {
            GameCard.instance.isActionCard = false;
            GameCard.instance.SetPoints(((QuestionCard)firstCard).GetPoints());
            GameCard.instance.SetSolution(((QuestionCard)firstCard).GetSolution());
        }
        else //AcionCard
        {
            GameCard.instance.isActionCard = true;

        }
        GameCard.instance.SetMaterial(firstCard.tex);
        cardStack.RemoveAt(0);
        Debug.Log(firstCard.id + " was drawn");
        Debug.Log(cardStack.Count);
    }

    private void BuildCardStack() //Draw 30 out of 50
    {
        Card tmpCard;
        int maxRandomNumber;
        cardStack = new List<Card>();

        //Draw 6 out of EasyCardSet
        maxRandomNumber = CardManager.instance.easyCardSet.Count;
        while(cardStack.Count < 6)
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
        /*maxRandomNumber = CardManager.instance.easyCardSet.Count;
        while (cardStack.Count < 30)
        {
            tmpCard = CardManager.instance.easyCardSet[randomizer.Next(maxRandomNumber)];
            if (!cardStack.Contains(tmpCard))
            {
                cardStack.Add(tmpCard);
                Debug.Log(tmpCard.id);
            }
        }*/
    }
}
