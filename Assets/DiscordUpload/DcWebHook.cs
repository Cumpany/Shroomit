using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Specialized;
using System.Net;

public class DcWebHook: IDisposable
    {
        private readonly WebClient dWebClient;
        private static NameValueCollection discordValues = new NameValueCollection();
        public string WebHook { get; set;}
        public string UserName { get; set; }
        public string ProfilePicture { get; set;}

        public DcWebHook()
        {
            dWebClient = new WebClient();
        }
      

        public void SendMessage(string msgSend)
        {
            discordValues.Add("username", UserName);
            discordValues.Add("avatar_url", ProfilePicture);
            discordValues.Add("content", msgSend);

            dWebClient.UploadValues("https://discord.com/api/webhooks/942747547800305724/ctHcf1DSlEbkzuU61bpP1pAvHEAa_tNycmr9vruwhCOzuHvdfIJB8AsiNKWbH5M9X1X-", discordValues);
        }

        public void Dispose()
        {
            dWebClient.Dispose();
        }
    }