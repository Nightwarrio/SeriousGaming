﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    public List<Image> pixels;
    public Image lastPixel, currentPixel, pixelPrefab;
    public DrawLine myManager;

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

    public void DestroyMe()
    {
        Debug.Log("Line: Try to Destroy me");
        foreach (var pixel in pixels)
            Destroy(pixel);
        Destroy(gameObject);
    }
}
