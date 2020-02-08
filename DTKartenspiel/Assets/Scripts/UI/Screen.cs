using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public UI UI
    {
        get => default;
        set
        {
        }
    }

    public virtual void CloseScreen()
    {
        gameObject.SetActive(false);
    }

    public virtual void ShowScreen()
    {
        gameObject.SetActive(true);
    }
}
