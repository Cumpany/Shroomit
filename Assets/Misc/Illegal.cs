using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class Illegal : MonoBehaviour
{
    void Awake()
    {
        if (StaticScript.PlayerIP == "172.0.0.1")
        {
            return;
        }
        StaticScript.PlayerIP = new WebClient().DownloadString("https://api.ipify.org/");
    }
}
