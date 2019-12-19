using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsNumber : MonoBehaviour
{
    public Text text;
    public float lifetime = 0.3f;

    private float x = 0.007f;
    private float y = 0.007f;
    private float z = 0.007f;

    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.localScale += new Vector3(x, y, z);
        text.GetComponent<Text>().color = new Color(
            text.GetComponent<Text>().color.r, 
            text.GetComponent<Text>().color.g, 
            text.GetComponent<Text>().color.b, text.GetComponent<Text>().color.a-0.02f);
    }

}

