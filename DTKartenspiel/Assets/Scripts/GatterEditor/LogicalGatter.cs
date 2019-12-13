using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicalGatter : MonoBehaviour, IPointerDownHandler
{
    public GameObject chooseEntry;
    public bool firstPosition; //Information gets from placeholder
    public Placeholder myPlaceholder; //Information gets from placeholder

    [Header("Choices")]
    public bool A;
    public bool B;
    public bool C;
    public bool D;

    [Header("Entries")]
    public bool entry1;
    public bool entry2;

    private int enabledEntries = 0;

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

    public virtual void SetValue(char entrie) 
    {
        CountEnabledEnries();
        Debug.Log(enabledEntries);

        if (enabledEntries < 1)
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
            entry1 = true;
            myPlaceholder.SetEntry1(entrie);
        }
        else if (enabledEntries < 2)
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
            entry2 = true;
            myPlaceholder.SetEntry2(entrie);
        }
        else
        {
            enabledEntries = 0;

            switch (entrie)
            {
                case 'A':
                    this.A = true;
                    this.B = false;
                    this.C = false;
                    this.D = false;
                    break;
                case 'B':
                    this.A = false;
                    this.B = true;
                    this.C = false;
                    this.D = false;
                    break;
                case 'C':
                    this.A = false;
                    this.B = false;
                    this.C = true;
                    this.D = false;
                    break;
                case 'D':
                    this.A = false;
                    this.B = false;
                    this.C = false;
                    this.D = true;
                    break;
            }
            myPlaceholder.SetEntry1(entrie);
            myPlaceholder.SetEntry2(' ');
            entry2 = false;
        }
    }

    private void CountEnabledEnries()
    {
        if (entry1) enabledEntries++;
        if (entry2) enabledEntries++;
    }
}
