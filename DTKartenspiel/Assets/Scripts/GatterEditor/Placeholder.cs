using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    /// <summary>
    /// Tell us how many letters we need for entry, or input are only output of an other gatter
    /// </summary>
    public bool needTwoLetters, needLetter1, needLetter2, needNoLetter; 

    public GameObject collisionObject;
    public Text entry1, entry2, notEntry;

    private GameObject logicalGatter = null;

    public bool RightPlace()
    {
        if (logicalGatter != null) return false; //placeholder ist bereits belegt
        return gameObject.tag == collisionObject.tag;
    }

    public void SetLogicalGatter(GameObject logicalGatter)
    {
        this.logicalGatter = logicalGatter;
        logicalGatter.GetComponent<LogicalGatter>().myPlaceholder = this;
        SetEntryType(); //set how mayn letters the gatter needs
        logicalGatter.GetComponent<LogicalGatter>().DestroyRedundantLineInputs();
        SnapGatterToPosition();

        Destroy(gameObject.GetComponent<Image>()); //die graue Hinterlegung entfernen
        Destroy(gameObject.GetComponent<BoxCollider2D>()); //without we get an nullPointerException
    }

    public void SetEntry1(char letter)
    {
        entry1.GetComponent<Text>().text = letter.ToString();
    }
    public void SetEntry2(char letter)
    {
        entry2.GetComponent<Text>().text = letter.ToString();
    }
    public void SetNotEntry(char letter)
    {
        notEntry.GetComponent<Text>().text = letter.ToString();
    }

    #region privateFunctions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
        collisionObject.GetComponent<GatterChoice>().SetChoosenPlaceholder(this);

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
    /// set Gatter in the center of the placeholder, so that the entries are visible
    /// </summary>
    private void SnapGatterToPosition()
    {
        logicalGatter.transform.position = new Vector3(gameObject.transform.position.x + 10f, gameObject.transform.position.y, 0);
    }

    /// <summary>
    /// Set the entry type to the logicalGatter
    /// </summary>
    private void SetEntryType()
    {
        logicalGatter.GetComponent<LogicalGatter>().needNoLetter = needNoLetter;
        logicalGatter.GetComponent<LogicalGatter>().needLetter1 = needLetter1;
        logicalGatter.GetComponent<LogicalGatter>().needLetter2 = needLetter2;
        logicalGatter.GetComponent<LogicalGatter>().needTwoLetters = needTwoLetters;
    }
    #endregion
}
