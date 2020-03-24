using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for the CraftingPanel UI Element in the GateEditor
/// </summary>
public class CraftingPanel : MonoBehaviour
{
    public static CraftingPanel instance;

    [Tooltip("The ChooseEntry UI Element")] public GameObject chooseEntry;

    /// <summary>
    /// Store all Gates we added, so that we can simply destroy them to clean up
    /// </summary>
    public List<GameObject> addedGatter = new List<GameObject>();

    private void Start()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// Remove the Gates from the CraftingPanel so that a new ActionCard can start in a clean panel
    /// </summary>
    public void ClearPanel()
    {
        foreach (var gatter in addedGatter)
        {
            Destroy(gatter);
        }
    }

    /// <summary>
    /// ChooseEntry has to be at the last position, to be on top of the Gates. 
    /// This fix the bug, that the ChosseEntry is behind a Gate and we can't set an entry.
    /// </summary>
    public void MoveChooseEntryToLastPosition()
    {
        var lastGatterAdded = gameObject.transform.GetChild(transform.childCount - 1);
        int index = chooseEntry.transform.GetSiblingIndex();

        lastGatterAdded.transform.SetSiblingIndex(index);
        chooseEntry.transform.SetSiblingIndex(gameObject.transform.childCount-1); //set to last position
    }
}
