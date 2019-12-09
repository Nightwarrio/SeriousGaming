using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public static Task instance;

    private void Start()
    {
        if (instance == null) instance = this;
    }

    public void SetSprite(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        this.GetComponent<Image>().sprite = sprite;
    }
}
