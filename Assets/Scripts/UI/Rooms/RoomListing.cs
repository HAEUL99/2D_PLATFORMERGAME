using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;
using Photon.Pun;
using UnityEngine.EventSystems;

public class RoomListing : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private GameObject _img;
    [SerializeField]
    private TextMeshProUGUI _theme;
    [SerializeField]
    private TextMeshProUGUI _numOfPlayer;
    public int themeName;
    public int currentNum;
    public int maxNum;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.Name;
        themeName = (int)roomInfo.CustomProperties["Theme"];
        currentNum = roomInfo.PlayerCount;
        maxNum = roomInfo.MaxPlayers;


    }



    public void OnEnable()
    {
       

        _img.SetActive(false);

    }
    public void OnClick_Button()
    {

        FindObjectOfType<AudioManager>().Play("clickbtn"); 
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {

        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        Debug.Log($"themeName: {themeName}");
        
        Debug.Log($"{currentNum} / { maxNum }");
        switch (themeName)
        {
            case 0:
                _theme.text = "Forest";
                break;
            case 1:
                _theme.text = "City";
                break;
        }

        _numOfPlayer.text = $"{currentNum} / { maxNum }";
        _img.SetActive(true);

    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        _img.SetActive(false);

    }
}
