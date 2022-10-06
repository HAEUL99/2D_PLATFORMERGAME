using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public Player Player { get; private set; }
    public bool Ready = false;
    public int charNum;

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        //int result = (int)player.CustomProperties["RandomNumebr"];
        _text.text = player.NickName;

   

        //_text.text = PlayerSetting.NickName;
    }
}
