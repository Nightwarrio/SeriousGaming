using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicalGatter : MonoBehaviour, IPointerDownHandler
{
    public GameObject chooseEntry;

    [Header("Choices")]
    public bool A;
    public bool B;
    public bool C;
    public bool D;

    [Header("Entrys")]
    public bool entryNotGatter;
    public bool entry1;
    public bool entry2;


    private void Start()
    {
        chooseEntry = CraftingPanel.instance.chooseEntry;
    }

    public virtual bool Calculate(){return true;}

    public void OnPointerDown(PointerEventData eventData)
    {
        chooseEntry.SetActive(true);
        chooseEntry.GetComponent<ChooseEntry>().RegisterCaller(this);
    }

    public void SetValue(char entrie) 
    {
        switch (entrie)
        {
            case 'A':
                this.A = true;
                break;
            case 'B':
                this.B = true;
                break;
            case 'C':
                this.C = true;
                break;
            case 'D':
                this.D = true;
                break;
        }
    }
}
