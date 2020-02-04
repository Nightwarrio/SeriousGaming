﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine = null;
    public bool hitSomething;

    private Vector3 currentPosition;
    private Vector3 lastPosition = Vector3.zero;
    public bool active;

    void Update()
    {
        currentPosition = Input.mousePosition;

        //Linie erstellen, bei Linksklick und im korrekten Radius
        if (Vector2.Distance(Input.mousePosition, transform.position) < 10f && Input.GetMouseButtonDown(0))
        {
            if (!transform.parent.GetComponent<LogicalGate>().haveLineOutput)
            {
                CreateLine();
            }
        }

        //Linie zeichen während die linke Maustaste gedrückt wird
        if (currentLine != null && Input.GetMouseButton(0))
        {
            if (Vector2.Distance(currentPosition, lastPosition) > .1f)
            {
                UpdateLine();
                SearchAndSetLineInput();
            }
        }

        //Taste losgelassen ohne ein gültiges entry erreicht zu haben
        if (Input.GetMouseButtonUp(0) && currentLine != null)
        {
            currentLine.GetComponent<Line>().DestroyMe();
            currentLine = null;
            transform.parent.GetComponent<LogicalGate>().haveLineOutput = false;
        }
            
    }

    #region privateMethods
    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.transform.SetParent(SolutionPanel.instance.currentShownSolutionPanel.transform);
        currentLine.transform.position = Input.mousePosition;
        currentLine.GetComponent<Line>().myManager = this;
    }

    private void UpdateLine()
    {
        try { lastPosition = currentLine.GetComponent<Line>().GetPosition(); }
        catch (ArgumentOutOfRangeException e) {};
        
        currentLine.GetComponent<Line>().AddPixel();
    }

    /// <summary>
    /// Find all colliders in near the mousePosition. Try to connect the line with the nearest collider with 
    /// tag "lineInput". If not works (there is already another line in the entry), the line will be destroyed.
    /// </summary>
    private void SearchAndSetLineInput()
    {
        //Find all colliders touching or inside of the given box.
        //Given: (center of the box, extensions in each direction, Rotation, Layer 5 = UI)
        Collider[] foundColliders = Physics.OverlapBox(Input.mousePosition, new Vector3(5f, 5f, 5f), Quaternion.identity, 5);
       
        if (foundColliders.Length > 0 && foundColliders[0].gameObject.tag.Equals("LineInput"))
        {
            GameObject destination = foundColliders[0].gameObject.transform.parent.gameObject;

            if (destination.name.Equals("Y"))
                transform.parent.GetComponent<LogicalGate>().haveLineOutput = true;  //TODO:: Strom fließen lassen?

            else //We found another gatter
            {
                if (destination.GetComponent<LogicalGate>().SetLineEntry())
                    transform.parent.GetComponent<LogicalGate>().haveLineOutput = true;
                else currentLine.GetComponent<Line>().DestroyMe(); 
            }

            currentLine = null;
        }
    }
    #endregion
}
