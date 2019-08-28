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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHauptprogramm));
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.cmdVerbinden = new System.Windows.Forms.Button();
            this.txtChannel1 = new System.Windows.Forms.TextBox();
            this.cmdTrennen = new System.Windows.Forms.Button();
            this.bgwBot1 = new System.ComponentModel.BackgroundWorker();
            this.bgwBot2 = new System.ComponentModel.BackgroundWorker();
            this.bgwBot3 = new System.ComponentModel.BackgroundWorker();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(93, 9);
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
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(962, 226);
            this.rtbChat.TabIndex = 6;
            this.rtbChat.Text = "";
            this.rtbChat.TextChanged += new System.EventHandler(this.RtbChat_TextChanged);
            // 
            // cmdVerbinden
            // 
            this.cmdVerbinden.Location = new System.Drawing.Point(34, 78);
            this.cmdVerbinden.Name = "cmdVerbinden";
            this.cmdVerbinden.Size = new System.Drawing.Size(156, 102);
            this.cmdVerbinden.TabIndex = 2;
            this.cmdVerbinden.Text = "Verbinden";
            this.cmdVerbinden.UseVisualStyleBackColor = true;
            this.cmdVerbinden.Click += new System.EventHandler(this.CmdVerbinden_Click);
            // 
            // txtChannel1
            // 
            this.txtChannel1.Location = new System.Drawing.Point(34, 39);
            this.txtChannel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChannel1.Name = "txtChannel1";
            this.txtChannel1.Size = new System.Drawing.Size(340, 31);
            this.txtChannel1.TabIndex = 1;
            this.txtChannel1.Text = "Vooshy";
            this.txtChannel1.TextChanged += new System.EventHandler(this.TxtChannel1_TextChanged);
            // 
            // cmdTrennen
            // 
            this.cmdTrennen.Location = new System.Drawing.Point(196, 78);
            this.cmdTrennen.Name = "cmdTrennen";
            this.cmdTrennen.Size = new System.Drawing.Size(156, 102);
            this.cmdTrennen.TabIndex = 3;
            this.cmdTrennen.Text = "Trennen";
            this.cmdTrennen.UseVisualStyleBackColor = true;
            this.cmdTrennen.Click += new System.EventHandler(this.CmdTrennen_Click);
            // 
            // bgwBot1
            // 
            this.bgwBot1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwBot1_DoWork);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(634, 14);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(340, 31);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.TextChanged += new System.EventHandler(this.TxtUsername_TextChanged);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(634, 55);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(116, 25);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Username:";
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(549, 58);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(78, 25);
            this.lblToken.TabIndex = 12;
            this.lblToken.Text = "Token:";
            // 
            // frmHauptprogramm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 438);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1012, 509);
            this.Name = "frmHauptprogramm";
            this.Text = "Marbles on TwitchBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHauptprogramm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHauptprogramm_FormClosed);
            this.Load += new System.EventHandler(this.FrmHauptprogramm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Button cmdVerbinden;
        internal System.Windows.Forms.TextBox txtChannel1;
        private System.Windows.Forms.Button cmdTrennen;
        private System.ComponentModel.BackgroundWorker bgwBot1;
        private System.ComponentModel.BackgroundWorker bgwBot2;
        private System.ComponentModel.BackgroundWorker bgwBot3;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblToken;
    }
}

