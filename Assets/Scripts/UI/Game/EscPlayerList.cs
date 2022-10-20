using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EscPlayerList : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Image _img;
    [SerializeField]
    private Sprite[] list;

    public string NickName { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        NickName = player.NickName;
        _text.text = player.NickName;
        _img.sprite = list[player.ActorNumber - 1];
            
    }

    
}
