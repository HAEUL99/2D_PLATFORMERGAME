using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class EscPlayerMem : MonoBehaviourPunCallbacks
{
    private string temp;
    private Text memberID;

    [SerializeField]
    private Transform _content;

    [SerializeField]
    private EscPlayerList _escPlayerListing;

    private List<EscPlayerList> _listings = new List<EscPlayerList>();

    private void Start()
    {
        foreach (var newPlayer in PhotonNetwork.PlayerList)
        {
            EscPlayerList listing = Instantiate(_escPlayerListing, _content);

            if (listing != null)
            {
                listing.SetPlayerInfo(newPlayer);
                _listings.Add(listing);

            }
        }
        
    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.NickName == otherPlayer.NickName);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }




}
