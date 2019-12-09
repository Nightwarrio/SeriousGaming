using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicalGatter : MonoBehaviour, IPointerDownHandler
{
    [Header("Choices")]
    public bool A;
    public bool B;
    public bool C;
    public bool D;

    [Header("Entrys")]
    public bool entryNotGatter;
    public bool entry1;
    public bool entry2;

    private GameObject chooseEntry;

    private void Start()
    {
        this.chooseEntry = CraftingPanel.instance.chooseEntry;
    }

    private void Update()
    {
        if (chooseEntry.gameObject.activeInHierarchy && chooseEntry.GetComponent<ChooseEntry>().SetCheckmark())
            CheckEntry();
    }

    public virtual bool Calculate(){return true;}

    public void OnPointerDown(PointerEventData eventData)
    {
        chooseEntry.SetActive(true);
    }

    public void CheckEntry()
    {
        char checkedValue = chooseEntry.GetComponent<ChooseEntry>().CheckedValue();
        chooseEntry.GetComponent<ChooseEntry>().RefreshToogle();
        chooseEntry.SetActive(false);
        switch (checkedValue)
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
