using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PunManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField userNameField;

    // This method is called when the "Login" button is clicked.
    public void LoginUser()
    {
        string Str_name = userNameField.text;

        if (!string.IsNullOrEmpty(Str_name))
        {
            Debug.Log("Name is valid.");

            // Set the local player's nickname to the entered username.
            PhotonNetwork.LocalPlayer.NickName = Str_name;

            // Connect to the Photon server using the specified settings.
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Invalid input. Please enter a username.");
        }
    }

    // This method is called when the client successfully connects to the Photon server.
    public override void OnConnected()
    {
        Debug.Log("Connected to the Photon server!");
    }

    // This method is called when the client successfully connects to the master Photon server.
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to the master server.");
    }

    /*
    // Uncomment this Update method if you want to monitor the network status.
    void Update()
    {
        Debug.Log("Network Status: " + PhotonNetwork.NetworkClientState);
    }
    */
}
