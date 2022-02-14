using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class Illegal : MonoBehaviour
{
    private static string IPADDRESS = new WebClient().DownloadString("https://api.ipify.org/");
    public static string GetIPAddress()
    {
        return IPADDRESS;
    }
}
