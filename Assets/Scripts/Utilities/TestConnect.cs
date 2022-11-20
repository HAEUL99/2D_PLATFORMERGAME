using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private LogIn logIn;

    void Start()
    {
        print("Connecting to server.");
        //this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 40;

        PhotonNetwork.AutomaticallySyncScene = true;

        // #Critical, we must first and foremost connect to Photon Online Server.
        PhotonNetwork.NickName = PlayerSetting.NickName;
        PhotonNetwork.GameVersion = "0.0.0";

        PhotonNetwork.ConnectUsingSettings();

    }

    //Called when the client is connected to the Master Server and ready for matchmaking and other tasks.
    public override void OnConnectedToMaster()
    {

        //Debug.Log("Connected to Photon.", this);
        //Debug.Log("My nickname is" + PhotonNetwork.LocalPlayer.NickName, this);

        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //Debug.Log("Disconnected from server for reason" + cause.ToString(), this);
       
    }

    public override void OnJoinedLobby()
    {
        //Debug.Log("Joined lobby");
    }
}
