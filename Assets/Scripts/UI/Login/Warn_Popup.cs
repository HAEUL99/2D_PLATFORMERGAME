using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warn_Popup : MonoBehaviour
{
    [SerializeField]
    GameObject _accounttxt;

    public void Click_OK()
    {
        gameObject.SetActive(false);
        _accounttxt.SetActive(true);
    }
}
