using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for the SolutionPanel UI Element in the GateEditor. This Loads the SolutionTemplate when a ActionCard starts and
/// it decides if the Taske is solved.
/// </summary>
public class SolutionPanel : MonoBehaviour
{
    public static SolutionPanel instance;

    [Tooltip("The GratulationPanel UI Element")] public GameObject gratulationPanel;
   
    [HideInInspector] public GameObject currentShownSolutionPanel; //The DrawLineScript need this

    private List<GameObject> solutions;

    /// <summary>
    /// The Amount of how many Gates we need for the solution.
    /// For each correct Gate we will decrease this by one.
    /// This will be set in LoadSolution()
    /// </summary>
    private int gateAmount = 0;

    /// <summary>
    /// The Amount of how many Gates we need for the solution.
    /// The ExtraPoints are given when all Inputs and Outputs set correct.
    /// </summary>
    private int extraPoints; 

    private void Start()
    {
        if (instance == null) instance = this;
    }

    public void LoadSolution(int index)
    {
        PrepareSolutions();

        solutions[index].SetActive(true); //TODO:: Wieder inaktiv setzen, wenn Aufgabe gelöst wurde; wird bereits gemacht. Bitte prüfen wo?!
        gateAmount = solutions[index].name[0] - 48; //the first Char of the solutions Name will have this Information
        extraPoints = gateAmount;
        currentShownSolutionPanel = solutions[index];
    }

    /// <summary>
    /// Called by a LogicalGate, when its completed and set the extraPoints to the playersTeam
    /// </summary>
    public void GateCompleted() 
    {
        gateAmount--;

        if (gateAmount == 0)
        {
            LoadGratulationPanel();
            Score.instance.SetExtraPoints(extraPoints);
        }
    }

    /// <summary>
    /// A completed Gate was canceld by removing the correct Answer
    /// The caller can be blocked, so that only one time a response arrived
    /// </summary>
    public void TakeBackGateCompleted(LogicalGate caller)
    {
        gateAmount++;
        caller.isBlocked = true;
    }

    #region privateFunctions
    /// <summary>
    /// Fill the SolutionsList. Simply all Childs of the SolutionPanel.
    /// Example: "7Solution1" means: This is the Solution for ActionCard 1 and we will need 7 Gates to solve this.
    /// </summary>
    private void PrepareSolutions()
    {
        solutions = new List<GameObject>();

        foreach (Transform child in transform)
        {
            solutions.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// This Method will wait 1 Second bevor open the GratulationPanel.
    /// </summary>
    private void LoadGratulationPanel()
    {
        StartCoroutine(Wait(1f));
    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        gratulationPanel.SetActive(true);
    }
    #endregion
}
