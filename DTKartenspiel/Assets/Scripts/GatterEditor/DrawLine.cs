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
        if (Vector2.Distance(Input.mousePosition, transform.position) < 10f)
        {
            //Debug.Log("active");
            currentPosition = Input.mousePosition;

            //Linie erstellen, bei Linksklick
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }

            //Linie zeichen, wenn wir im erlaubten Bereich sind und die linke Maustaste gedrückt wird
            if (currentLine != null && Input.GetMouseButton(0))
            {
                if (Vector3.Distance(currentPosition, lastPosition) > .1f)
                    UpdateLine();
            }
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
