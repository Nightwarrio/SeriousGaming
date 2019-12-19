using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsNumber : MonoBehaviour
{
    public Text damageText;
    public float lifetime = 0.3f;

    private float x = 0.01f;
    private float y = 0.01f;
    private float z = 0.01f;

    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.localScale += new Vector3(x, y, z);
        damageText.GetComponent<Text>().color = new Color(
            damageText.GetComponent<Text>().color.r, 
            damageText.GetComponent<Text>().color.g, 
            damageText.GetComponent<Text>().color.b, damageText.GetComponent<Text>().color.a-0.02f);
    }

}

