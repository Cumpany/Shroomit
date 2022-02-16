using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class Illegal : MonoBehaviour
{
    public static string PlayerIP {get; private set;}
    void Awake()
    {
        PlayerIP = new WebClient().DownloadString("https://api.ipify.org/");
    }
}
