using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RandomCustomProperty : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetCustonNumber()
    {
        _myCustomProperties["RandomNumber"] = 0;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }
}
