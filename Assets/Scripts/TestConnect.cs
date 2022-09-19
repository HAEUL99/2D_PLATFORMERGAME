using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

    }


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
        Debug.Log("Jointed lobby");
    }
}
