using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class GameManager : MonoBehaviour
{
    private NetworkManager manager;
    public static GameObject connectingPanel;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        if (scene.name.ToString().Equals("Menu"))
        {
            connectingPanel = GameObject.Find("ConnectingPanel");
            connectingPanel.SetActive(false);
            StartCoroutine(SetUpMenuSceneButtons());
        }
        else if (scene.name.ToString().Equals("Game"))
        {
            SetUpGameSceneButtons();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator SetUpMenuSceneButtons()
    {
        yield return new WaitForSeconds(0.5f);
        
        GameObject.Find("HostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HostButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
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
            // LAN Client + IP
            string ipAddress = GameObject.Find("HostInput").transform.Find("Text").GetComponent<Text>().text;
            if (string.IsNullOrEmpty(ipAddress))
                ipAddress = GameObject.Find("HostInput").transform.Find("Placeholder").GetComponent<Text>().text;
            manager.networkAddress = ipAddress;
            manager.StartClient();

            // Connecting
            if (NetworkClient.active)
            {
                //Debug.Log("Connecting to " + manager.networkAddress);
                connectingPanel.SetActive(true);

                GameObject.Find("ExitButton").GetComponent<Button>().onClick.RemoveAllListeners();
                GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(delegate ()
                {
                    manager.StopClient();
                    connectingPanel.SetActive(false);
                });
            }
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
            // Stop
            manager.StopHost();
        });
    }
}

