using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class False : MonoBehaviour
{
    public Text text;
    private float lifetime = 0.7f;

    private float x = 0.01f;
    private float y = 0.01f;
    private float z = 0.01f;

    void Update()
    {
        Destroy(gameObject, lifetime);
        text.transform.localScale += new Vector3(x, y, z);
    }
}
