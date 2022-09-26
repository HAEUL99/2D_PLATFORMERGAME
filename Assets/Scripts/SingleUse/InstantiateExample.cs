using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class InstantiateExample : MonoBehaviourPun
{
    [SerializeField]
    private GameObject _prefab;

    
    private void Start()
    {
        PhotonNetwork.Instantiate(this._prefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);

    }
}
