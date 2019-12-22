using System.Collections;
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
            if (!transform.parent.GetComponent<LogicalGatter>().haveLine)
            {
                CreateLine();
                transform.parent.GetComponent<LogicalGatter>().haveLine = true;
            }
        }

        //Linie zeichen während die linke Maustaste gedrückt wird
        if (currentLine != null && Input.GetMouseButton(0))
        {
            if (Vector2.Distance(currentPosition, lastPosition) > .1f)
                UpdateLine();
        }

        if (Input.GetMouseButtonUp(0))
            currentLine = null;
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
