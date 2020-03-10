﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GateChoice : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject prefab;

    private Vector3 originPosition;
    private GameObject clone;
    private Placeholder choosenPlaceholder; //set by placeholder when trigger

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.black;
        originPosition = transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.white;
        transform.position = originPosition;

        try //wenn man zu früh loslässt ist choosenPlaceholder noch nicht zugewiesen
        {
            if (choosenPlaceholder.RightPlace())
            {
                clone = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                CraftingPanel.instance.addedGatter.Add(clone);

                //here we add the clone as a child to the panel; this changes the transform of the clone
                CraftingPanel panel = FindObjectOfType<CraftingPanel>();
                clone.transform.SetParent(panel.transform, false); //worldPositionStayes = true?!
                clone.transform.position = Input.mousePosition;

                CraftingPanel.instance.MoveChooseEntryToLastPosition();
                choosenPlaceholder.SetLogicalGate(clone);
                choosenPlaceholder = null; 

                GateEditorManager.instance.ShowPoints(clone);
            }
            else
            {
                GateEditorManager.instance.ShowFalse(choosenPlaceholder.gameObject);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
            Debug.Log("Gatter muss über eines der grau hinterlegten Felder losgelassen werden!");
        }
    }

    /// <summary>
    /// used by placeholder, when a the gatterChoice triggers
    /// </summary>
    /// <param name="placeholder"></param>
    public void SetChoosenPlaceholder(Placeholder placeholder)
    {
        this.choosenPlaceholder = placeholder;
    }
}