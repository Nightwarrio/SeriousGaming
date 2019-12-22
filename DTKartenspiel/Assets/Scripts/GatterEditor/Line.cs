using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    public List<Image> pixels;
    public Image lastPixel, currentPixel, pixelPrefab;
    public DrawLine myManager;
    public bool hitSomething, allowToDraw, endDraw;

    void Start()
    {
        pixels = new List<Image>();
        AddPixel();
    }

    public Vector3 GetPosition()
    {
        return pixels[pixels.Count - 1].transform.position;
    }

    public void AddPixel()
    {
        currentPixel = Instantiate(pixelPrefab, Vector3.zero, Quaternion.identity);
        pixels.Add(currentPixel);
        currentPixel.transform.SetParent(transform);
        currentPixel.transform.position = Input.mousePosition;
    }
}
