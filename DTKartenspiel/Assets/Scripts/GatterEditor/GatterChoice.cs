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

        clone = Instantiate(prefab, Input.mousePosition, Quaternion.identity);
        CraftingPanel panel = FindObjectOfType<CraftingPanel>();
        clone.transform.SetParent(panel.transform, false); //this changes the transform of the clone
        clone.transform.position = Input.mousePosition;
    }
}
