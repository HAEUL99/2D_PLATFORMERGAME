using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerSpawnEvt : MonoBehaviourPun, IOnEventCallback
{
    public GameObject[] obj;
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 1)
        {
            int num1 = (int)PhotonNetwork.LocalPlayer.CustomProperties["CharNum"];
            PhotonNetwork.Instantiate(obj[num1].name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }
    }
    
}
