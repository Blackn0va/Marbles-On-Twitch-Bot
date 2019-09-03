namespace TwitchChatBot
{
    partial class frmHauptprogramm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHauptprogramm));
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.timerSendPlay = new System.Windows.Forms.Timer(this.components);
            this.lblHinweis = new System.Windows.Forms.Label();
            this.numCounter = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).BeginInit();
            this.SuspendLayout();
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
            this.rtbChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(962, 225);
            this.rtbChat.TabIndex = 6;
            this.rtbChat.Text = "";
            this.rtbChat.TextChanged += new System.EventHandler(this.RtbChat_TextChanged);
            // 
            // cmdVerbinden
            // 
            this.cmdVerbinden.Location = new System.Drawing.Point(24, 79);
            this.cmdVerbinden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdVerbinden.Name = "cmdVerbinden";
            this.cmdVerbinden.Size = new System.Drawing.Size(178, 102);
            this.cmdVerbinden.TabIndex = 2;
            this.cmdVerbinden.Text = "Verbinden";
            this.cmdVerbinden.UseVisualStyleBackColor = true;
            this.cmdVerbinden.Click += new System.EventHandler(this.CmdVerbinden_Click);
            // 
            // txtChannel1
            // 
            this.txtChannel1.Location = new System.Drawing.Point(116, 38);
            this.txtChannel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtChannel1.Name = "txtChannel1";
            this.txtChannel1.Size = new System.Drawing.Size(272, 31);
            this.txtChannel1.TabIndex = 1;
            this.txtChannel1.TextChanged += new System.EventHandler(this.TxtChannel1_TextChanged);
            // 
            // bgwBot1
            // 
            this.bgwBot1.WorkerSupportsCancellation = true;
            this.bgwBot1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwBot1_DoWork);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(634, 13);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(340, 31);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.TextChanged += new System.EventHandler(this.TxtUsername_TextChanged);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(634, 56);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtToken.Name = "txtToken";
            this.txtToken.PasswordChar = '*';
            this.txtToken.Size = new System.Drawing.Size(340, 31);
            this.txtToken.TabIndex = 5;
            this.txtToken.TextChanged += new System.EventHandler(this.TxtToken_TextChanged);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 79);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 102);
            this.button2.TabIndex = 3;
            this.button2.Text = "Trennen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CmdTrennen_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(548, 156);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(36, 25);
            this.lblCounter.TabIndex = 17;
            this.lblCounter.Text = "10";
            // 
            // timerSendPlay
            // 
            this.timerSendPlay.Enabled = true;
            this.timerSendPlay.Interval = 1000;
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
            this.numCounter.Location = new System.Drawing.Point(401, 113);
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
            // frmHauptprogramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 469);
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
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtChannel1);
            this.Controls.Add(this.cmdVerbinden);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1002, 479);
            this.Name = "frmHauptprogramm";
            this.Text = "Marbles on TwitchBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHauptprogramm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHauptprogramm_FormClosed);
            this.Load += new System.EventHandler(this.FrmHauptprogramm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Timer timerSendPlay;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.NumericUpDown numCounter;
    }
}

