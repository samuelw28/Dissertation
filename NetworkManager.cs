using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Text serverText;
    public Text signText;

    //Starts the connection process
    void Start()
    {
        ConnectToServer();
    }

    //Attempts to connect to the server
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        serverText.text = "Connecting to server...";
    }

    //Initializes the server
    public override void OnConnectedToMaster()
    {
        serverText.text = "Connected";
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    //Confirms that a room has been joined
    public override void OnJoinedRoom()
    {
        serverText.text = "Joined a Room";
        base.OnJoinedRoom();
    }

    //Notifies when a new user joins the room
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        serverText.text = "New User Joined";
        base.OnPlayerEnteredRoom(newPlayer);
    }

    //Notifies when a new user leaves the room
    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        serverText.text = "User disconnected";
        base.OnPlayerLeftRoom(newPlayer);
    }
}
