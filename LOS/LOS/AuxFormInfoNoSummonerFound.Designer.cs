namespace LOS
{
    partial class AuxFormInfoNoSummonerFound
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuxFormInfoNoSummonerFound));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnNewSummonerName = new System.Windows.Forms.Button();
            this.btnNewAPIKey = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxSummonerName = new System.Windows.Forms.TextBox();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOK.Location = new System.Drawing.Point(56, 173);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Retry";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseEnter += new System.EventHandler(this.btnOK_MouseEnter);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseHover += new System.EventHandler(this.btnOK_MouseHover);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExit.Location = new System.Drawing.Point(174, 173);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMessage.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMessage.Location = new System.Drawing.Point(25, 50);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(270, 71);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Seems like LoL API returned an error. Are you sure you provided a valid API key a" +
    "nd summoner name?";
            // 
            // btnNewSummonerName
            // 
            this.btnNewSummonerName.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnNewSummonerName.FlatAppearance.BorderSize = 0;
            this.btnNewSummonerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSummonerName.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNewSummonerName.Location = new System.Drawing.Point(224, 111);
            this.btnNewSummonerName.Name = "btnNewSummonerName";
            this.btnNewSummonerName.Size = new System.Drawing.Size(59, 25);
            this.btnNewSummonerName.TabIndex = 6;
            this.btnNewSummonerName.Text = "Change";
            this.btnNewSummonerName.UseVisualStyleBackColor = false;
            this.btnNewSummonerName.Click += new System.EventHandler(this.btnNewSummonerName_Click);
            this.btnNewSummonerName.MouseEnter += new System.EventHandler(this.btnNewSummonerName_MouseEnter);
            this.btnNewSummonerName.MouseLeave += new System.EventHandler(this.btnNewSummonerName_MouseLeave);
            this.btnNewSummonerName.MouseHover += new System.EventHandler(this.btnNewSummonerName_MouseHover);
            // 
            // btnNewAPIKey
            // 
            this.btnNewAPIKey.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnNewAPIKey.FlatAppearance.BorderSize = 0;
            this.btnNewAPIKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAPIKey.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNewAPIKey.Location = new System.Drawing.Point(224, 137);
            this.btnNewAPIKey.Name = "btnNewAPIKey";
            this.btnNewAPIKey.Size = new System.Drawing.Size(59, 25);
            this.btnNewAPIKey.TabIndex = 7;
            this.btnNewAPIKey.Text = "Change";
            this.btnNewAPIKey.UseVisualStyleBackColor = false;
            this.btnNewAPIKey.Click += new System.EventHandler(this.btnNewAPIKey_Click);
            this.btnNewAPIKey.MouseEnter += new System.EventHandler(this.btnNewAPIKey_MouseEnter);
            this.btnNewAPIKey.MouseLeave += new System.EventHandler(this.btnNewAPIKey_MouseLeave);
            this.btnNewAPIKey.MouseHover += new System.EventHandler(this.btnNewAPIKey_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(12, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(49, 14);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "LOS Info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxSummonerName
            // 
            this.tbxSummonerName.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbxSummonerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSummonerName.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxSummonerName.Location = new System.Drawing.Point(36, 127);
            this.tbxSummonerName.Name = "tbxSummonerName";
            this.tbxSummonerName.ReadOnly = true;
            this.tbxSummonerName.Size = new System.Drawing.Size(194, 23);
            this.tbxSummonerName.TabIndex = 11;
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbxApiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxApiKey.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxApiKey.Location = new System.Drawing.Point(36, 150);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.ReadOnly = true;
            this.tbxApiKey.Size = new System.Drawing.Size(194, 23);
            this.tbxApiKey.TabIndex = 12;
            // 
            // InfoNoSummonerFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 210);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.tbxSummonerName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnNewAPIKey);
            this.Controls.Add(this.btnNewSummonerName);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoNoSummonerFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunClientWarning";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RunClientWarning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnOK;
        private Button btnExit;
        private Label lblMessage;
        private Button btnNewSummonerName;
        private Button btnNewAPIKey;
        private Label lblTitle;
        private TextBox tbxSummonerName;
        private TextBox tbxApiKey;
    }
}