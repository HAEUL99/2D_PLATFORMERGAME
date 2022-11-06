using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject _createUI;


    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }


    public void OnClick_TryCreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        OnCreateUI();

        //CreateRoom
        //JoinOrCreateRoom


    }

    public void OnCreateUI()
    {
        _createUI.SetActive(true);
        gameObject.SetActive(false);

    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message);
    }

    public void OnClick_Back()
    {
        SceneManager.LoadScene("Lobby");

    }
}
