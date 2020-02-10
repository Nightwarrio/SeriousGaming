using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for the PlaceholderPrefabs. This Class will prove, if the dropped Gate belongs to this Placeholder.
/// A specific Placeholder (OR, NOT, AND, XOR) has a generel Placeholder Object with this script.
/// The generel Placeholder Object has two Text UI Elements for the Input Letters.
/// The Placeholder have the Information how many Letters the assigned Gate needs.
/// </summary>
public class Placeholder : MonoBehaviour
{
    /// <summary>
    /// letter1 is on top and letter2 is the bottom position
    /// </summary>
    [Tooltip("Tell us how many letters this Placeholder needs for the Input. he Placeholder for NOT doesnt need any of them")] 
    public bool needTwoLetters, needLetter1, needLetter2, needNoLetter;

    [Tooltip("The UI Text Elements of the general Placeholder")] public Text entry1, entry2, notEntry;

    /// <summary>
    /// Set by the Developer!
    /// Have to be in Format "A" or "AB" <= without space or comma!
    /// </summary>
    public string expectedEntrie;

    /// <summary>
    /// The assigned Gate to this Placeholder. Can only assigned by the Player, by dragging a Gate to the Placeholder.
    /// </summary>
    private LogicalGate logicalGate = null;

    /// <summary>
    /// The Object wich collids with the Placeholder. Set by the OnTriggerFunction.
    /// </summary>
    private GameObject collisionObject;

    /// <summary>
    /// Proof if the Gate is dropped over the right Placeholder.
    /// </summary>
    /// <returns>False: There is already a Gate or it is the wrong Gate</returns>
    public bool RightPlace()
    {
        if (logicalGate != null) return false; //The Placeholder have alreday an assigned Gate
        return CompareTag(collisionObject.tag);
    }

    public void SetLogicalGate(GameObject logicalGate)
    {
        this.logicalGate = logicalGate.GetComponent<LogicalGate>();
        this.logicalGate.myPlaceholder = this;
        this.logicalGate.DestroyRedundantLineInputs();
        SnapGateToPosition();

        Destroy(gameObject.GetComponent<Image>()); //Remove the grey-colored Background
        Destroy(gameObject.GetComponent<BoxCollider2D>()); //remove this, to prevents NullException
    }

    /// <summary>
    /// Proof if the Letter is valid. 
    /// </summary>
    /// <param name="letter">The choosen Letter from the ChooseEntry</param>
    public void SetEntry1(char letter) //Called by the LogicalGate
    {
        entry1.GetComponent<Text>().text = letter.ToString();

        if (letter.ToString().Equals(entry2.GetComponent<Text>().text)) //two times the same letter
            logicalGate.SetGateToFalse();
        else
        {
            if (expectedEntrie.Contains(letter.ToString()))
                logicalGate.letter1Alright = true;
            else
                logicalGate.letter1Alright = false;

            CompareSolution(letter);
        }
    }

    /// <summary>
    /// Proof if the Letter is valid. 
    /// </summary>
    /// <param name="letter">The choosen Letter from the ChooseEntry</param>
    public void SetEntry2(char letter) //Called by the LogicalGate
    {
        entry2.GetComponent<Text>().text = letter.ToString();

        if (letter.ToString().Equals(entry1.GetComponent<Text>().text)) //two times the same letter
            logicalGate.SetGateToFalse();
        else
        {
            if (expectedEntrie.Contains(letter.ToString()))
                logicalGate.letter2Alright = true;
            else
                logicalGate.letter2Alright = false;

            CompareSolution(letter);
        } 
    }

    /// <summary>
    /// Proof if the Letter is valid. 
    /// </summary>
    /// <param name="letter">The choosen Letter from the ChooseEntry</param>
    public void SetNotEntry(char letter) //Called by the LogicalGate
    {
        notEntry.GetComponent<Text>().text = letter.ToString();
        CompareSolution(letter);
    }

    #region privateFunctions

    /// <summary>
    /// Called after a Letter is set. Compare the Letter with the expectedEntrie
    /// </summary>
    /// <param name="letter">The choosen Letter from the ChooseEntry</param>
    private void CompareSolution(char letter)
    {
        if (needTwoLetters)
        {
            if (!logicalGate.letter1Alright || !logicalGate.letter2Alright)
                logicalGate.SetGateToFalse();
            else if(logicalGate.letter1Alright && logicalGate.letter2Alright)
            {
                //Both Letters have to bet set!
                if (!entry1.GetComponent<Text>().text.Equals(' ') && !entry2.GetComponent<Text>().text.Equals(' '))
                    logicalGate.lettersAlright = true;
            }
        }
        else
        {
            if (expectedEntrie.Contains(letter.ToString()))
                logicalGate.lettersAlright = true;
            else
                logicalGate.SetGateToFalse();
        }
    }

    /// <summary>
    /// Makes a Hover-Effect by changing the Color and set the Placeholder to the GateChoice
    /// </summary>
    /// <param name="collision">The recognized collisonObject</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
        collisionObject.GetComponent<GateChoice>().SetChoosenPlaceholder(this);

        var image = gameObject.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    /// <summary>
    /// Makes a Hover-Effect by changing the Color
    /// </summary>
    /// <param name="collision">The recognized collisonObject</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.GetComponent<Image>() != null)
        {
            var image = gameObject.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2156863f);
        }
    }

    /// <summary>
    /// Set Gate in the center of the Placeholder, so that the entries are visible
    /// </summary>
    private void SnapGateToPosition()
    {
        logicalGate.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 10f, 
            gameObject.transform.position.y, 0);
    }
    #endregion
}
