using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanel : MonoBehaviour
{
    public static CraftingPanel instance;
    public GameObject chooseEntry;
    public List<GameObject> addedGatter = new List<GameObject>();

    private void Start()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// remove the gatter from the craftingPanel so that a new actionCard would start at a clean panel
    /// </summary>
    public void ClearPanel()
    {
        foreach (var gatter in addedGatter)
        {
            Debug.Log(gatter.name);
            Destroy(gatter);
            Debug.Log(gatter.name); 
        }
    }
}
