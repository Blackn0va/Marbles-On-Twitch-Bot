using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchChatBot;
using TwitchLib.Client;
using TwitchLib.Communication.Interfaces;

namespace TwitchChatBot
{
    class Verbindung
    {
        TwitchClient client2;

        private void test()
        {
            try
            {
                client2 = new TwitchClient();

                client2.Initialize(credentials, "elozyn");


                client2.OnMessageReceived += onMessageReceived2; // Bei Erhalt einer Nachricht



                if (client2.IsConnected)
                {
                    //Wenn eine verbindung besteht wird diese Getrennt und dann neu aufgebaut

                    client2.Disconnect();
                    client2.Connect();
                }
                else
                {
                    //Verbindung neu Aufbauens
                    client2.Connect();

                }
            }
            catch
            {
            }
        }
    }
}
