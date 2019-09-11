using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;

namespace Marbles_On_Twitch_Bot
{
    public class InvokeThreadSafeForm : System.Windows.Forms.Form
    {
        TwitchClient client;
        int i = 0;
 
        #region "Deklarationen f. Form"
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Button cmdVerbinden;
        internal System.Windows.Forms.TextBox txtChannel1;
        private System.ComponentModel.BackgroundWorker bgwBot1;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.LinkLabel linkToken;
        private System.Windows.Forms.LinkLabel LinkDeveloper;
        private System.Windows.Forms.Timer timeReconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVerbunden;
        private System.Windows.Forms.Button cmdTrennen;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Timer timerControll;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.NumericUpDown numCounter;
        private System.Windows.Forms.Label lblViewer;
        private System.Windows.Forms.Label lblViewerCounter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region "Form Initialisieren"
        public InvokeThreadSafeForm()
        {
            InitializeComponent();
            timerControll.Start();
            timeReconnect.Stop();
            txtChannel1.Text = Marbles_On_Twitch_Bot.Properties.Settings.Default.Channel;
            txtUsername.Text = Marbles_On_Twitch_Bot.Properties.Settings.Default.Username;
            txtToken.Text = Marbles_On_Twitch_Bot.Properties.Settings.Default.Token;


            (txtChannel1).TextChanged += new EventHandler(TxtChannel1_TextChanged);
            (txtUsername).TextChanged += new EventHandler(TxtUsername_TextChanged);
            (txtToken).TextChanged += new EventHandler(TxtToken_TextChanged);

        }
        #endregion

        #region "bgw Initialisierung"
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
        #endregion

        #region "Klick Verbinden / Trennen"
        private void cmdVerbinden_Click(System.Object sender, System.EventArgs e)
        {
            InitializeBackgroundWorker();
            backgroundWorker1.RunWorkerAsync();
        }

        private void cmdTrennen_Click(System.Object sender, System.EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
        }
        #endregion

        #region "Bgw DoWork"
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
     
            ConnectionCredentials credentials = new ConnectionCredentials(Marbles_On_Twitch_Bot.Properties.Settings.Default.Username, Marbles_On_Twitch_Bot.Properties.Settings.Default.Token);
            client = new TwitchClient();
            
            try
            {
                i = (int)numCounter.Value; 
                client.Initialize(credentials, txtChannel1.Text);
                client.OnMessageReceived += onMessageReceived; // Bei Erhalt einer Nachricht
                 client.OnJoinedChannel += onJoin;
                client.OnConnectionError += ConnectionError;
                client.OnChatCommandReceived += OnChatCommandReceived;
  


                //Verbindung neu Aufbauens
                client.Connect();
                lblVerbunden.ForeColor = Color.FromArgb(6, 244, 0); //Grün
                lblVerbunden.Text = "Verbunden";
            }
            catch
            {
            }
        }
        #endregion

        #region "bgw RunWorkerComplete"
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        #endregion

        #region "bgw ProgressChanged"
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        #endregion

        #region "On Timer Tick"
        private void TimeReconnect_Tick(object sender, EventArgs e)
        {
            i = (int)numCounter.Value;
 
            Invoke((MethodInvoker)delegate
            {
                lblCounter.Text = i.ToString();
            });
            timeReconnect.Stop();
        }
        #endregion

        #region "RTB Autoscroll"
        private void rtbChat_TextChanged(object sender, EventArgs e)
        {
            this.rtbChat.SelectionStart = rtbChat.Text.Length;
            this.rtbChat.ScrollToCaret();
        }
        #endregion

        #region "On NumValue Changed"
        private void NumCounter_ValueChanged(object sender, EventArgs e)
        {
            lblCounter.Text = numCounter.Value.ToString();
        }
        #endregion

 

        #region "On ChatCommandReceived"
        private void OnChatCommandReceived(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText)
            {
                case "play":
                    i = i - 1;

                    Invoke((MethodInvoker)delegate
                    {
                        lblCounter.Text = i.ToString();
                    });
                     break;
            }
        }
        #endregion

        #region "On Message Received"
        private void onMessageReceived(object sender, OnMessageReceivedArgs e)
        {
                //Chat Schreiben USERNAME --> NACHRICHT <--
                Invoke((MethodInvoker)delegate
                {
                    AppendText(this.rtbChat, Color.Blue, e.ChatMessage.Username + ": ");
                    AppendText(this.rtbChat, Color.Black, e.ChatMessage.Message + Environment.NewLine);
                });

                if (i == 0)
                {
                    // Play in den Chat senden.
                    client.SendMessage(e.ChatMessage.Channel, "!play");
                }


        }
        #endregion

        #region "On ConnectionError"
        private void ConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                txtStatus.ForeColor = Color.FromArgb(153,0,0); //Grün
                txtStatus.Text = "Verbindung beendet";
            });
        }
        #endregion

        #region "On Join"
        private void onJoin(object sender, OnJoinedChannelArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                txtStatus.ForeColor = Color.FromArgb(6, 244, 0); //Grün
                txtStatus.Text = "Verbindung erfolgreich hergestellt";
            });
        }
        #endregion

        #region "On Error"
        private void onError2(object sender, OnConnectionErrorArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                txtStatus.ForeColor = Color.FromArgb(152,0,0); //Grün
                txtStatus.Text = "Fehler mit der Verbindung.. Verbindung wird neu hergestellt";
            });
        }
        #endregion

        #region "Timer Kontrolle"
        private void TimerControll_Tick(object sender, EventArgs e)
        {
            if (i < 0)
            {
                timeReconnect.Start();
            }
        }
        #endregion

        #region "Append TextBox"
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

        #region "Windows Form Designer generated code"
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvokeThreadSafeForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.cmdVerbinden = new System.Windows.Forms.Button();
            this.txtChannel1 = new System.Windows.Forms.TextBox();
            this.bgwBot1 = new System.ComponentModel.BackgroundWorker();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.linkToken = new System.Windows.Forms.LinkLabel();
            this.LinkDeveloper = new System.Windows.Forms.LinkLabel();
            this.timeReconnect = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblVerbunden = new System.Windows.Forms.Label();
            this.cmdTrennen = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.timerControll = new System.Windows.Forms.Timer(this.components);
            this.lblHinweis = new System.Windows.Forms.Label();
            this.numCounter = new System.Windows.Forms.NumericUpDown();
            this.lblViewer = new System.Windows.Forms.Label();
            this.lblViewerCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(26, 10);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(112, 10);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(1140, 25);
            this.txtStatus.TabIndex = 1;
            // 
            // rtbChat
            // 
            this.rtbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChat.Enabled = false;
            this.rtbChat.Location = new System.Drawing.Point(12, 200);
            this.rtbChat.Margin = new System.Windows.Forms.Padding(4);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(962, 225);
            this.rtbChat.TabIndex = 6;
            this.rtbChat.Text = "";
            this.rtbChat.TextChanged += new System.EventHandler(this.rtbChat_TextChanged);
            // 
            // cmdVerbinden
            // 
            this.cmdVerbinden.Location = new System.Drawing.Point(24, 79);
            this.cmdVerbinden.Margin = new System.Windows.Forms.Padding(4);
            this.cmdVerbinden.Name = "cmdVerbinden";
            this.cmdVerbinden.Size = new System.Drawing.Size(178, 102);
            this.cmdVerbinden.TabIndex = 2;
            this.cmdVerbinden.Text = "Verbinden";
            this.cmdVerbinden.UseVisualStyleBackColor = true;
            this.cmdVerbinden.Click += new System.EventHandler(this.cmdVerbinden_Click);
            // 
            // txtChannel1
            // 
            this.txtChannel1.Location = new System.Drawing.Point(116, 38);
            this.txtChannel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtChannel1.Name = "txtChannel1";
            this.txtChannel1.Size = new System.Drawing.Size(272, 31);
            this.txtChannel1.TabIndex = 1;
            // 
            // bgwBot1
            // 
            this.bgwBot1.WorkerSupportsCancellation = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(634, 13);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(340, 31);
            this.txtUsername.TabIndex = 4;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(634, 56);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtToken.Name = "txtToken";
            this.txtToken.PasswordChar = '*';
            this.txtToken.Size = new System.Drawing.Size(340, 31);
            this.txtToken.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(512, 17);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(116, 25);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Username:";
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(548, 58);
            this.lblToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(78, 25);
            this.lblToken.TabIndex = 12;
            this.lblToken.Text = "Token:";
            // 
            // linkToken
            // 
            this.linkToken.AutoSize = true;
            this.linkToken.Location = new System.Drawing.Point(630, 94);
            this.linkToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkToken.Name = "linkToken";
            this.linkToken.Size = new System.Drawing.Size(156, 25);
            this.linkToken.TabIndex = 13;
            this.linkToken.TabStop = true;
            this.linkToken.Text = "get your Token";
            this.linkToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkToken_LinkClicked);
            // 
            // LinkDeveloper
            // 
            this.LinkDeveloper.AutoSize = true;
            this.LinkDeveloper.Location = new System.Drawing.Point(630, 119);
            this.LinkDeveloper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkDeveloper.Name = "LinkDeveloper";
            this.LinkDeveloper.Size = new System.Drawing.Size(157, 25);
            this.LinkDeveloper.TabIndex = 14;
            this.LinkDeveloper.TabStop = true;
            this.LinkDeveloper.Text = "Visit Developer";
            this.LinkDeveloper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkDeveloper_LinkClicked);
            // 
            // timeReconnect
            // 
            this.timeReconnect.Enabled = true;
            this.timeReconnect.Interval = 60000;
            this.timeReconnect.Tick += new System.EventHandler(this.TimeReconnect_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Channel:";
            // 
            // lblVerbunden
            // 
            this.lblVerbunden.Location = new System.Drawing.Point(634, 162);
            this.lblVerbunden.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerbunden.Name = "lblVerbunden";
            this.lblVerbunden.Size = new System.Drawing.Size(340, 37);
            this.lblVerbunden.TabIndex = 16;
            // 
            // cmdTrennen
            // 
            this.cmdTrennen.Location = new System.Drawing.Point(208, 79);
            this.cmdTrennen.Margin = new System.Windows.Forms.Padding(4);
            this.cmdTrennen.Name = "cmdTrennen";
            this.cmdTrennen.Size = new System.Drawing.Size(178, 102);
            this.cmdTrennen.TabIndex = 3;
            this.cmdTrennen.Text = "Trennen";
            this.cmdTrennen.UseVisualStyleBackColor = true;
            this.cmdTrennen.Click += new System.EventHandler(this.cmdTrennen_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(566, 156);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(36, 25);
            this.lblCounter.TabIndex = 17;
            this.lblCounter.Text = "10";
            // 
            // timerControll
            // 
            this.timerControll.Enabled = true;
            this.timerControll.Interval = 20;
            this.timerControll.Tick += new System.EventHandler(this.TimerControll_Tick);
            // 
            // lblHinweis
            // 
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(396, 154);
            this.lblHinweis.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(158, 25);
            this.lblHinweis.TabIndex = 18;
            this.lblHinweis.Text = "Send Play on : ";
            // 
            // numCounter
            // 
            this.numCounter.Location = new System.Drawing.Point(400, 113);
            this.numCounter.Margin = new System.Windows.Forms.Padding(4);
            this.numCounter.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numCounter.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCounter.Name = "numCounter";
            this.numCounter.Size = new System.Drawing.Size(120, 31);
            this.numCounter.TabIndex = 19;
            this.numCounter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCounter.ValueChanged += new System.EventHandler(this.NumCounter_ValueChanged);
            // 
            // lblViewer
            // 
            this.lblViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViewer.AutoSize = true;
            this.lblViewer.Location = new System.Drawing.Point(416, 435);
            this.lblViewer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblViewer.Name = "lblViewer";
            this.lblViewer.Size = new System.Drawing.Size(83, 25);
            this.lblViewer.TabIndex = 20;
            this.lblViewer.Text = "Viewer:";
            // 
            // lblViewerCounter
            // 
            this.lblViewerCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViewerCounter.Location = new System.Drawing.Point(512, 433);
            this.lblViewerCounter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblViewerCounter.Name = "lblViewerCounter";
            this.lblViewerCounter.Size = new System.Drawing.Size(240, 33);
            this.lblViewerCounter.TabIndex = 21;
            // 
            // InvokeThreadSafeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 469);
            this.Controls.Add(this.lblViewerCounter);
            this.Controls.Add(this.lblViewer);
            this.Controls.Add(this.numCounter);
            this.Controls.Add(this.lblHinweis);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblVerbunden);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinkDeveloper);
            this.Controls.Add(this.linkToken);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.cmdTrennen);
            this.Controls.Add(this.txtChannel1);
            this.Controls.Add(this.cmdVerbinden);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(992, 450);
            this.Name = "InvokeThreadSafeForm";
            this.Text = "Marbles on TwitchBot";
            this.Load += new System.EventHandler(this.InvokeThreadSafeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region "STA Thread"
        [STAThread]
        static void Main()
        {
            Application.Run(new InvokeThreadSafeForm());
        }
        #endregion

        #region "Hyperlinks Klicked"
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

        private void InvokeThreadSafeForm_Load(object sender, EventArgs e)
        {
            timerControll.Start();
        }
    }
}