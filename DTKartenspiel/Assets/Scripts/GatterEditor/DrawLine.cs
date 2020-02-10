using UnityEngine;
using System;

/// <summary>
/// This Class Manages to draw a Line in the CraftingPanel. It contains to the DrawLineArea GameObject.
/// Each LogicalGate-Prefab have a DrawLineArea on the right Side and an LineInput at the LeftSide.
/// </summary>
public class DrawLine : MonoBehaviour
{
    [Tooltip("The Line Prefab")]public GameObject linePrefab;
    public GameObject currentLine = null;
    public bool hitSomething;
    public bool active;

    private Vector3 currentPosition;
    private Vector3 lastPosition = Vector3.zero;

    void Update()
    {
        currentPosition = Input.mousePosition;

        //Create a Line, when clicking the left MouseButton in the correct radius
        if (Vector2.Distance(Input.mousePosition, transform.position) < 10f && Input.GetMouseButtonDown(0))
        {
            if (!transform.parent.GetComponent<LogicalGate>().haveLineOutput)
                CreateLine();
        }

        //Draw the Line during pressing the left MouseButton
        if (currentLine != null && Input.GetMouseButton(0))
        {
            if (Vector2.Distance(currentPosition, lastPosition) > .1f)
            {
                UpdateLine();
                SearchAndSetLineInput();
            }
        }

        //MouseButton released without reaching an valid entry
        if (Input.GetMouseButtonUp(0) && currentLine != null)
        {
            currentLine.GetComponent<Line>().DestroyMe();
            currentLine = null;
            transform.parent.GetComponent<LogicalGate>().haveLineOutput = false;
        }
            
    }

    #region privateMethods

    /// <summary>
    /// Create the Line and assign this Script to it.
    /// </summary>
    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.transform.SetParent(SolutionPanel.instance.currentShownSolutionPanel.transform);
        currentLine.transform.position = Input.mousePosition;

        currentLine.GetComponent<Line>().myManager = this;
    }

    /// <summary>
    /// If there is a lastPosition, we can add a new Pixel to the Line
    /// </summary>
    private void UpdateLine()
    {
        try { lastPosition = currentLine.GetComponent<Line>().GetPosition(); }
        catch (Exception e) {};
        
        currentLine.GetComponent<Line>().AddPixel();
    }

    /// <summary>
    /// Find all colliders in near the mousePosition. Try to connect the line with the nearest collider with 
    /// tag "lineInput". If not works (there is already another line in the entry), the line will be destroyed.
    /// </summary>
    private void SearchAndSetLineInput()
    {
        //Find all colliders touching or inside of the given box.
        //Given: (mousePosition, center of the box, extensions in each direction, Rotation, Layer 5 = UI)
        Collider[] foundColliders = Physics.OverlapBox(Input.mousePosition, new Vector3(5f, 5f, 5f), Quaternion.identity, 5);
       
        if (foundColliders.Length > 0 && foundColliders[0].gameObject.CompareTag("LineInput"))
        {
            GameObject destination = foundColliders[0].gameObject.transform.parent.gameObject;

            if (destination.name.Equals("Y"))
                transform.parent.GetComponent<LogicalGate>().haveLineOutput = true; 

            else //We found another Gate
            {
                if (destination.GetComponent<LogicalGate>().SetLineEntry()) //Found valid Entry
                    transform.parent.GetComponent<LogicalGate>().haveLineOutput = true;

                else currentLine.GetComponent<Line>().DestroyMe(); //No valid Entry
            }

            currentLine = null;
        }
    }
    #endregion
}
