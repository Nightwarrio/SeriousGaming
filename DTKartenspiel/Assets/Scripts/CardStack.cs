using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    public static CardStack instance;
    HashSet<Card> cardStack;
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        BuildCardStack();
    }

    //private Methods//
    private void BuildCardStack()
    {
        cardStack = new HashSet<Card>();

        //TODO Draw 30 out of 50
        //Draw 6 out of EasyCardSet
        //Draw 9 out of MediumCardSet
        //Draw 6 out of HardCardSet
        //Draw 9 out of ActionCardSet
    }
}
