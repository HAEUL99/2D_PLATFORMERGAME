using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveRoomMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _createRoomMenu;
    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        //_roomsCanvases.CurrentRoomCanvas.Hide();
        //_createRoomMenu.SetActive(true);
        SceneManager.LoadScene("Game Scenes/Lobby");
    }

    
}
