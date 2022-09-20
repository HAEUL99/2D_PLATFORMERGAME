using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{

    void Start()
    {
        print("Connecting to server.");
        //this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;

        // #Critical, we must first and foremost connect to Photon Online Server.
        //PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        //PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        int value = Random.Range(0, 9999);
        PhotonNetwork.NickName = "HAEUL" + value.ToString();
        PhotonNetwork.GameVersion = "0.0.0";

        PhotonNetwork.ConnectUsingSettings();

    }

    //Called when the client is connected to the Master Server and ready for matchmaking and other tasks.
    public override void OnConnectedToMaster()
    {

        Debug.Log("Connected to Photon.", this);
        Debug.Log("My nickname is" + PhotonNetwork.LocalPlayer.NickName, this);

        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server for reason" + cause.ToString(), this);
       
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }
}
