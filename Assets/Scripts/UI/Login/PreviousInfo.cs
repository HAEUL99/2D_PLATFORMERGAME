using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousInfo : MonoBehaviour
{
    public static PreviousInfo instancepreviousInfo;
    public int numOfImg;

    private void Awake()
    {
        instancepreviousInfo = this;
        numOfImg = 0;
        DontDestroyOnLoad(gameObject);
    }


}
