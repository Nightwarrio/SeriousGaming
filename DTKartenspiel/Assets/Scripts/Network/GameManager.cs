using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class GameManager : MonoBehaviour
{
    NetworkManager manager;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
        if (scene.name.ToString().Equals("Menu"))
        {
            StartCoroutine(SetUpMenuSceneButtons());
        }
        else if (scene.name.ToString().Equals("Connecting"))
        {
            SetUpConnectingSceneButtons();
        }
        else if (scene.name.ToString().Equals("Game"))
        {
            SetUpGameSceneButtons();
        }
    }

    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator SetUpMenuSceneButtons()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("HostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HostButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //Debug.Log("Click Host Button");

            // LAN Host
            manager.StartHost();

            if (NetworkServer.active)
            {
                //Debug.Log("Server: active. Transport: " + Transport.activeTransport);
            }
        });

        GameObject.Find("ConnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ConnectButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Debug.Log("Click Connect Button");

            string ipAddress = GameObject.Find("HostInput").transform.Find("Text").GetComponent<Text>().text;
            if (string.IsNullOrEmpty(ipAddress))
                ipAddress = GameObject.Find("HostInput").transform.Find("Placeholder").GetComponent<Text>().text;
            manager.networkAddress = ipAddress;

            manager.StartClient();

            if (NetworkClient.active)
            {
                //Debug.Log("Connecting to " + manager.networkAddress);
                SceneManager.LoadScene(1);
            }
        });
    }

    void SetUpConnectingSceneButtons()
    {
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //Debug.Log("Click Exit Button");
            manager.StopClient();
            SceneManager.LoadScene(0);
        });
    }

    void SetUpGameSceneButtons()
    {
        if (NetworkClient.isConnected)
        {
            //Debug.Log("Client: address=" + manager.networkAddress);
        }

        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            //Debug.Log("Click Disconnect Button");
            manager.StopHost();
        });
    }
}

