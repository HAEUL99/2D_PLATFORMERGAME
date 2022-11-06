using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChange : MonoBehaviour
{
    //public static BackGroundChange instanceDataImg;
    [SerializeField]
    private GameObject[] _background;
    public bool IsLocked;

    public int _firstImg;

    

    private void Start()
    {
        IsLocked = false;
        //numOfImg = 0;
        _background[0].SetActive(false);
        _background[1].SetActive(false);
        _background[2].SetActive(false);
        _firstImg = PreviousInfo.instancepreviousInfo.numOfImg;
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

        
        _background[_firstImg].SetActive(true);
        _background[(_firstImg + 1)%3].SetActive(false);
        _background[(_firstImg + 2) % 3].SetActive(false);
       
        yield return new WaitForSeconds(8f);
        PreviousInfo.instancepreviousInfo.numOfImg = (_firstImg + 1) % 3;

        _background[_firstImg].SetActive(false);
        _background[(_firstImg + 1) % 3].SetActive(true);
        _background[(_firstImg + 2) % 3].SetActive(false);
        
        yield return new WaitForSeconds(8f);
        PreviousInfo.instancepreviousInfo.numOfImg = (_firstImg + 1) % 3;

        _background[_firstImg].SetActive(false);
        _background[(_firstImg + 1) % 3].SetActive(false);
        _background[(_firstImg + 2) % 3].SetActive(true);
        
        yield return new WaitForSeconds(8f);
        PreviousInfo.instancepreviousInfo.numOfImg = (_firstImg + 1) % 3;
        IsLocked = false;

    }
}
