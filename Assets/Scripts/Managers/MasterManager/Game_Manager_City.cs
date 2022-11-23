using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Game_Manager_City : MonoBehaviour
{
    public GameObject[] obj;
    public bool ischecked = false;




    public void Start()
    {
        StartCoroutine(Initiate());
    }

    IEnumerator Initiate()
    {

        yield return new WaitForSeconds(2f);
        Debug.Log("?");
        PhotonNetwork.Instantiate(obj[PhotonNetwork.LocalPlayer.ActorNumber - 1].name, gameObject.GetComponent<Transform>().position, Quaternion.identity, 0);
        Debug.Log("??");
    }

}
