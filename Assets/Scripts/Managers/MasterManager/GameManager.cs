using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;


public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    public GameObject[] obj;
    public int[] orderArray;

    // public int orderNum;
    private void Start()
    {

        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        //RPC_charRandomAssign(random)
    }
    /*
    public void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
            orderArray = RandomArray();
        base.photonView.RPC("RPC_RandomCharact", RpcTarget.All, PhotonNetwork.LocalPlayer, orderArray);


    }

    public int[] RandomArray()
    {
        int[] arr = { 1, 2, 3, 4 };
        System.Random random = new System.Random();
        arr = arr.OrderBy(x => random.Next()).ToArray();
        return arr;
    }



    [PunRPC]
    private void RPC_RandomCharact(Player player, int[] orderArray)
    {
        
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].charNum = orderArray[index];
        }
        
    }
*/
}
