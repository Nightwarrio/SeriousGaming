using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LogicalGate : MonoBehaviour, IPointerDownHandler
{
    public GameObject chooseEntry;
    public Placeholder myPlaceholder; //Information gets from placeholder

    public bool haveLineOutput = false;  // Information gets from DrawLine-Child
    public bool lettersAlright = false; //set by placeholder

    [Header("Entries")]
    public bool entry1;
    public bool entry2;

    /// <summary>
    /// If this Gatter canceld his request in the solutionPanel, the solutionPanel can block the caller,
    /// so that no every frame a request response
    /// </summary>
    public bool isBlocked = false; [HideInInspector]

    //proven by the placeholder
    //die muessen zu beginn true sein, da sonst das gate false/rot wird solange nur ein (richtiger) Eintrag gesetzt wurde
    public bool letter1Alright = true; [HideInInspector] 
    public bool letter2Alright = true; [HideInInspector] 

    private int enabledEntries = 0;
    private List<GameObject> myLineInputs;
    private bool gaveRequest;

    private void Start()
    {
        chooseEntry = CraftingPanel.instance.chooseEntry;
    }

    private void Update()
    {
        //giveRequest prevent to give an request every frame if we finished the Gate
        if (!gaveRequest && entry1 && entry2 && haveLineOutput)
            Completed();
        
        if(!isBlocked && gaveRequest && !lettersAlright) //a correct answer was removed
        {
            gaveRequest = false;
            SolutionPanel.instance.TakeBackGateCompleted(this);
        }
    }

    public virtual bool Calculate(){return true;}

    public void OnPointerDown(PointerEventData eventData)
    {
        //only opens, if we click at the center of the gatter
        if (Vector2.Distance(Input.mousePosition, transform.position) < 30f)
        {
            if (myPlaceholder.needNoLetter) return;

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

        /*if (Input.mousePosition.x < transform.position.x)
        {
            Debug.Log("I am in this case");
            //es wurde versucht ein Gatter zu veknüpfen welches weiter hinten liegt
            setLineCorrect = false;
        }*/
        if (Input.mousePosition.y >= transform.position.y) //We would reach entry1
        {
            if (myPlaceholder.needLetter2 || myPlaceholder.needNoLetter)
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
            if (myPlaceholder.needLetter1 || myPlaceholder.needNoLetter)
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

    /// <summary>
    /// Called by ChooseEntry when a letter is choosed
    /// </summary>
    /// <param name="entry">A, B, C or D</param>
    public virtual void SetEntry(char entry) 
    {
        if (myPlaceholder.needLetter1)
            SetEntrieOne(entry);

        else if (myPlaceholder.needLetter2)
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
            if (myPlaceholder.needTwoLetters) Destroy(l); //Keine lineInputs benötigt

            //Wenn beim lineInput der yWert der Position negativ ist, handelt es sich um den unteren lineInput
            else if (myPlaceholder.needLetter1 && l.transform.localPosition.y >= 0)
                Destroy(l);
            else if (myPlaceholder.needLetter2 && l.transform.localPosition.y < 0)
                Destroy(l);
        }
    }

    /// <summary>
    /// set the sprite to red 'r' or green 'g'
    /// also used by the placeholder
    /// Only set to green when the gate is completed!!
    /// </summary>
    public void SetColor(char c)
    {
        string gatterName = name.Substring(0, name.Length-7); //"(Clone)" have to be removed
        string color = gatterName; 
        switch (c)
        {
            case 'g':
                color = gatterName + "_GREEN";
                break;
            case 'r':
                color = gatterName + "_RED";
                break;
            default:
                Debug.Log(name + ": no such color " + c + " exists.");
                break;
        }

        foreach(Texture2D tex in GateEditorManager.instance.gateTextures)
        {
            if (tex.name.Contains(color))
            {
                Sprite tmp = CardManager.instance.TexToSprite(tex);
                GetComponent<Image>().sprite = tmp;
                break;
            }
        }
    }

    #region privateFunctions

    /// <summary>
    /// is called when the gatter is completet
    /// </summary>
    private void Completed()
    {
        if(myPlaceholder.needNoLetter || lettersAlright)
        {
            SolutionPanel.instance.GateCompleted();
            gaveRequest = true;
            SetColor('g'); //set color to green
        }
    }

    private List<GameObject> GetAllLineInputs()
    {
        List<GameObject> list = new List<GameObject>();
        foreach(Transform child in transform)
        {
            if (child.CompareTag("LineInput"))
                list.Add(child.gameObject);
        }
        return list;
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
