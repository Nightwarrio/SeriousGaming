using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Creats a Line by string Pixels together.
/// </summary>
public class Line : MonoBehaviour
{
    [Tooltip("The Pixel Prefab")] public Image pixelPrefab;

    /// <summary>
    /// The Pixels which represents the Line
    /// </summary>
    [HideInInspector] public List<Image> pixels;

    /// <summary>
    /// The Corrsponding DrawLineScript to the Line
    /// </summary>
    [HideInInspector] public DrawLine myManager;

    /// <summary>
    /// The last added Pixel to the Line
    /// </summary>
    private Image currentPixel;

    void Start()
    {
        pixels = new List<Image>();
        AddPixel();
    }

    /// <summary>
    /// Get Position of the last added Pixel
    /// </summary>
    /// <returns>Position of the last Pixel</returns>
    public Vector3 GetPosition()
    {
        return pixels[pixels.Count - 1].transform.position;
    }

    /// <summary>
    /// Add a Pixel at the Endo of the Line
    /// </summary>
    public void AddPixel()
    {
        currentPixel = Instantiate(pixelPrefab, Vector3.zero, Quaternion.identity);
        pixels.Add(currentPixel);
        currentPixel.transform.SetParent(transform);
        currentPixel.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Destroy all Pixels of the Line and the Line itself
    /// </summary>
    public void DestroyMe()
    {
        foreach (var pixel in pixels)
            Destroy(pixel);
        Destroy(gameObject);
    }
}