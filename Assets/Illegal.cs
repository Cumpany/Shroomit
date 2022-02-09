using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class Illegal : MonoBehaviour
{
    public static string GetIPAddress()
    {
        string IPADDRESS = new WebClient().DownloadString("https://api.ipify.org/");
        return IPADDRESS;
    }
}
