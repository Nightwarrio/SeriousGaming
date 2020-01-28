﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardStack : MonoBehaviour
{
    public static CardStack instance;
    public GameObject gatterEditor;
    public GameObject cardInterface, cardsLeft, UIObject, noAnswerScreen, countdownScreen;
    public bool firstTurn; //UsedCards greift darauf zu, da bei der ersten Runde keine Karte abgeworfen wird

    List<Card> cardStack; 
    private System.Random randomizer = new System.Random();
    private GameObject[] buttons;

    void OnEnable()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(gameObject);

        firstTurn = true;
        //cardStack = CardManager.instance.actionCardSet; for testing actionCards
        BuildCardStack();
        Shuffle();
        cardsLeft.GetComponent<Text>().text = "Cards Left: " + cardStack.Count;

        //Füge die Buttons für die vier Auswahlmöglichkeiten hinzu
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
        if (firstTurn)
        {
            GameCard.instance.Reveal();
          //  firstTurn = false;
        }

        if (gatterEditor.activeInHierarchy) return;

        DrawCard();

        if (UIObject.GetComponent<UI>().getAnswerGiven()) //TODO: Jonas macht das
        {
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

            UsedCards.instance.Grow();
        }
    }

    //private Methods
    private void DrawCard()
    {
        if (UIObject.GetComponent<UI>().getAnswerGiven())
        {
            countdownScreen.SetActive(true);
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
                  if(buttons[i].gameObject.tag == "ActionButton")
                    buttons[i].SetActive(true);
                  else{
                    buttons[3].SetActive(false);
                  }
                }
            }
            else //AcionCard
            {
                GameCard.instance.SetStatusToActionCard();
                for (int i = 0; i < 3; i++)
                {
                  if(buttons[i].gameObject.tag == "ActionButton")
                    buttons[i].SetActive(false);
                  else{
                    buttons[3].SetActive(true);
                  }
            }
          }

            GameCard.instance.SetMaterial(firstCard.tex);
            GameCard.instance.SetName(firstCard.id);

            cardStack.RemoveAt(0);

            cardsLeft.GetComponent<Text>().text = "Cards Left: " + cardStack.Count;

            UIObject.GetComponent<UI>().setanswerGivenFalse();

            Debug.Log(firstCard.id + " was drawn");

            if(!firstTurn){
              UsedCards.instance.Grow();
            }
        }

        else
        {
            noAnswerScreen.SetActive(true);
        }
        if(firstTurn){
          firstTurn = false;
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
