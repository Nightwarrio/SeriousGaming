using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for the False Prefab. This will show up, when a LogicalGate is incorrect placed.
/// </summary>
public class False : MonoBehaviour
{
    public Text text;

    void Update()
    {
        Destroy(gameObject, 0.7f);
        text.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
    }
}
