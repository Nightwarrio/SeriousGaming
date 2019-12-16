using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GatterChoice : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject prefab;

    private Vector3 originPosition;
    private GameObject clone;
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

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.white;
        transform.position = originPosition;

        if (choosenPlaceholder.RightPlace())
        {
            clone = Instantiate(prefab, Input.mousePosition, Quaternion.identity);
            CraftingPanel panel = FindObjectOfType<CraftingPanel>();
            CraftingPanel.instance.addedGatter.Add(clone); //give a reference to the craftingPanel, so that we can destroy the gatters
            clone.transform.SetParent(panel.transform, false); //this changes the transform of the clone
            clone.transform.position = Input.mousePosition; 

            choosenPlaceholder.SetLogicalGatter(clone);
            //choosenPlaceholder.SnapGatterToPosition(); //TODO::
            SolutionPanel.instance.DecreaseGatterAmount();
        }
        else
        {
            //TODO:: Kenntlich machen, dass es falsch war (rotes Kreuz)
            Debug.Log(choosenPlaceholder.gameObject.name + ": That was the wrong logicGatter!");
        }
    }

    public void SetChoosenPlaceholder(Placeholder placeholder)
    {
        this.choosenPlaceholder = placeholder;
    }
}
