namespace LOS
{
    partial class FormOptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.btnCloseOptions = new System.Windows.Forms.Button();
            this.cbxSummonerNames = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblActiveSum = new System.Windows.Forms.Label();
            this.btnScanSummonerName = new System.Windows.Forms.Button();
            this.tbxSummonerName = new System.Windows.Forms.TextBox();
            this.lblNewSum = new System.Windows.Forms.Label();
            this.btnSetNewSummoner = new System.Windows.Forms.Button();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            this.btnSetApiKey = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeleteActiveSummonerData = new System.Windows.Forms.Button();
            this.lblLoLClientL = new System.Windows.Forms.Label();
            this.tbxLoLClientL = new System.Windows.Forms.TextBox();
            this.btnSetLoLCleintL = new System.Windows.Forms.Button();
            this.lblOptionsMessage = new System.Windows.Forms.Label();
            this.showHideTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnCloseOptions
            // 
            this.btnCloseOptions.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnCloseOptions.FlatAppearance.BorderSize = 0;
            this.btnCloseOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCloseOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseOptions.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCloseOptions.Location = new System.Drawing.Point(68, 216);
            this.btnCloseOptions.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnCloseOptions.Name = "btnCloseOptions";
            this.btnCloseOptions.Size = new System.Drawing.Size(133, 23);
            this.btnCloseOptions.TabIndex = 0;
            this.btnCloseOptions.Text = "Close";
            this.btnCloseOptions.UseVisualStyleBackColor = false;
            this.btnCloseOptions.Click += new System.EventHandler(this.btnCloseOptions_Click);
            this.btnCloseOptions.MouseEnter += new System.EventHandler(this.btnCloseOptions_MouseEnter);
            this.btnCloseOptions.MouseLeave += new System.EventHandler(this.btnCloseOptions_MouseLeave);
            this.btnCloseOptions.MouseHover += new System.EventHandler(this.btnCloseOptions_MouseHover);
            // 
            // cbxSummonerNames
            // 
            this.cbxSummonerNames.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbxSummonerNames.BackColor = System.Drawing.SystemColors.WindowText;
            this.cbxSummonerNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSummonerNames.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxSummonerNames.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxSummonerNames.FormattingEnabled = true;
            this.cbxSummonerNames.Location = new System.Drawing.Point(109, 45);
            this.cbxSummonerNames.Name = "cbxSummonerNames";
            this.cbxSummonerNames.Size = new System.Drawing.Size(161, 23);
            this.cbxSummonerNames.TabIndex = 1;
            this.cbxSummonerNames.SelectedIndexChanged += new System.EventHandler(this.cbxSummonerNames_SelectedIndexChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lblActiveSum
            // 
            this.lblActiveSum.AutoSize = true;
            this.lblActiveSum.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveSum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblActiveSum.Location = new System.Drawing.Point(0, 48);
            this.lblActiveSum.Name = "lblActiveSum";
            this.lblActiveSum.Size = new System.Drawing.Size(105, 15);
            this.lblActiveSum.TabIndex = 2;
            this.lblActiveSum.Text = "Active Summoner:";
            // 
            // btnScanSummonerName
            // 
            this.btnScanSummonerName.BackColor = System.Drawing.Color.Black;
            this.btnScanSummonerName.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnScanSummonerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanSummonerName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnScanSummonerName.ForeColor = System.Drawing.SystemColors.Window;
            this.btnScanSummonerName.Location = new System.Drawing.Point(3, 101);
            this.btnScanSummonerName.Name = "btnScanSummonerName";
            this.btnScanSummonerName.Size = new System.Drawing.Size(47, 23);
            this.btnScanSummonerName.TabIndex = 3;
            this.btnScanSummonerName.Text = "Scan";
            this.btnScanSummonerName.UseVisualStyleBackColor = false;
            this.btnScanSummonerName.Click += new System.EventHandler(this.btnScanSummonerName_Click);
            this.btnScanSummonerName.MouseEnter += new System.EventHandler(this.btnScanSummonerName_MouseEnter);
            this.btnScanSummonerName.MouseLeave += new System.EventHandler(this.btnScanSummonerName_MouseLeave);
            this.btnScanSummonerName.MouseHover += new System.EventHandler(this.btnScanSummonerName_MouseHover);
            // 
            // tbxSummonerName
            // 
            this.tbxSummonerName.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbxSummonerName.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxSummonerName.Location = new System.Drawing.Point(53, 101);
            this.tbxSummonerName.Name = "tbxSummonerName";
            this.tbxSummonerName.PlaceholderText = "Enter manually...";
            this.tbxSummonerName.Size = new System.Drawing.Size(168, 23);
            this.tbxSummonerName.TabIndex = 4;
            // 
            // lblNewSum
            // 
            this.lblNewSum.AutoSize = true;
            this.lblNewSum.BackColor = System.Drawing.Color.Transparent;
            this.lblNewSum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNewSum.Location = new System.Drawing.Point(0, 83);
            this.lblNewSum.Name = "lblNewSum";
            this.lblNewSum.Size = new System.Drawing.Size(96, 15);
            this.lblNewSum.TabIndex = 5;
            this.lblNewSum.Text = "New Summoner:";
            // 
            // btnSetNewSummoner
            // 
            this.btnSetNewSummoner.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnSetNewSummoner.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSetNewSummoner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetNewSummoner.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetNewSummoner.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSetNewSummoner.Location = new System.Drawing.Point(223, 101);
            this.btnSetNewSummoner.Name = "btnSetNewSummoner";
            this.btnSetNewSummoner.Size = new System.Drawing.Size(46, 23);
            this.btnSetNewSummoner.TabIndex = 6;
            this.btnSetNewSummoner.Text = "Set";
            this.btnSetNewSummoner.UseVisualStyleBackColor = false;
            this.btnSetNewSummoner.Click += new System.EventHandler(this.btnSetNewSummoner_Click);
            this.btnSetNewSummoner.MouseEnter += new System.EventHandler(this.btnSetNewSummoner_MouseEnter);
            this.btnSetNewSummoner.MouseLeave += new System.EventHandler(this.btnSetNewSummoner_MouseLeave);
            this.btnSetNewSummoner.MouseHover += new System.EventHandler(this.btnSetNewSummoner_MouseHover);
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.BackColor = System.Drawing.Color.Transparent;
            this.lblApiKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblApiKey.Location = new System.Drawing.Point(0, 128);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(50, 15);
            this.lblApiKey.TabIndex = 7;
            this.lblApiKey.Text = "API Key:";
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbxApiKey.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxApiKey.Location = new System.Drawing.Point(3, 146);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.PlaceholderText = "Enter new API key...";
            this.tbxApiKey.Size = new System.Drawing.Size(218, 23);
            this.tbxApiKey.TabIndex = 8;
            // 
            // btnSetApiKey
            // 
            this.btnSetApiKey.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnSetApiKey.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSetApiKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetApiKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetApiKey.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSetApiKey.Location = new System.Drawing.Point(223, 146);
            this.btnSetApiKey.Name = "btnSetApiKey";
            this.btnSetApiKey.Size = new System.Drawing.Size(46, 23);
            this.btnSetApiKey.TabIndex = 9;
            this.btnSetApiKey.Text = "Set";
            this.btnSetApiKey.UseVisualStyleBackColor = false;
            this.btnSetApiKey.Click += new System.EventHandler(this.btnSetApiKey_Click);
            this.btnSetApiKey.MouseEnter += new System.EventHandler(this.btnSetApiKey_MouseEnter);
            this.btnSetApiKey.MouseLeave += new System.EventHandler(this.btnSetApiKey_MouseLeave);
            this.btnSetApiKey.MouseHover += new System.EventHandler(this.btnSetApiKey_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Location = new System.Drawing.Point(71, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 20);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "LoL Overlay System";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.Location = new System.Drawing.Point(213, 69);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(57, 24);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.MouseEnter += new System.EventHandler(this.btnUpdate_MouseEnter);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.btnUpdate_MouseLeave);
            this.btnUpdate.MouseHover += new System.EventHandler(this.btnUpdate_MouseHover);
            // 
            // btnDeleteActiveSummonerData
            // 
            this.btnDeleteActiveSummonerData.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnDeleteActiveSummonerData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteActiveSummonerData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteActiveSummonerData.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDeleteActiveSummonerData.Location = new System.Drawing.Point(109, 69);
            this.btnDeleteActiveSummonerData.Name = "btnDeleteActiveSummonerData";
            this.btnDeleteActiveSummonerData.Size = new System.Drawing.Size(57, 23);
            this.btnDeleteActiveSummonerData.TabIndex = 12;
            this.btnDeleteActiveSummonerData.Text = "Delete";
            this.btnDeleteActiveSummonerData.UseVisualStyleBackColor = false;
            this.btnDeleteActiveSummonerData.Click += new System.EventHandler(this.btnDeleteActiveSummonerData_Click);
            this.btnDeleteActiveSummonerData.MouseEnter += new System.EventHandler(this.btnDeleteActiveSummonerData_MouseEnter);
            this.btnDeleteActiveSummonerData.MouseLeave += new System.EventHandler(this.btnDeleteActiveSummonerData_MouseLeave);
            this.btnDeleteActiveSummonerData.MouseHover += new System.EventHandler(this.btnDeleteActiveSummonerData_MouseHover);
            // 
            // lblLoLClientL
            // 
            this.lblLoLClientL.AutoSize = true;
            this.lblLoLClientL.BackColor = System.Drawing.Color.Transparent;
            this.lblLoLClientL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLoLClientL.Location = new System.Drawing.Point(3, 172);
            this.lblLoLClientL.Name = "lblLoLClientL";
            this.lblLoLClientL.Size = new System.Drawing.Size(112, 15);
            this.lblLoLClientL.TabIndex = 13;
            this.lblLoLClientL.Text = "LoL Client Location:";
            // 
            // tbxLoLClientL
            // 
            this.tbxLoLClientL.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbxLoLClientL.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxLoLClientL.Location = new System.Drawing.Point(3, 190);
            this.tbxLoLClientL.Name = "tbxLoLClientL";
            this.tbxLoLClientL.PlaceholderText = "Enter new LoL Client Location...";
            this.tbxLoLClientL.Size = new System.Drawing.Size(218, 23);
            this.tbxLoLClientL.TabIndex = 14;
            // 
            // btnSetLoLCleintL
            // 
            this.btnSetLoLCleintL.BackColor = System.Drawing.SystemColors.WindowText;
            this.btnSetLoLCleintL.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSetLoLCleintL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetLoLCleintL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetLoLCleintL.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSetLoLCleintL.Location = new System.Drawing.Point(223, 190);
            this.btnSetLoLCleintL.Name = "btnSetLoLCleintL";
            this.btnSetLoLCleintL.Size = new System.Drawing.Size(46, 23);
            this.btnSetLoLCleintL.TabIndex = 15;
            this.btnSetLoLCleintL.Text = "Set";
            this.btnSetLoLCleintL.UseVisualStyleBackColor = false;
            this.btnSetLoLCleintL.Click += new System.EventHandler(this.btnSetLoLCleintL_Click);
            this.btnSetLoLCleintL.MouseEnter += new System.EventHandler(this.btnSetLoLCleintL_MouseEnter);
            this.btnSetLoLCleintL.MouseLeave += new System.EventHandler(this.btnSetLoLCleintL_MouseLeave);
            this.btnSetLoLCleintL.MouseHover += new System.EventHandler(this.btnSetLoLCleintL_MouseHover);
            // 
            // lblOptionsMessage
            // 
            this.lblOptionsMessage.AutoSize = true;
            this.lblOptionsMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblOptionsMessage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOptionsMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOptionsMessage.Location = new System.Drawing.Point(2, 5);
            this.lblOptionsMessage.Name = "lblOptionsMessage";
            this.lblOptionsMessage.Size = new System.Drawing.Size(0, 13);
            this.lblOptionsMessage.TabIndex = 16;
            // 
            // showHideTimer
            // 
            this.showHideTimer.Interval = 1;
            this.showHideTimer.Tick += new System.EventHandler(this.updateShowHideTimer);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(274, 240);
            this.Controls.Add(this.lblOptionsMessage);
            this.Controls.Add(this.btnSetLoLCleintL);
            this.Controls.Add(this.tbxLoLClientL);
            this.Controls.Add(this.lblLoLClientL);
            this.Controls.Add(this.btnDeleteActiveSummonerData);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSetApiKey);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.btnSetNewSummoner);
            this.Controls.Add(this.lblNewSum);
            this.Controls.Add(this.tbxSummonerName);
            this.Controls.Add(this.btnScanSummonerName);
            this.Controls.Add(this.lblActiveSum);
            this.Controls.Add(this.cbxSummonerNames);
            this.Controls.Add(this.btnCloseOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(274, 240);
            this.MinimumSize = new System.Drawing.Size(0, 240);
            this.Name = "FormOptions";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCloseOptions;
        private ComboBox cbxSummonerNames;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblActiveSum;
        private Button btnScanSummonerName;
        private TextBox tbxSummonerName;
        private Label lblNewSum;
        private Button btnSetNewSummoner;
        private Label lblApiKey;
        private TextBox tbxApiKey;
        private Button btnSetApiKey;
        private Label lblTitle;
        private Button btnUpdate;
        private Button btnDeleteActiveSummonerData;
        private Label lblLoLClientL;
        private TextBox tbxLoLClientL;
        private Button btnSetLoLCleintL;
        private Label lblOptionsMessage;
        private System.Windows.Forms.Timer showHideTimer;
    }
}