using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Linq;
using System;
using ExitGames.Client.Photon;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private PlayerListing _playerListing;

    [SerializeField]
    private TextMeshProUGUI _readyUpText;
    [SerializeField]
    private GameObject ReadyBtn;
    [SerializeField]
    private GameObject GameStartBtn;
    [SerializeField]
    private GameObject _settingsBtn;
    [SerializeField]
    private GameObject _settingUI;
    /*
    [SerializeField]
    private TextMeshProUGUI _readyUpText;
    */
    public List<PlayerListing> _listings = new List<PlayerListing>();
    private RoomsCanvases _roomsCanvases;
    private bool _ready = false;
    string nameOfTheme;
    int numOfTheme;


    public void ShowUIEachPlayer()
    {
        ReadyBtn.SetActive(false);
        GameStartBtn.SetActive(false);
        _settingUI.SetActive(false);
        _settingsBtn.SetActive(false);

        if (PhotonNetwork.IsMasterClient == true)
        {

            GameStartBtn.SetActive(true);
            //ReadyBtn.SetActive(false);
            //_settingsBtn.SetActive(true);
        }
        else
        {

            ReadyBtn.SetActive(true);
            

            
        }

        

    }

    public override void OnEnable()
    {
        
        base.OnEnable();

        ShowUIEachPlayer();


        GetCurrentRoomPlayer();
        SetReadyUp(false);
        
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listings.Count; i++)
            Destroy(_listings[i].gameObject);

        _listings.Clear();
    }

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    private void SetReadyUp(bool state)
    {
        _ready = state;
        if (_ready)
        {
            _readyUpText.text = "Ready";
            _readyUpText.color = Color.green;
        }
        else
        {
            _readyUpText.text = "Not Ready";
            _readyUpText.color = Color.red;
        }
    }



    private void GetCurrentRoomPlayer()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
        
    }

    private void AddPlayerListing(Player player)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].SetPlayerInfo(player);

            /*
            _myCustomProperties["RandomNumber"] = RandomArray;
            PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
            */
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListing, _content);

            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listings.Add(listing);
                /*
                _myCustomProperties["RandomNumber"] = 0;
                PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;*/
            }
        }
        
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }

    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < _listings.Count; i++)
            {
                if (_listings[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if (!_listings[i].Ready)
                        return;
                }
            }


            // Prevent other users from participating in the game anymore.
            PhotonNetwork.CurrentRoom.IsOpen = false;
            // This room is no longer visible on the room list.
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.EnableCloseConnection = true;

            numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];


            //int numOfTheme = (int)PhotonNetwork.CurrentRoom.CustomProperties["Theme"];
            

            //_numTheme = 0 rabbit
            //_numTheme = 1 City
            //_numTheme = 2 Fox
            //_numTheme = 3 medieval
            switch (numOfTheme)
            {
                case 0:
                    nameOfTheme = "Forest";
                    break;
                case 1:
                    nameOfTheme = "City";
                    break;

                    /*
                case 2:
                    nameOfTheme = "Fox";
                    break;
                case 3:
                    nameOfTheme = "Medieval";
                    break;

                    */
            }
            
            PhotonNetwork.LoadLevel($"Game Scenes/{nameOfTheme}");


            /*
            System.Random random = new System.Random();
            for (int i = 0; i < 4; i++)
            {

                arrayList[i] = i;
            }

            //[2, 0, 3, 1]

            arrayList = arrayList.OrderBy(x => random.Next()).ToArray();

            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(0, raiseEventOptions, SendOptions.SendReliable);
            */


        }

        

    }
    
    
    public void OnClick_Settings()
    {
        _settingUI.SetActive(true);

    }

    public void OnClick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!_ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);

        }

    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].Ready = ready;
        }
    }

}
