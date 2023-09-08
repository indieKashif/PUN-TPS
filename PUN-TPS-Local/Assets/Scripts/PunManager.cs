using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PunManager : MonoBehaviourPun
{
    public TMP_InputField userNameField;

    public void LoginUser(){

        string Str_name = userNameField.text;
        if (!string.IsNullOrEmpty(Str_name))
        {
            Debug.Log("Name is ok");
            PhotonNetwork.LocalPlayer.NickName = Str_name;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Invalid Input");
        }
    }

    
    private void OnConnectedToServer()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName  + "Connected To Server");

    }

    private void OnFailedToConnect()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName  + "Failed To Connect");
    }

    private void OnPlayerConnected()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName  + "Player Connected");
    }




    void Update()
    {
        Debug.Log("Net Status: " + PhotonNetwork.NetworkClientState);
       
    }



}
