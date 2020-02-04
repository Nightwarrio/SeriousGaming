using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionPanel : MonoBehaviour
{
    public static SolutionPanel instance;

    public GameObject gratulationPanel;
    public GameObject screenCard, UiObject;
    public GameObject currentShownSolutionPanel;

    private List<GameObject> solutions;
    private int gateAmount = 0; //how many Gate do we need for the solution; Is set in LoadSolution();
    private int extraPoints; //is given when all entrys end outputs set correct

    private void Start()
    {
        if (instance == null) instance = this;
    }

    private void PrepareSolutions()
    {
        solutions = new List<GameObject>();

        foreach(Transform child in transform)
        {
            solutions.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public void LoadSolution(int index)
    {
        PrepareSolutions();

        //TODO:: Wieder inaktiv setzen, wenn Aufgabe gelöst wurde; wird bereits gemacht. Bitte prüfen wo?!
        solutions[index].SetActive(true);
        gateAmount = solutions[index].name[0] - 48; //der erste char im Namen sagt an, wie viele Gatter für die Lösung benötigt werden
        extraPoints = gateAmount;
        currentShownSolutionPanel = solutions[index];
    }

    /// <summary>
    ///     Called by a LogicalGattter, when its completed and set the extraPoints to the playersTeam
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
    /// a completed gatter was canceld by remove the correct answer
    /// the caller can be blocked, so that only one time a response done
    /// </summary>
    public void TakeBackGateCompleted(LogicalGate caller)
    {
        gateAmount++;
        caller.isBlocked = true;
    }

    #region privateFunctions
    private void LoadGratulationPanel() //wait 1sec. bevor open the gratulationPanel
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
