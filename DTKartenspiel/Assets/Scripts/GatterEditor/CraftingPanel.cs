using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanel : MonoBehaviour
{
    public static CraftingPanel instance;
    public GameObject chooseEntry;

    private void Start()
    {
        if (instance == null) instance = this;
    }
}
