using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class CustomizedNetworkManager : NetworkManager {

    public InputField inputIPAdress;

	public void StartupHost() {
        SetPort();
        singleton.StartHost();
    }

    public void JoinGame() {
        SetIPAddress();
        SetPort();
        singleton.StartClient();
    }

    public void DisconnectGame() {
        singleton.StopHost();
    }

    void SetPort() {
        singleton.networkPort = 7777;
    }

    void SetIPAddress() {
        string ipAddress = "localhost";
        if(inputIPAdress) {
            ipAddress = inputIPAdress.text;
        }
        singleton.networkAddress = ipAddress;
    }

    /*void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        GameObject inputField = GameObject.Find("InputField");
        if (inputField) {
            inputIPAdress = inputField.GetComponent<InputField>();
        } else {
            Debug.Log("No input field for IP address found!");
        }
    }*/
}
