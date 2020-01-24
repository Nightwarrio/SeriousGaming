using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LogicalGatter : MonoBehaviour, IPointerDownHandler
{
    public GameObject chooseEntry;
    public bool needTwoLetters, needLetter1, needLetter2, needNoLetter; //Information gets from placeholder
    public Placeholder myPlaceholder; //Information gets from placeholder

    public bool haveLineOutput = false;  // Information gets from DrawLine-Child

    [Header("Entries")]
    public bool entry1;
    public bool entry2;

    private int enabledEntries = 0;
    private List<GameObject> myLineInputs;
    private bool gaveRequest;

    private void Start()
    {
        chooseEntry = CraftingPanel.instance.chooseEntry;
    }

    private void Update()
    {
        //giveRequest prevent to give an request every frame if we finished the gatter
        if (!gaveRequest && entry1 && entry2 && haveLineOutput)
            Completed();
    }

    public virtual bool Calculate(){return true;}

    public void OnPointerDown(PointerEventData eventData)
    {
        //only opens, if we click at the center of the gatter
        if (Vector2.Distance(Input.mousePosition, transform.position) < 30f)
        {
            if (needNoLetter) return;

            chooseEntry.SetActive(true);
            chooseEntry.GetComponent<ChooseEntry>().RegisterCaller(this);
        }
    }

    /// <summary>
    /// Return: Die Information darüber, ob ein Eingang gesetzt werden darf
    /// Gibt false zurück, wenn der Entry bereits durch eine andere Line belegt ist!
    /// Das NotGatter überschreibt diese Methode
    /// </summary>
    public virtual bool SetLineEntry()
    {
        bool setLineCorrect = false;

        if (Input.mousePosition.y >= transform.position.y) //We would reach entry1
        {
            //Debug.Log("I'm at position first entry");
            if (needLetter2 || needNoLetter)
            {
                if (!entry1) //entry1 ist false und somit noch nicht belegt
                {
                    entry1 = true;
                    setLineCorrect = true;
                }
            }
        }
        else if (Input.mousePosition.y < transform.position.y) //We would reach entry2
        {
            //Debug.Log("I'm at position second entry");
            if (needLetter1 || needNoLetter)
            {
                if (!entry2) //entry2 ist false und somit noch nicht belegt
                {
                    entry2 = true;
                    setLineCorrect = true;
                }
            }
        }
        return setLineCorrect;
    }

    public virtual void SetEntry(char entry) 
    {
        if (needLetter1)
            SetEntrieOne(entry);

        else if (needLetter2)
            SetEntrieTwo(entry);

        else
        {
            if (enabledEntries < 1)
                SetEntrieOne(entry);
            else if (enabledEntries == 1)
                SetEntrieTwo(entry);
            else //try to set a third entry 
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

    /// <summary>
    /// is called when the gatter is completet
    /// </summary>
    private void Completed()
    {
        SolutionPanel.instance.GatterCompleted();
        gaveRequest = true;
        SetColor('g'); //set color to green
    }

    /// <summary>
    /// set the sprite to red 'r' or green 'g'
    /// </summary>
    private void SetColor(char c)
    {
        string color = GetComponent<Image>().sprite.name;
        switch (c)
        {
            case 'g':
                color = GetComponent<Image>().sprite.name + "_GREEN";
                break;
            case 'r':
                color = GetComponent<Image>().sprite.name + "_RED";
                break;
            default:
                Debug.Log(name + ": no such color " + c + " exists.");
                break;
        }

        foreach (string s in FileReader.instance.gatterSprites)
        {
            if (s.Contains(color))
            {
                Sprite tmp = FileReader.instance.FileToSprite(s);
                GetComponent<Image>().sprite = tmp;
                break;
            }
        }
    }

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
        enabledEntries++;
        entry1 = true;
        myPlaceholder.SetEntry1(entry);
    }

    private void SetEntrieTwo(char entry)
    {
        enabledEntries++;
        entry2 = true;
        myPlaceholder.SetEntry2(entry);
    }
    #endregion
}
