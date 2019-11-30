using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    public static CardStack instance;
    List<Card> cardStack;
    private System.Random randomizer = new System.Random();

    void OnEnable()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        BuildCardStack();
        DrawCard();
    }

    public void DrawCard()
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

    //private Methods
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
