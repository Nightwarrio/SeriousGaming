using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    /// <summary>
    /// Tell us how many letters we need for entry, or input are only output of an other Gate
    /// letter1 is on top and letter2 is the bottom position 
    /// </summary>
    public bool needTwoLetters, needLetter1, needLetter2, needNoLetter;
    /// <summary>
    /// Have to be in Format "A" or "AB" <= without space or comma!
    /// </summary>
    public string expectedEntrie;


    [HideInInspector]  public GameObject collisionObject;
    [HideInInspector]  public Text entry1, entry2, notEntry;

    private GameObject logicalGate = null;

    public bool RightPlace()
    {
        if (logicalGate != null) return false; //placeholder ist bereits belegt
        return CompareTag(collisionObject.tag);
    }

    public void SetLogicalGate(GameObject logicalGate)
    {
        this.logicalGate = logicalGate;
        logicalGate.GetComponent<LogicalGate>().myPlaceholder = this;
        logicalGate.GetComponent<LogicalGate>().DestroyRedundantLineInputs();
        SnapGateToPosition();

        Destroy(gameObject.GetComponent<Image>()); //die graue Hinterlegung entfernen
        Destroy(gameObject.GetComponent<BoxCollider2D>()); //without we get an nullPointerException
    }

    //Called by the LogicalGate
    public void SetEntry1(char letter)
    {
        entry1.GetComponent<Text>().text = letter.ToString();

        if (letter.ToString() == entry2.GetComponent<Text>().text) //zweimal der gleiche Buchstabe gesetzt
            SetGateToFalse();
        else
            CompareSolution(letter);
    }
    public void SetEntry2(char letter)
    {
        entry2.GetComponent<Text>().text = letter.ToString();

        if (letter.ToString() == entry1.GetComponent<Text>().text) //zweimal der gleiche Buchstabe gesetzt
            SetGateToFalse();
        else
            CompareSolution(letter);
    }
    public void SetNotEntry(char letter)
    {
        notEntry.GetComponent<Text>().text = letter.ToString();
        CompareSolution(letter);
    }

    #region privateFunctions
    private void CompareSolution(char letter)
    {
        if (expectedEntrie.Contains(letter.ToString()))
            logicalGate.GetComponent<LogicalGate>().lettersAlright = true;
        else
            SetGateToFalse();
    }

    /// <summary>
    /// called if a Gate is not correct solved
    /// </summary>
    private void SetGateToFalse()
    {
        logicalGate.GetComponent<LogicalGate>().lettersAlright = false;
        logicalGate.GetComponent<LogicalGate>().SetColor('r');

        //Falls das Gate bereits einen Response zurückgenommen hatte, darf es das jetzt wieder tun
        if (logicalGate.GetComponent<LogicalGate>().isBlocked)
            logicalGate.GetComponent<LogicalGate>().isBlocked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
        collisionObject.GetComponent<GateChoice>().SetChoosenPlaceholder(this);

        var image = gameObject.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.GetComponent<Image>() != null)
        {
            var image = gameObject.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2156863f);
        }
    }

    /// <summary>
    /// set Gate in the center of the placeholder, so that the entries are visible
    /// </summary>
    private void SnapGateToPosition()
    {
        logicalGate.transform.position = new Vector3(gameObject.transform.position.x + 10f, gameObject.transform.position.y, 0);
    }
    #endregion
}
