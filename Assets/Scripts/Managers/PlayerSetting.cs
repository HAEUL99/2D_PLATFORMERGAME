using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSetting 
{
    //nickname + random number
    private static string _fullnickName;
    public static string FullNickName { get { return _fullnickName; } set { _fullnickName = value; } }


    //only nickname
    private static string _nickName;
    public static string NickName { get { return _nickName; } set { _nickName = value; } }

   // public static GameObject LocalPlayerInstance;


    
}
