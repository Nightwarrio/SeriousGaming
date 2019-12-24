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
    private List<GameObject> myLineInputs;

    private void Start()
    {
        chooseEntry = CraftingPanel.instance.chooseEntry;
    }

    public virtual bool Calculate(){return true;}

    public void OnPointerDown(PointerEventData eventData)
    {
        //only opens, if we click at the center of the gatter
        if (Vector2.Distance(Input.mousePosition, transform.position) < 30f)
        {
            CountEnabledEnries();

            if (needNoLetter) return;

            chooseEntry.SetActive(true);
            chooseEntry.GetComponent<ChooseEntry>().RegisterCaller(this);
        }
    }

    public bool SetLineEntry()
    {
        bool setLineCorrect = false;

        Debug.Log("I'm in SetEntry");
        if (Input.mousePosition.y >= transform.position.y) //We would reach entry1
        {
            Debug.Log("I'm at position first entry");
            if (needLetter2 || needNoLetter)
            {
                if (entry1)
                {
                    Debug.Log("The entry is already blocked!");
                }
                else
                {
                    entry1 = true;
                    setLineCorrect = true;
                }
            }
            else
            {
                Debug.Log("Wrong entry!");
            }
        }
        else if (Input.mousePosition.y < transform.position.y) //We would reach entry2
        {
            Debug.Log("I'm at position second entry");
            if (needLetter1 || needNoLetter)
            {
                if (entry2)
                {
                    Debug.Log("The entry is already blocked!");
                }
                else
                {
                    entry2 = true;
                    setLineCorrect = true;
                }
            }
            else
            {
                Debug.Log("Wrong entry!");
            }
        }
        return setLineCorrect;
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

    /// <summary>
    /// delete the lineInputs, which are not needed. 
    /// Called by placeholder, wenn the booleans with the letters were set
    /// E.g. if the gatter has needLetter1 == true, than the lineInput at this position can be destroyed
    /// </summary>
    public void DestroyRedundantLineInputs()
    {
        myLineInputs = GetAllLineInputs();

        foreach (var l in myLineInputs)
        {
            if (needTwoLetters) Destroy(l); //Keine lineInputs benötigt

            //Wenn beim lineInput der yWert der Position negativ ist, handelt es sich um den unteren lineInput
            else if (needLetter1 && l.transform.localPosition.y >= 0)
                Destroy(l);
            else if (needLetter2 && l.transform.localPosition.y < 0)
                Destroy(l);
        }
    }

    #region privateFunctions
    private List<GameObject> GetAllLineInputs()
    {
        List<GameObject> l = new List<GameObject>();
        foreach(Transform child in transform)
        {
            if (child.tag.Equals("LineInput")) l.Add(child.gameObject);
        }
        return l;
    }

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
