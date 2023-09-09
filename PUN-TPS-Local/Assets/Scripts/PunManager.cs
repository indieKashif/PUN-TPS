using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PunManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField userNameField;
    public TMP_InputField roomName;
    public TMP_InputField maxPlayers;

    public GameObject LoginPanel;
    public GameObject ConnectionPanel;
    public GameObject RoomListPanel;
    public GameObject CreateRoomPanel;


    // This method is called when the "Login" button is clicked.
    public void _LoginUser()
    {
        string Str_name = userNameField.text;

        if (!string.IsNullOrEmpty(Str_name))
        {
            Debug.Log("Name is valid.");
            // Set the local player's nickname to the entered username.
            PhotonNetwork.LocalPlayer.NickName = Str_name;
            // Connect to the Photon server using the specified settings.
            PhotonNetwork.ConnectUsingSettings();
            _ActivatePanel(ConnectionPanel.name);
           // LobbyPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Invalid input. Please enter a username.");
        }
    }

    public void _ActivatePanel(string PanelName)  //Checks GameObject if its name matches the value stored in the "PanelName" variable
    {
        LoginPanel.SetActive(PanelName.Equals(LoginPanel.name)); 
        ConnectionPanel.SetActive(PanelName.Equals(ConnectionPanel.name));
        RoomListPanel.SetActive(PanelName.Equals(RoomListPanel.name));
        CreateRoomPanel.SetActive(PanelName.Equals(CreateRoomPanel.name));
    }

    public void _CreateRoomClick()
    {
        string room_name = roomName.text;

        if (string.IsNullOrEmpty(room_name)) //if room id is empty then it will generate random number
        {
            room_name = room_name + Random.Range(0, 1000);
        }
        
            RoomOptions room_options = new RoomOptions(); 
            room_options.MaxPlayers = (byte)(int.Parse(maxPlayers.text)); //parsing bcuz roomoptions only store byte value
            PhotonNetwork.CreateRoom(room_name, room_options); //more arguments can be passed   
    }

    public void _CancelClick()
    {
        _ActivatePanel(RoomListPanel.name); //go back to lobby // disables the room panel
    }

    #region PUN_CALLBACKS
    // This method is called when the client successfully connects to the Photon server.
    public override void OnConnected()
    {
        Debug.Log("Connected to the Photon server!");
        _ActivatePanel(RoomListPanel.name);
    }
    // This method is called when the client successfully connects to the master Photon server.
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to the master server.");
    }
    // This method is called when the client successfully joins the room.
    public override void OnJoinedRoom()
    {
        Debug.Log("A Wild "+  PhotonNetwork.LocalPlayer.NickName + " Hopped into the Room");
    }
    // This method is called when the client successfully creates the room.
    public override void OnCreatedRoom()
    {
        Debug.Log(roomName.text + " has been created successfuly");
    }

    /*
    // Uncomment this Update method if you want to monitor the network status.
    void Update()
    {
        Debug.Log("Network Status: " + PhotonNetwork.NetworkClientState);
    }
    */
    #endregion







}
