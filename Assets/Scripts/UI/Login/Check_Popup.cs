using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Popup : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _noticetxt;
    [SerializeField]
    private GameObject _accouttxt;

    public void OnClick_Yes()
    {
        FindObjectOfType<AudioManager>().Play("clickbtn");
        Invoke("sceneLoad", 0.3f);
        
    }

    void sceneLoad()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnClcik_No()
    {
        FindObjectOfType<AudioManager>().Play("clickbtn");
        gameObject.SetActive(false);
        _accouttxt.SetActive(true);
    }

    public void OnClick_Close()
    {
        FindObjectOfType<AudioManager>().Play("clickbtn");
        gameObject.SetActive(false);
        _accouttxt.SetActive(true);
    }
}
