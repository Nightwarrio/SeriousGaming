using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SingleGatterChoice : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject prefab;

    [Header("Entrys")]
    public bool a;
    public bool b;
    public bool c;

    [Header("Exit")]
    public bool y;

    private Vector3 originPosition;

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
        Instantiate(prefab, Input.mousePosition, Quaternion.identity);
        transform.position = originPosition;
    }
}
