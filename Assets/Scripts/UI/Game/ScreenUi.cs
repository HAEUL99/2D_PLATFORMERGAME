using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUi : MonoBehaviourPunCallbacks
{
    private List<EscPlayerList> _listings = new List<EscPlayerList>();

    [SerializeField]
    private Sprite[] _list;

    [SerializeField]
    private GameObject[] PlayersImg;

    [SerializeField]
    private GameObject[] Playerstxt;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayersImg[i].SetActive(false);

        }
        int count = 0;
        foreach (var newPlayer in PhotonNetwork.PlayerList)
        {
            
            PlayersImg[count].SetActive(true);
            PlayersImg[count].GetComponent<Image>().sprite = _list[newPlayer.ActorNumber - 1];
            Playerstxt[count].GetComponent<TextMeshProUGUI>().text = newPlayer.NickName;
            count++;

        }

    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        for (int i = 0; i < 4; i++)
        {
            PlayersImg[i].SetActive(false);
         
        }
        int count = 0;
        foreach (var newPlayer in PhotonNetwork.PlayerList)
        {
            PlayersImg[count].SetActive(true);
            PlayersImg[count].GetComponent<Image>().sprite = _list[newPlayer.ActorNumber - 1];
            Playerstxt[count].GetComponent<TextMeshProUGUI>().text = newPlayer.NickName;
            count++;

        } 
    }
}
