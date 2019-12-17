using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionPanel : MonoBehaviour
{
    public static SolutionPanel instance;

    public GameObject gratulationPanel;
    public GameObject screenCard, UiObject;

    private List<GameObject> solutions;
    private int gatterAmount = 0; //how many gatter do we need for the solution

    private void Start()
    {
        if (instance == null) instance = this;
    }

    public void PrepareSolutions()
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
        //TODO:: Wieder inaktiv setzen, wenn Aufgabe gelöst wurde
        solutions[index].SetActive(true);
        gatterAmount = solutions[index].name[0] - 48;
    }

    /// <summary>
    ///     Erniedrige die Anzahl der zu findenden Gatter um eins. Ist diese 0, sind keine Gatter mehr übrig und
    ///     die Schaltung wurde gelöst
    /// </summary>
    public void DecreaseGatterAmount()
    {
        gatterAmount--;

        if (gatterAmount == 0)
        {
            LoadGratulationPanel();
        }
    }

    #region privateFunctions
    private void LoadGratulationPanel()
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
