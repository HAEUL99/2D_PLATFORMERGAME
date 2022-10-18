using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public GameObject[] obj;
    
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

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
        if (photonEvent.Code == 0)
        {
            
            PhotonNetwork.Instantiate(obj[PhotonNetwork.LocalPlayer.ActorNumber -1].name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);


        }
    }


}
