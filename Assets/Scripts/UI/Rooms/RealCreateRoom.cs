using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RealCreateRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject _roomUI;
    //private int _themeNumber;
    public ChooseTheme _choosetheme;
    [SerializeField]
    private GameObject[] BiggerImg = new GameObject[4];
    [SerializeField]
    private GameObject WarnImg;

    public void OnClick_CreateRoomMenu()
    {
        if (_choosetheme._numTheme == 100)
        {
            WarnImg.SetActive(true);
        }
        else
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            options.CustomRoomProperties = new Hashtable() { { "Theme", _choosetheme._numTheme } };

            Debug.Log($"_choosetheme._numTheme: {_choosetheme._numTheme}");

            // default roomname = host name
            PhotonNetwork.JoinOrCreateRoom(PlayerSetting.NickName, options, TypedLobby.Default);

            // Debug.Log($"photonView.Owner.NickName: {photonView.Owner.NickName}");


        }


    }

    public void OnClick_Back()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            BiggerImg[i].SetActive(false);
        }

    }

    public override void OnCreatedRoom()
    {

        Debug.Log("Created room successfully.");
        _roomUI.SetActive(true);
        
        

    }

    public void Click_Ok()
    {
        WarnImg.SetActive(false);
    }


}
