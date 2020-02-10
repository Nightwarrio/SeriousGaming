using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Class for the GatePrefabs which placed on the left Side in the GateEditor.
/// When a Gate is chossen and drag to the CraftingPanel, a copy is instatiate and the GateChoice Script is 
/// replaced by a LogicalGate Script.
/// </summary>
public class GateChoice : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Tooltip("A logical AND, OR, NOT or XOR Gate")] public GameObject prefab;

    /// <summary>
    /// The Position of the Gate bevor we drag them. After we drop a Copy of it to the right Placeholder
    /// the original Gate is positioned back to this origionPosition.
    /// </summary>
    private Vector3 originPosition;

    private GameObject clone;

    /// <summary>
    /// The Placeholder where the Gate is dropped over. This one will set by the Placehilder when trigger.
    /// </summary>
    private Placeholder choosenPlaceholder; 

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.black;
        originPosition = transform.position;
    }

    /// <summary>
    /// This Method proofs, it this Placeholder we dropped the Gate above is a valid Position for the Gate.
    /// If it is, the a Copy of the Gate will be assigned to this Placeholder and the original Gate will be positioned back.
    /// The Player earn Points if it is a valid Position or the "False" is shown up.
    /// </summary>
    /// <param name="eventData">Leave the left mouseButton</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.white;
        transform.position = originPosition;

        try //in the Case the player dont dropped over a Placeholder
        {
            if (choosenPlaceholder.RightPlace()) 
            {
                clone = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                CraftingPanel.instance.addedGatter.Add(clone);

                //here we add the clone as a child to the panel; this changes the transform of the clone
                CraftingPanel panel = FindObjectOfType<CraftingPanel>();
                clone.transform.SetParent(panel.transform, false); 
                clone.transform.position = Input.mousePosition;

                CraftingPanel.instance.MoveChooseEntryToLastPosition();
                choosenPlaceholder.SetLogicalGate(clone);
                choosenPlaceholder = null; 

                GateEditorManager.instance.ShowPoints(clone);
            }
            else
            {
                GateEditorManager.instance.ShowFalse(choosenPlaceholder.gameObject);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
            Debug.Log("Gate has to be dropped over a grey colored Field!");
        }
    }

    /// <summary>
    /// Used by Placeholder, when a the GateChoice triggers
    /// </summary>
    /// <param name="placeholder">The Placeholder where the Gate is dropped</param>
    public void SetChoosenPlaceholder(Placeholder placeholder)
    {
        choosenPlaceholder = placeholder;
    }
}
