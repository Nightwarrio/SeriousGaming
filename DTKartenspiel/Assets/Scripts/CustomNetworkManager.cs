using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class CustomNetworkManager : NetworkManager
{

    public void HostButton()
    {
        NetworkManager.singleton.StartHost();
    }

    public void ConnectButton()
    {
        Debug.Log("Click Connect Button");
        string ipAddress = GameObject.Find("HostInput").transform.Find("Text").GetComponent<Text>().text;
        if (string.IsNullOrEmpty(ipAddress))
            ipAddress = GameObject.Find("HostInput").transform.Find("Placeholder").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;

        NetworkManager.singleton.StartClient();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if (scene.name.ToString().Equals("Menu"))
        {
            StartCoroutine(SetUpMenuSceneButtons());
        }
        else if (scene.name.ToString().Equals("Connecting"))
        {
            // do something
        }
        else if (scene.name.ToString().Equals("ConnectionError"))
        {
            SetUpConnectionErrorSceneButtons();
        }
        else if (scene.name.ToString().Equals("Game"))
        {
            SetUpGameSceneButtons();
        }
    }

    IEnumerator SetUpMenuSceneButtons()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("HostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("HostButton").GetComponent<Button>().onClick.AddListener(HostButton);

        GameObject.Find("ConnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ConnectButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Debug.Log("Click Connect Button");
            ConnectButton();

            if (!NetworkClient.isConnected)
            {
                Debug.Log("Connecting");
                SceneManager.LoadScene(1);
            }
        });
    }

    void SetUpConnectionErrorSceneButtons()
    {
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Debug.Log("Click Exit Button");
            ExitButton();
        });
        Debug.Log("Set Up Connection Error Scene Buttons");
    }

    void SetUpGameSceneButtons()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Debug.Log("Click Disconnect Button");
            NetworkManager.singleton.StopHost();
        });
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

