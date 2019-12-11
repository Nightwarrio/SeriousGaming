using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionPanel : MonoBehaviour
{
    public List<GameObject> solutions;

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
        solutions[index].SetActive(true);
        //TODO:: Wieder inaktiv setzen, wenn Aufgabe gelöst wurde
    }
}
