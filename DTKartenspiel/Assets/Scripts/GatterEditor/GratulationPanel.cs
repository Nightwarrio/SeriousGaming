using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GratulationPanel : MonoBehaviour
{
    public GameObject points;

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        GateEditorManager.instance.gameObject.SetActive(false);
        points.GetComponent<Points>().Reset();
        GameManager.instance.NewTurn();
    }
}
