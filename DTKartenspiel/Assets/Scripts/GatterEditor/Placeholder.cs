﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    public bool firstPosition; //we would need two letters to choose!

    public GameObject collisionObject;
    private GameObject logicalGatter = null;

    public bool RightPlace()
    {
        bool tmp = gameObject.tag == collisionObject.tag;
        //TODO:: if true, schreibe dem Team des Spielers 5 Punkte aufs Konto (gerne auch mit Effekt, wie beim Damage)
        if (tmp) Debug.Log(gameObject.name + ": Thats right! You earn 5 Points!");
        return tmp;
    }

    public void SetLogicalGatter(GameObject logicalGatter)
    {
        this.logicalGatter = logicalGatter;
        logicalGatter.GetComponent<LogicalGatter>().firstPosition = firstPosition;

        Destroy(gameObject.GetComponent<Image>()); //die graue Hinterlegung entfernen
        Destroy(gameObject.GetComponent<BoxCollider2D>()); //prevent to set a second gatter
    }

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
}
