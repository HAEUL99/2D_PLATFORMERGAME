using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Creating or Joining Room Canvas
public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingMenu _roomListingsMenu;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }

    public void LobbyBack() {
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       SceneManager.LoadScene("Main Menu");
    }

}
