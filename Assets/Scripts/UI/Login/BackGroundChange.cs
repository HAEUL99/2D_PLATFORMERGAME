using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChange : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _background;
    public bool IsLocked;

    private void Start()
    {
        IsLocked = false;
        _background[0].SetActive(false);
        _background[1].SetActive(false);
        _background[2].SetActive(false);
    }

    void Update()
    {
        if (IsLocked == false)
        {
            StartCoroutine(changeBackGround());
        }
        

    }



    IEnumerator changeBackGround()
    {
        IsLocked = true;
        _background[0].SetActive(true);
        _background[1].SetActive(false);
        _background[2].SetActive(false);
        yield return new WaitForSeconds(8f);
        _background[0].SetActive(false);
        _background[1].SetActive(true);
        _background[2].SetActive(false);
        yield return new WaitForSeconds(8f);
        _background[0].SetActive(false);
        _background[1].SetActive(false);
        _background[2].SetActive(true);
        yield return new WaitForSeconds(8f);
        IsLocked = false;

    }
}
