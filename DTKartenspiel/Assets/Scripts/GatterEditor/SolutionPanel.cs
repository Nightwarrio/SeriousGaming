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
    private int gatterAmount = 0; //how many gatter do we need for the solution

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
        gatterAmount = solutions[index].name[0] - 48; //der erste char im Namen sagt an, wie viele Gatter für die Lösung benötigt werden
        currentShownSolutionPanel = solutions[index];
    }

    /// <summary>
    ///     Called by a LogicalGattter, when its completed
    /// </summary>
    public void GatterCompleted() 
    {
        gatterAmount--;

        if (gatterAmount == 0)
        {
            LoadGratulationPanel();
        }
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
        UiObject.GetComponent<UI>().setanswerGivenTrue();
        screenCard.SetActive(false);
    }
    #endregion
}
