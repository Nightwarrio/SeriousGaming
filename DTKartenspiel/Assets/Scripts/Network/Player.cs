using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Mirror.NetworkBehaviour
{
    public GameObject playerCamera;

    void Start()
    {
        if (isLocalPlayer)
        {
            playerCamera.SetActive(true);
        }
        else
        {
            playerCamera.SetActive(false);
        }
    }
    void Update()
    {
        if (isLocalPlayer)
        {
            // Test
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A");
                this.transform.Translate(Vector3.up * Time.deltaTime * 3.0f);
            }
        }
    }
}
