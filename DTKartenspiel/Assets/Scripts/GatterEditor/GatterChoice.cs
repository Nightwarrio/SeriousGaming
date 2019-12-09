using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GatterChoice : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector3 originPosition;
    private GameObject clone;

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

        clone = Instantiate(this.gameObject, Input.mousePosition, Quaternion.identity);
        CraftingPanel panel = FindObjectOfType<CraftingPanel>();
        clone.transform.SetParent(panel.transform, false); //this changes the transform of the clone
        clone.transform.position = Input.mousePosition;
        Destroy(clone.GetComponent<GatterChoice>());
        AddLogicalGatterScript();
    }

    private void AddLogicalGatterScript()
    {
        string type = gameObject.name;
        switch (type)
        {
            case "AND":
                clone.AddComponent<AND>();
                break;
            case "NAND":
                clone.AddComponent<NAND>();
                break;
            case "OR":
                clone.AddComponent<OR>();
                break;
            case "NOR":
                clone.AddComponent<NOR>();
                break;
            case "NOT":
                clone.AddComponent<NOT>();
                break;
            case "XOR":
                clone.AddComponent<XOR>();
                break;
            case "XNOR":
                clone.AddComponent<XNOR>();
                break;
        }
    }
}
