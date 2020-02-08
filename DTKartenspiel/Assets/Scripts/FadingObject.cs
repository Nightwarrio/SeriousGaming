using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingObject : MonoBehaviour
{
    public Text text;
    public float lifetime = 1f;

    private float x = 0.007f;
    private float y = 0.007f;
    private float z = 0.007f;

    void Update()
    {
        if (CompareTag("PlayerName"))
            StartCoroutine(Wait(0.5f));
           
        else
            Fading();
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        Fading();
    }

    private void Fading()
    {
        Destroy(gameObject, lifetime);
        transform.localScale += new Vector3(x, y, z);
        text.GetComponent<Text>().color = new Color(
            text.GetComponent<Text>().color.r,
            text.GetComponent<Text>().color.g,
            text.GetComponent<Text>().color.b, text.GetComponent<Text>().color.a - 0.02f);
    }
}

