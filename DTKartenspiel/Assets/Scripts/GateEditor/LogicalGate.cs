using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// The Root Class of all LogicalGates!
/// </summary>
public abstract class LogicalGate : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public GameObject chooseEntry;
    [HideInInspector] public bool entry1;
    [HideInInspector] public bool entry2;
    [HideInInspector] public Placeholder myPlaceholder; //Information gets from placeholder
    [HideInInspector] public bool haveLineOutput = false;  // Information gets from DrawLine-Child
    [HideInInspector] public bool lettersAlright = false; //set by placeholder

    /// <summary>
    /// If this Gatter canceld his request in the solutionPanel, the solutionPanel can block the caller,
    /// so that no every frame a request response
    /// </summary>
    [HideInInspector] public bool isBlocked = false;

    //proven by the placeholder
    //die muessen zu beginn true sein, da sonst das gate false/rot wird solange nur ein (richtiger) Eintrag gesetzt wurde
    [HideInInspector] public bool letter1Alright = true;
    [HideInInspector] public bool letter2Alright = true; 

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

    public virtual bool Calculate(){return true; }  // Not even used. Can be implement for Extensions.

    /// <summary>
    /// If the player clicked near the Gate, the ChooseEntry opens and the Caller will be assigned to it.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        float radius = 30f;
        if (UnityEngine.Screen.width <= 1200)
            radius = 40f;

        //only opens, if we click at the center of the gatter
        if (Vector2.Distance(Input.mousePosition, transform.position) < radius)
        {
            if (myPlaceholder.needNoLetter) return;

            chooseEntry.SetActive(true);
            chooseEntry.GetComponent<ChooseEntry>().RegisterCaller(this);
        }
    }

    /// <summary>
    /// Proof if the Line can be set at this Position. False, is there is already a Line or there have to be a letterInput.
    /// </summary>
    /// <returns>The Permission if the Line can be drawn</returns>
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
                if (!entry1) //entry1 is false => not yet taken
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
                if (!entry2) //entry2 is false => not yet taken
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
    /// <param name="entry">The choosen Letter</param>
    public virtual void SetEntry(char entry) 
    {
        if (myPlaceholder.needLetter1)
            SetEntrieOne(entry);

        else if (myPlaceholder.needLetter2)
            SetEntrieTwo(entry);

        else //two Letters are needed
        {
            if (enabledEntries < 1)
                SetEntrieOne(entry);
            else if (enabledEntries == 1)
                SetEntrieTwo(entry);
            else //try to set a third entry will reset the other entries
            {
                enabledEntries = 0;
                SetEntrieOne(entry);

                myPlaceholder.SetEntry2(' ');
                entry2 = false;
            }
        }
    }

    /// <summary>
    /// Delete the lineInputs, which are not needed. 
    /// Called by Placeholder.
    /// E.g. if the gatter has needLetter1 == true, than the lineInput at this position can be destroyed
    /// </summary>
    public void DestroyRedundantLineInputs()
    {
        myLineInputs = GetAllLineInputs();

        foreach (var lInput in myLineInputs)
        {
            if (myPlaceholder.needTwoLetters) Destroy(lInput); //No lineInputs were needed

            //If the y-Value of the lineInput is < 0, then it is the lower lineInput
            else if (myPlaceholder.needLetter1 && lInput.transform.localPosition.y >= 0)
                Destroy(lInput);

            else if (myPlaceholder.needLetter2 && lInput.transform.localPosition.y < 0)
                Destroy(lInput);
        }
    }

    /// <summary>
    /// set the sprite to red 'r' or green 'g'
    /// also used by the placeholder
    /// Only set to green when the gate is completed!!
    /// </summary>
    /// <param name="c">The choosen Color</param>
    public void SetColor(char c)
    {
        string gatterName = name.Substring(0, name.Length-7); //"(Clone)" have to be removed
        string color = gatterName; 
        switch (c) //Find the right Color
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
            if (tex.name.Contains(color)) //Find the correspondig Sprite to the Color
            {
                Sprite tmp = CardManager.instance.TexToSprite(tex);
                GetComponent<Image>().sprite = tmp;
                break;
            }
        }
    }

    /// <summary>
    /// Called if a Gate is not correct solved
    /// </summary>
    public void SetGateToFalse()
    {
        lettersAlright = false;
        SetColor('r');

        //Gate can allready send an Response to the SolutionPanel
        if (isBlocked)
            isBlocked = false;
    }

    #region privateFunctions

    /// <summary>
    /// Called when the Gate is completet. Allowed to give a Request to the SolutionPanel
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
