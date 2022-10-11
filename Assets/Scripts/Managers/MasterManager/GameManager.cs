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
    
    public TMP_Text text;
    public TMP_Text text1;
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

            int[] array = (int[])photonEvent.CustomData;

            for (int i = 0; i < 4; i++)
            {
                Debug.Log($"array{i} : {array[i]}");
            }


            Dictionary<int, Photon.Realtime.Player> pList = Photon.Pun.PhotonNetwork.CurrentRoom.Players;



            foreach (KeyValuePair<int, Photon.Realtime.Player> p in pList)
            {

                Debug.Log($"PlayerId (not nickname) : {p.Value.ActorNumber}");

                _myCustomProperties["CharNum"] = array[p.Value.ActorNumber - 1];

                p.Value.CustomProperties = _myCustomProperties;


            }


            int num1 = (int)PhotonNetwork.LocalPlayer.CustomProperties["CharNum"];
            Debug.Log($"num1: {num1}");

            PhotonNetwork.Instantiate(obj[num1].name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);







        }
    }


}
