using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogicalGatter : MonoBehaviour, IPointerDownHandler
{
    public GameObject chooseEntry;
    public bool needTwoLetters, needLetter1, needLetter2, needNoLetter; //Information gets from placeholder
    public Placeholder myPlaceholder; //Information gets from placeholder
    public bool haveLine; //Information gets from DrawLine-Child

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
        CountEnabledEnries();

        if (needNoLetter) return;

        chooseEntry.SetActive(true);
        chooseEntry.GetComponent<ChooseEntry>().RegisterCaller(this);
    }

    public virtual void SetEntry(char entry) 
    {
        CountEnabledEnries();

        if (needLetter1)
            SetEntrieOne(entry);

        else if (needLetter2)
            SetEntrieTwo(entry);

        else
        {
            if (enabledEntries < 1)
                SetEntrieOne(entry);
            else if (enabledEntries < 2)
                SetEntrieTwo(entry);
            else
            {
                enabledEntries = 0;
                SetEntrieOne(entry);
                myPlaceholder.SetEntry2(' ');
                entry2 = false;
            }
        }
    }

    #region privateFunctions
    private void SetEntrieOne(char entry)
    {
        entry1 = true;
        myPlaceholder.SetEntry1(entry);
    }

    private void SetEntrieTwo(char entry)
    {
        entry2 = true;
        myPlaceholder.SetEntry2(entry);
    }

    private void CountEnabledEnries()
    {
        if (entry1) enabledEntries++;
        if (entry2) enabledEntries++;
    }
    #endregion
}
