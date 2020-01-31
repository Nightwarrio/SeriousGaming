using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GratulationPanel : MonoBehaviour
{
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        GameManager.instance.NewTurn();
    }
}
