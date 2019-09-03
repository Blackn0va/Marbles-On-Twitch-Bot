#region "Importdirektiven"
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchLib;
using TwitchChatBot;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Client;
namespace TwitchChatBot
#endregion
{
    public partial class frmHauptprogramm : Form
    {
        //Client erzeugen
        TwitchClient client;
        int i = 10;

        #region "Form initialisieren"
        public frmHauptprogramm()
        {
            InitializeComponent();

            //Threadfehler ignore
            CheckForIllegalCrossThreadCalls = false;

        }
        #endregion

        #region "Verbinden Klick"
        public void CmdVerbinden_Click(object sender, EventArgs e)
        {

            if (txtChannel1.Text != "")
            {
                bgwBot1.RunWorkerAsync();
            }


        }
        #endregion

        #region "Backgroundworker"
        public void BgwBot1_DoWork(object sender, DoWorkEventArgs e)
        {
            ConnectionCredentials credentials = new ConnectionCredentials(Marbles_On_Twitch_Bot.Properties.Settings.Default.Username, Marbles_On_Twitch_Bot.Properties.Settings.Default.Token);
            client = new TwitchClient();

            try
            {
                client.Initialize(credentials, txtChannel1.Text);

                client.OnMessageReceived += onMessageReceived; // Bei Erhalt einer Nachricht
                client.OnJoinedChannel += onJoin;
                client.OnConnectionError += ConnectionError;
                client.OnUserTimedout += OnTimed;


                if (client.IsConnected)
                {
                    client.Reconnect();
                     //Wenn eine verbindung besteht wird diese Getrennt und dann neu aufgebaut
                    lblVerbunden.ForeColor = Color.FromArgb(6, 244, 0); //Grün
                    lblVerbunden.Text = "Verbunden";
                }
                else
                {
                    //Verbindung neu Aufbauens
                    client.Connect();
                    lblVerbunden.ForeColor = Color.FromArgb(6, 244, 0); //Grün
                    lblVerbunden.Text = "Verbunden";

                }
            }
            catch
            {
            }
        }
        #endregion

        #region "On Events"
        private void onMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                //Chat Schreiben USERNAME --> NACHRICHT <--
                Invoke((MethodInvoker)delegate
                {
                    AppendText(this.rtbChat, Color.Blue, e.ChatMessage.Username + ": ");
                    AppendText(this.rtbChat, Color.Black, e.ChatMessage.Message + Environment.NewLine);

                    if (e.ChatMessage.Message.Contains("!play"))
                    {
                        i = i - 1;
                        lblCounter.Text = i.ToString();
                        if (i == 0)
                        {
                            i = 10;
                            lblCounter.Text = i.ToString();
                            client.SendMessage(e.ChatMessage.Channel, "!play");
                            rtbChat.AppendText("------ PLAY wurde gesendet ------" + Environment.NewLine);
                            txtStatus.Text = "!play wurde gesendet";
                            client.Disconnect();
                            lblVerbunden.ForeColor = Color.FromArgb(153, 0, 0); //Rot
                            lblVerbunden.Text = "Verbindung getrennt";
                            bgwBot1.CancelAsync();
                            bgwBot1.Dispose();
                            timeReconnect.Start();
                            GC.Collect();
                        }
                    }
                });
            }
            catch
            {

            }
        }

        private void OnTimed(object sender, OnUserTimedoutArgs e)
        {
            if (client.IsConnected == false)
            {
                try
                {
                     client.Connect();
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    client.Reconnect();
                 }
                catch
                {

                }

            }
        }
        private void ConnectionError(object sender, OnConnectionErrorArgs e)
        {
            txtStatus.Text = "FEHLER";
            if(client.IsConnected == false)
            {
                client.Connect();
            }
            else
            {
                client.Reconnect();
            }
        }

        private void onJoin(object sender, OnJoinedChannelArgs e)
        {
            txtStatus.Text = "Verbindung erfolgreich hergestellt";
        }

        private void onError2(object sender, OnConnectionErrorArgs e)
        {
            txtStatus.Text = "Fehler mit der Verbindung.. Verbindung wird neu hergestellt";
            //Neu Verbindens
        }
        #endregion

        #region "FormEvents"
        private void RtbChat_TextChanged(object sender, EventArgs e)
        {
            this.rtbChat.SelectionStart = rtbChat.Text.Length;
            this.rtbChat.ScrollToCaret();

        }
 


        private void FrmHauptprogramm_Load(object sender, EventArgs e)
        {
            txtChannel1.Text = Marbles_On_Twitch_Bot.Properties.Settings.Default.Channel;
            txtUsername.Text = Marbles_On_Twitch_Bot.Properties.Settings.Default.Username;
            txtToken.Text = Marbles_On_Twitch_Bot.Properties.Settings.Default.Token;
          
        }

        private void FrmHauptprogramm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Save();

        }

        private void FrmHauptprogramm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Save();
        }

        private void CmdTrennen_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.IsConnected)
                {
                    client.Disconnect();
                    lblVerbunden.ForeColor = Color.FromArgb(153, 0, 0); //Rot
                    lblVerbunden.Text = "Verbindung getrennt";
                    timeReconnect.Stop();

                }
                else
                {
                    lblVerbunden.ForeColor = Color.FromArgb(153, 0, 0); //Rot
                    lblVerbunden.Text = "Verbindung getrennt";
                    timeReconnect.Stop();

                }
            }
            catch
            {

            }

        }
        #endregion

        #region "Settings Speichern"
        private void TxtChannel1_TextChanged(object sender, EventArgs e)
        {
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Channel = txtChannel1.Text;
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Save();
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Username = txtUsername.Text;
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Save();
        }

        private void TxtToken_TextChanged(object sender, EventArgs e)
        {
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Token = txtToken.Text;
            Marbles_On_Twitch_Bot.Properties.Settings.Default.Save();
        }
        #endregion

        #region "Hyperlinks"
        private void LinkToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkToken.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://twitchtokengenerator.com/");
        }

        private void LinkDeveloper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LinkDeveloper.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.twitch.tv/8lackn0va");
        }
        #endregion

        #region "Timer"
        private void TimeReconnect_Tick(object sender, EventArgs e)
        {
            try
            {
                if (client.IsConnected == false)
                {
                    bgwBot1.RunWorkerAsync();
                    lblVerbunden.ForeColor = Color.FromArgb(6, 244, 0); //Rot
                    lblVerbunden.Text = "Verbindung hergestellt";
                    client.Connect();
                 }
                else
                {
                    lblVerbunden.ForeColor = Color.FromArgb(6, 244, 0); //Grün
                    lblVerbunden.Text = "Verbindung hergestellt";
                    try
                    {
                        bgwBot1.RunWorkerAsync();
                        client.Reconnect(); 
                     }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #region RTB ColorChange"
        void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0; // clear
        }
        #endregion
    }
}

 