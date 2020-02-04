using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPanel : MonoBehaviour
{
    public static CraftingPanel instance;
    public GameObject chooseEntry;

    /// <summary>
    /// store all gatters we added, so that we can simply destroy them, to clean up
    /// </summary>
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
            Destroy(gatter);
        }
    }

    /// <summary>
    /// ChooseEntry has to be at the last position, to be on top of the gatters. 
    /// This fix the bug, that the panel is behind a gatter and we can't set an entry.
    /// </summary>
    public void MoveChooseEntryToLastPosition()
    {
        var lastGatterAdded = gameObject.transform.GetChild(transform.childCount - 1);
        int index = chooseEntry.transform.GetSiblingIndex();

        lastGatterAdded.transform.SetSiblingIndex(index);
        chooseEntry.transform.SetSiblingIndex(gameObject.transform.childCount-1); //set to last position
    }
}
