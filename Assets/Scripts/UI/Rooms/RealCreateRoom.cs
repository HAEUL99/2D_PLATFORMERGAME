using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RealCreateRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    public GameObject _roomUI;
    [SerializeField]
    private GameObject _creatRoomMenu;
    //private int _themeNumber;
    public ChooseTheme _choosetheme;
    [SerializeField]
    public GameObject _createRoombtn;
    [SerializeField]
    public GameObject _closedUIbtn;

    [SerializeField]
    private GameObject WarnImg;
    //private ArrayList sceneList = new ArrayList();

    [SerializeField]
    private ChooseTheme chooseTheme;
    [SerializeField]
    private Sprite[] change_img = new Sprite[2];
    private Image startImg;

    public int GameCount = 0;


    private void Start()
    {
        WarnImg.SetActive(false);

    }

    public void OnClick_CreateRoomMenu()
    {
        if (_choosetheme._numTheme == 100)
        {
            //gameObject.SetActive(false);

            WarnImg.SetActive(true);
            _createRoombtn.SetActive(false);

            _closedUIbtn.SetActive(false);

        }
        else
        {
            
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            //options.CustomRoomProperties = new Hashtable() { { "Theme", _choosetheme._numTheme } };
            //sceneList.Add(_choosetheme._numTheme);
 
            
            // default roomname = host name
            PhotonNetwork.JoinOrCreateRoom(PlayerSetting.NickName, options, TypedLobby.Default);

            // Debug.Log($"photonView.Owner.NickName: {photonView.Owner.NickName}");

            //string[] Property = new string[] { "Password" };
            string[] LobbyOptions = new string[] { "Theme", "NumOfPlay" };
            options.CustomRoomPropertiesForLobby = LobbyOptions;
            options.CustomRoomProperties = new Hashtable() { { "Theme", _choosetheme._numTheme }, { "NumOfPlay", GameCount } };

            //string[] PlayCountOptions = new string[] { "NumOfPlay" };
            //options.CustomRoomPropertiesForLobby = PlayCountOptions;
           // options.CustomRoomProperties = new Hashtable() { { "NumOfPlay", GameCount } };


        }




    }

    public void OnClick_Back()
    {
        //gameObject.SetActive(false);

        // _creatRoomMenu.SetActive(true);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Game Scenes/Lobby");
    }

    public override void OnCreatedRoom()
    {
        gameObject.SetActive(false);
        _roomUI.SetActive(true);
        
        

    }

    public void Click_Ok()
    {
        WarnImg.SetActive(false);
        _createRoombtn.SetActive(true);

        _closedUIbtn.SetActive(true);

        
    }


}
