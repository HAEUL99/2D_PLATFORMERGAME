using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

//Creating or Joining Room Canvas
public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingMenu _roomListingsMenu;


    [SerializeField]
    private GameObject _createUI;
    [SerializeField]
    private GameObject _currentRoomCanvas;

    private RoomsCanvases _roomsCanvases;

    public void Start()
    {
        _createUI.SetActive(false);
        _currentRoomCanvas.SetActive(false);
    }

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }

    public void LobbyBack() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Main Menu");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
