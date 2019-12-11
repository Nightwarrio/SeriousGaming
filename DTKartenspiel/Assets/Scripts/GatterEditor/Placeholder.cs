using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    public static Placeholder instance;

    private void Start()
    {
        if (instance == null) instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var image = gameObject.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var image = gameObject.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2156863f);
    }
}
