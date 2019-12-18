﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    public bool needTwoLetters; //we would need two letters to choose!
    public GameObject collisionObject;
    public Text entry1, entry2, notEntry;

    private GameObject logicalGatter = null;

    public bool RightPlace()
    {
        if (logicalGatter != null) return false; //placeholder ist bereits belegt

        bool tmp = gameObject.tag == collisionObject.tag;
        //TODO:: if true, schreibe dem Team des Spielers 5 Punkte aufs Konto (gerne auch mit Effekt, wie beim Damage)
        if (tmp) Debug.Log(gameObject.name + ": Thats right! You earn 5 Points!");
        return tmp;
    }

    public void SetLogicalGatter(GameObject logicalGatter)
    {
        this.logicalGatter = logicalGatter;
        logicalGatter.GetComponent<LogicalGatter>().needTwoLetters = needTwoLetters;
        logicalGatter.GetComponent<LogicalGatter>().myPlaceholder = this;
        SnapGatterToPosition();

        Destroy(gameObject.GetComponent<Image>()); //die graue Hinterlegung entfernen
        Destroy(gameObject.GetComponent<BoxCollider2D>()); //without we get an nullPointerException
    }

    public void SetEntry1(char letter)
    {
        entry1.GetComponent<Text>().text = letter.ToString();
    }
    public void SetEntry2(char letter)
    {
        entry2.GetComponent<Text>().text = letter.ToString();
    }
    public void SetNotEntry(char letter)
    {
        notEntry.GetComponent<Text>().text = letter.ToString();
    }

    #region privateFunctions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
        collisionObject.GetComponent<GatterChoice>().SetChoosenPlaceholder(this);

        var image = gameObject.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.GetComponent<Image>() != null)
        {
            var image = gameObject.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2156863f);
        }
    }

    /// <summary>
    /// set Gatter in the center of the placeholder, so that the entries are visible
    /// </summary>
    private void SnapGatterToPosition()
    {
        logicalGatter.transform.position = new Vector3(gameObject.transform.position.x + 10f, gameObject.transform.position.y, 0);
    }
    #endregion
}
