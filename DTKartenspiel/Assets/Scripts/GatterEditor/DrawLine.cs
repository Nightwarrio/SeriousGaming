using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab, currentLine;

    private Vector3 currentPosition;
    private Vector3 lastPosition = Vector3.zero;

    void Update()
    {
        currentPosition = Input.mousePosition;
        
        if (Input.GetMouseButtonDown(0)) //left mouseButton initial click
            CreateLine();

        if (Input.GetMouseButton(0)) //pressing the left mouseButton
        {
            if (Vector3.Distance(currentPosition, lastPosition) > .1f) //.1f is the size of one pixel
                UpdateLine();
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.transform.SetParent(SolutionPanel.instance.currentShownSolutionPanel.transform);
        currentLine.transform.position = Input.mousePosition;
    }

    private void UpdateLine()
    {
        try { lastPosition = currentLine.GetComponent<Line>().GetPosition(); }
        catch (ArgumentOutOfRangeException e) {
            //Only the first one will throw an error
        };
        
        currentLine.GetComponent<Line>().AddPixel();
    }
}
