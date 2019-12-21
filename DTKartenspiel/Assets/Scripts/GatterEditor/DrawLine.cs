using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab, currentLine;
    public LineRenderer lineRenderer;
    public List<Vector3> positions;

    private Vector3 currentPosition;

    // Update is called once per frame
    void Update()
    {
        /// for the z position we need a negative value, so that the line is on top
        currentPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -2f);

        if (Input.GetMouseButtonDown(0)) //left mouseButton initial click
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0)) //pressing the left mouseButton
        {
            if (Vector2.Distance(currentPosition, positions[positions.Count - 1]) > .1f)
            {
                UpdateLine();
            }
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.transform.SetParent(SolutionPanel.instance.currentShownSolutionPanel.transform);

        lineRenderer = currentLine.GetComponent<LineRenderer>();

        positions.Clear();
        positions.Add(currentPosition); 
        lineRenderer.SetPosition(0, positions[0]); //an die Position 0 setze positions[0]
        lineRenderer.SetPosition(1, positions[0]); //da eine Linie aus mind. zwei Punkten besteht
    }

    private void UpdateLine()
    {
        positions.Add(currentPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, currentPosition);
    }
}
