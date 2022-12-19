namespace MergeImageApp
{
    partial class Form1
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
            this.pb1stPic = new System.Windows.Forms.PictureBox();
            this.pb2ndPic = new System.Windows.Forms.PictureBox();
            this.pbFinalPic = new System.Windows.Forms.PictureBox();
            this.btnBrowseTop = new System.Windows.Forms.Button();
            this.btnBrowseBot = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnResizeUp = new System.Windows.Forms.Button();
            this.btnResizeDown = new System.Windows.Forms.Button();
            this.lblSizeDeviationTitle = new System.Windows.Forms.Label();
            this.lblSizeDeviation = new System.Windows.Forms.Label();
            this.lblXPositionDeviationTitle = new System.Windows.Forms.Label();
            this.lblXPositionDeviation = new System.Windows.Forms.Label();
            this.lblYPositionDeviationTitle = new System.Windows.Forms.Label();
            this.lblYPositionDeviation = new System.Windows.Forms.Label();
            this.lblResizeTitle = new System.Windows.Forms.Label();
            this.lblOpacityTitle = new System.Windows.Forms.Label();
            this.btnOpacityUp = new System.Windows.Forms.Button();
            this.btnOpacityDown = new System.Windows.Forms.Button();
            this.lblOpacityPercentageTitle = new System.Windows.Forms.Label();
            this.lblOpacityPercentage = new System.Windows.Forms.Label();
            this.btnOpacityUpLittle = new System.Windows.Forms.Button();
            this.btnOpacityDownLittle = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblOpacityDesc1Title = new System.Windows.Forms.Label();
            this.lblOpacityDesc01Title = new System.Windows.Forms.Label();
            this.lblMoveTitle = new System.Windows.Forms.Label();
            this.lblBackImageTitle = new System.Windows.Forms.Label();
            this.lblFrontImageTitle = new System.Windows.Forms.Label();
            this.btnResizeUpMuch = new System.Windows.Forms.Button();
            this.btnResizeDownMuch = new System.Windows.Forms.Button();
            this.lblResizeDesc10Title = new System.Windows.Forms.Label();
            this.lblResizeDesc1Title = new System.Windows.Forms.Label();
            this.cbxRetainScaleOffset = new System.Windows.Forms.CheckBox();
            this.cbxAllowQualityLoss = new System.Windows.Forms.CheckBox();
            this.tbxBackImage = new System.Windows.Forms.TextBox();
            this.tbxFrontImage = new System.Windows.Forms.TextBox();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnSaveAllM = new System.Windows.Forms.Button();
            this.btnSaveAllS = new System.Windows.Forms.Button();
            this.btnSetDefaultM = new System.Windows.Forms.Button();
            this.btnSetDefaultS = new System.Windows.Forms.Button();
            this.btnSaveAllResolutions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb1stPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2ndPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pb1stPic
            // 
            this.pb1stPic.Location = new System.Drawing.Point(13, 12);
            this.pb1stPic.Name = "pb1stPic";
            this.pb1stPic.Size = new System.Drawing.Size(250, 250);
            this.pb1stPic.TabIndex = 0;
            this.pb1stPic.TabStop = false;
            // 
            // pb2ndPic
            // 
            this.pb2ndPic.Location = new System.Drawing.Point(12, 290);
            this.pb2ndPic.Name = "pb2ndPic";
            this.pb2ndPic.Size = new System.Drawing.Size(250, 250);
            this.pb2ndPic.TabIndex = 1;
            this.pb2ndPic.TabStop = false;
            // 
            // pbFinalPic
            // 
            this.pbFinalPic.Location = new System.Drawing.Point(405, 12);
            this.pbFinalPic.Name = "pbFinalPic";
            this.pbFinalPic.Size = new System.Drawing.Size(450, 450);
            this.pbFinalPic.TabIndex = 2;
            this.pbFinalPic.TabStop = false;
            // 
            // btnBrowseTop
            // 
            this.btnBrowseTop.Location = new System.Drawing.Point(12, 262);
            this.btnBrowseTop.Name = "btnBrowseTop";
            this.btnBrowseTop.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTop.TabIndex = 3;
            this.btnBrowseTop.Text = "Browse Top";
            this.btnBrowseTop.UseVisualStyleBackColor = true;
            this.btnBrowseTop.Click += new System.EventHandler(this.btnBrowseTop_Click);
            // 
            // btnBrowseBot
            // 
            this.btnBrowseBot.Location = new System.Drawing.Point(188, 267);
            this.btnBrowseBot.Name = "btnBrowseBot";
            this.btnBrowseBot.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBot.TabIndex = 4;
            this.btnBrowseBot.Text = "Browse Bot";
            this.btnBrowseBot.UseVisualStyleBackColor = true;
            this.btnBrowseBot.Click += new System.EventHandler(this.btnBrowseBot_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(102, 264);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 5;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(608, 489);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(44, 23);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "▲";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(608, 517);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(44, 23);
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.Text = "▼";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Location = new System.Drawing.Point(658, 517);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(44, 23);
            this.btnMoveRight.TabIndex = 8;
            this.btnMoveRight.Text = ">";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Location = new System.Drawing.Point(558, 517);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(44, 23);
            this.btnMoveLeft.TabIndex = 9;
            this.btnMoveLeft.Text = "<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnResizeUp
            // 
            this.btnResizeUp.Location = new System.Drawing.Point(800, 493);
            this.btnResizeUp.Name = "btnResizeUp";
            this.btnResizeUp.Size = new System.Drawing.Size(44, 23);
            this.btnResizeUp.TabIndex = 10;
            this.btnResizeUp.Text = "+";
            this.btnResizeUp.UseVisualStyleBackColor = true;
            this.btnResizeUp.Click += new System.EventHandler(this.btnResizeUp_Click);
            // 
            // btnResizeDown
            // 
            this.btnResizeDown.Location = new System.Drawing.Point(800, 518);
            this.btnResizeDown.Name = "btnResizeDown";
            this.btnResizeDown.Size = new System.Drawing.Size(44, 23);
            this.btnResizeDown.TabIndex = 11;
            this.btnResizeDown.Text = "-";
            this.btnResizeDown.UseVisualStyleBackColor = true;
            this.btnResizeDown.Click += new System.EventHandler(this.btnResizeDown_Click);
            // 
            // lblSizeDeviationTitle
            // 
            this.lblSizeDeviationTitle.AutoSize = true;
            this.lblSizeDeviationTitle.Location = new System.Drawing.Point(279, 211);
            this.lblSizeDeviationTitle.Name = "lblSizeDeviationTitle";
            this.lblSizeDeviationTitle.Size = new System.Drawing.Size(76, 13);
            this.lblSizeDeviationTitle.TabIndex = 12;
            this.lblSizeDeviationTitle.Text = "Size deviatian:";
            // 
            // lblSizeDeviation
            // 
            this.lblSizeDeviation.AutoSize = true;
            this.lblSizeDeviation.Location = new System.Drawing.Point(361, 211);
            this.lblSizeDeviation.Name = "lblSizeDeviation";
            this.lblSizeDeviation.Size = new System.Drawing.Size(10, 13);
            this.lblSizeDeviation.TabIndex = 13;
            this.lblSizeDeviation.Text = "-";
            // 
            // lblXPositionDeviationTitle
            // 
            this.lblXPositionDeviationTitle.AutoSize = true;
            this.lblXPositionDeviationTitle.Location = new System.Drawing.Point(279, 232);
            this.lblXPositionDeviationTitle.Name = "lblXPositionDeviationTitle";
            this.lblXPositionDeviationTitle.Size = new System.Drawing.Size(56, 13);
            this.lblXPositionDeviationTitle.TabIndex = 14;
            this.lblXPositionDeviationTitle.Text = "X position:";
            // 
            // lblXPositionDeviation
            // 
            this.lblXPositionDeviation.AutoSize = true;
            this.lblXPositionDeviation.Location = new System.Drawing.Point(361, 232);
            this.lblXPositionDeviation.Name = "lblXPositionDeviation";
            this.lblXPositionDeviation.Size = new System.Drawing.Size(10, 13);
            this.lblXPositionDeviation.TabIndex = 15;
            this.lblXPositionDeviation.Text = "-";
            // 
            // lblYPositionDeviationTitle
            // 
            this.lblYPositionDeviationTitle.AutoSize = true;
            this.lblYPositionDeviationTitle.Location = new System.Drawing.Point(279, 254);
            this.lblYPositionDeviationTitle.Name = "lblYPositionDeviationTitle";
            this.lblYPositionDeviationTitle.Size = new System.Drawing.Size(56, 13);
            this.lblYPositionDeviationTitle.TabIndex = 16;
            this.lblYPositionDeviationTitle.Text = "Y position:";
            // 
            // lblYPositionDeviation
            // 
            this.lblYPositionDeviation.AutoSize = true;
            this.lblYPositionDeviation.Location = new System.Drawing.Point(361, 254);
            this.lblYPositionDeviation.Name = "lblYPositionDeviation";
            this.lblYPositionDeviation.Size = new System.Drawing.Size(10, 13);
            this.lblYPositionDeviation.TabIndex = 17;
            this.lblYPositionDeviation.Text = "-";
            // 
            // lblResizeTitle
            // 
            this.lblResizeTitle.AutoSize = true;
            this.lblResizeTitle.Location = new System.Drawing.Point(751, 473);
            this.lblResizeTitle.Name = "lblResizeTitle";
            this.lblResizeTitle.Size = new System.Drawing.Size(39, 13);
            this.lblResizeTitle.TabIndex = 18;
            this.lblResizeTitle.Text = "Resize";
            // 
            // lblOpacityTitle
            // 
            this.lblOpacityTitle.AutoSize = true;
            this.lblOpacityTitle.Location = new System.Drawing.Point(402, 473);
            this.lblOpacityTitle.Name = "lblOpacityTitle";
            this.lblOpacityTitle.Size = new System.Drawing.Size(43, 13);
            this.lblOpacityTitle.TabIndex = 19;
            this.lblOpacityTitle.Text = "Opacity";
            // 
            // btnOpacityUp
            // 
            this.btnOpacityUp.Location = new System.Drawing.Point(405, 493);
            this.btnOpacityUp.Name = "btnOpacityUp";
            this.btnOpacityUp.Size = new System.Drawing.Size(44, 23);
            this.btnOpacityUp.TabIndex = 20;
            this.btnOpacityUp.Text = "+";
            this.btnOpacityUp.UseVisualStyleBackColor = true;
            this.btnOpacityUp.Click += new System.EventHandler(this.btnOpacityUp_Click);
            // 
            // btnOpacityDown
            // 
            this.btnOpacityDown.Location = new System.Drawing.Point(405, 517);
            this.btnOpacityDown.Name = "btnOpacityDown";
            this.btnOpacityDown.Size = new System.Drawing.Size(44, 23);
            this.btnOpacityDown.TabIndex = 21;
            this.btnOpacityDown.Text = "-";
            this.btnOpacityDown.UseVisualStyleBackColor = true;
            this.btnOpacityDown.Click += new System.EventHandler(this.btnOpacityDown_Click);
            // 
            // lblOpacityPercentageTitle
            // 
            this.lblOpacityPercentageTitle.AutoSize = true;
            this.lblOpacityPercentageTitle.Location = new System.Drawing.Point(279, 276);
            this.lblOpacityPercentageTitle.Name = "lblOpacityPercentageTitle";
            this.lblOpacityPercentageTitle.Size = new System.Drawing.Size(46, 13);
            this.lblOpacityPercentageTitle.TabIndex = 22;
            this.lblOpacityPercentageTitle.Text = "Opacity:";
            // 
            // lblOpacityPercentage
            // 
            this.lblOpacityPercentage.AutoSize = true;
            this.lblOpacityPercentage.Location = new System.Drawing.Point(361, 276);
            this.lblOpacityPercentage.Name = "lblOpacityPercentage";
            this.lblOpacityPercentage.Size = new System.Drawing.Size(10, 13);
            this.lblOpacityPercentage.TabIndex = 23;
            this.lblOpacityPercentage.Text = "-";
            // 
            // btnOpacityUpLittle
            // 
            this.btnOpacityUpLittle.Location = new System.Drawing.Point(451, 493);
            this.btnOpacityUpLittle.Name = "btnOpacityUpLittle";
            this.btnOpacityUpLittle.Size = new System.Drawing.Size(44, 23);
            this.btnOpacityUpLittle.TabIndex = 24;
            this.btnOpacityUpLittle.Text = "+";
            this.btnOpacityUpLittle.UseVisualStyleBackColor = true;
            this.btnOpacityUpLittle.Click += new System.EventHandler(this.btnOpacityUpLittle_Click);
            // 
            // btnOpacityDownLittle
            // 
            this.btnOpacityDownLittle.Location = new System.Drawing.Point(451, 517);
            this.btnOpacityDownLittle.Name = "btnOpacityDownLittle";
            this.btnOpacityDownLittle.Size = new System.Drawing.Size(44, 23);
            this.btnOpacityDownLittle.TabIndex = 25;
            this.btnOpacityDownLittle.Text = "-";
            this.btnOpacityDownLittle.UseVisualStyleBackColor = true;
            this.btnOpacityDownLittle.Click += new System.EventHandler(this.btnOpacityDownLittle_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(291, 385);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 23);
            this.btnReset.TabIndex = 26;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(766, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblOpacityDesc1Title
            // 
            this.lblOpacityDesc1Title.AutoSize = true;
            this.lblOpacityDesc1Title.Location = new System.Drawing.Point(379, 511);
            this.lblOpacityDesc1Title.Name = "lblOpacityDesc1Title";
            this.lblOpacityDesc1Title.Size = new System.Drawing.Size(27, 13);
            this.lblOpacityDesc1Title.TabIndex = 28;
            this.lblOpacityDesc1Title.Text = "10%";
            // 
            // lblOpacityDesc01Title
            // 
            this.lblOpacityDesc01Title.AutoSize = true;
            this.lblOpacityDesc01Title.Location = new System.Drawing.Point(495, 511);
            this.lblOpacityDesc01Title.Name = "lblOpacityDesc01Title";
            this.lblOpacityDesc01Title.Size = new System.Drawing.Size(21, 13);
            this.lblOpacityDesc01Title.TabIndex = 29;
            this.lblOpacityDesc01Title.Text = "1%";
            // 
            // lblMoveTitle
            // 
            this.lblMoveTitle.AutoSize = true;
            this.lblMoveTitle.Location = new System.Drawing.Point(555, 473);
            this.lblMoveTitle.Name = "lblMoveTitle";
            this.lblMoveTitle.Size = new System.Drawing.Size(34, 13);
            this.lblMoveTitle.TabIndex = 30;
            this.lblMoveTitle.Text = "Move";
            // 
            // lblBackImageTitle
            // 
            this.lblBackImageTitle.AutoSize = true;
            this.lblBackImageTitle.Location = new System.Drawing.Point(269, 12);
            this.lblBackImageTitle.Name = "lblBackImageTitle";
            this.lblBackImageTitle.Size = new System.Drawing.Size(73, 13);
            this.lblBackImageTitle.TabIndex = 31;
            this.lblBackImageTitle.Text = "< Back Image";
            // 
            // lblFrontImageTitle
            // 
            this.lblFrontImageTitle.AutoSize = true;
            this.lblFrontImageTitle.Location = new System.Drawing.Point(269, 527);
            this.lblFrontImageTitle.Name = "lblFrontImageTitle";
            this.lblFrontImageTitle.Size = new System.Drawing.Size(72, 13);
            this.lblFrontImageTitle.TabIndex = 32;
            this.lblFrontImageTitle.Text = "< Front Image";
            // 
            // btnResizeUpMuch
            // 
            this.btnResizeUpMuch.Location = new System.Drawing.Point(754, 493);
            this.btnResizeUpMuch.Name = "btnResizeUpMuch";
            this.btnResizeUpMuch.Size = new System.Drawing.Size(44, 23);
            this.btnResizeUpMuch.TabIndex = 33;
            this.btnResizeUpMuch.Text = "+";
            this.btnResizeUpMuch.UseVisualStyleBackColor = true;
            this.btnResizeUpMuch.Click += new System.EventHandler(this.btnResizeUpMuch_Click);
            // 
            // btnResizeDownMuch
            // 
            this.btnResizeDownMuch.Location = new System.Drawing.Point(754, 518);
            this.btnResizeDownMuch.Name = "btnResizeDownMuch";
            this.btnResizeDownMuch.Size = new System.Drawing.Size(44, 23);
            this.btnResizeDownMuch.TabIndex = 34;
            this.btnResizeDownMuch.Text = "-";
            this.btnResizeDownMuch.UseVisualStyleBackColor = true;
            this.btnResizeDownMuch.Click += new System.EventHandler(this.btnResizeDownMuch_Click);
            // 
            // lblResizeDesc10Title
            // 
            this.lblResizeDesc10Title.AutoSize = true;
            this.lblResizeDesc10Title.Location = new System.Drawing.Point(725, 511);
            this.lblResizeDesc10Title.Name = "lblResizeDesc10Title";
            this.lblResizeDesc10Title.Size = new System.Drawing.Size(30, 13);
            this.lblResizeDesc10Title.TabIndex = 35;
            this.lblResizeDesc10Title.Text = "10px";
            // 
            // lblResizeDesc1Title
            // 
            this.lblResizeDesc1Title.AutoSize = true;
            this.lblResizeDesc1Title.Location = new System.Drawing.Point(843, 511);
            this.lblResizeDesc1Title.Name = "lblResizeDesc1Title";
            this.lblResizeDesc1Title.Size = new System.Drawing.Size(24, 13);
            this.lblResizeDesc1Title.TabIndex = 36;
            this.lblResizeDesc1Title.Text = "1px";
            // 
            // cbxRetainScaleOffset
            // 
            this.cbxRetainScaleOffset.AutoSize = true;
            this.cbxRetainScaleOffset.Checked = true;
            this.cbxRetainScaleOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRetainScaleOffset.Location = new System.Drawing.Point(282, 298);
            this.cbxRetainScaleOffset.Name = "cbxRetainScaleOffset";
            this.cbxRetainScaleOffset.Size = new System.Drawing.Size(118, 17);
            this.cbxRetainScaleOffset.TabIndex = 37;
            this.cbxRetainScaleOffset.Text = "Retain Scale Offset";
            this.cbxRetainScaleOffset.UseVisualStyleBackColor = true;
            this.cbxRetainScaleOffset.CheckStateChanged += new System.EventHandler(this.cbxRetainScaleOffset_CheckStateChanged);
            // 
            // cbxAllowQualityLoss
            // 
            this.cbxAllowQualityLoss.AutoSize = true;
            this.cbxAllowQualityLoss.Location = new System.Drawing.Point(282, 321);
            this.cbxAllowQualityLoss.Name = "cbxAllowQualityLoss";
            this.cbxAllowQualityLoss.Size = new System.Drawing.Size(111, 17);
            this.cbxAllowQualityLoss.TabIndex = 38;
            this.cbxAllowQualityLoss.Text = "Allow Quality Loss";
            this.cbxAllowQualityLoss.UseVisualStyleBackColor = true;
            this.cbxAllowQualityLoss.CheckStateChanged += new System.EventHandler(this.cbxAllowQualityLoss_CheckStateChanged);
            // 
            // tbxBackImage
            // 
            this.tbxBackImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbxBackImage.Location = new System.Drawing.Point(272, 28);
            this.tbxBackImage.Multiline = true;
            this.tbxBackImage.Name = "tbxBackImage";
            this.tbxBackImage.ReadOnly = true;
            this.tbxBackImage.Size = new System.Drawing.Size(108, 50);
            this.tbxBackImage.TabIndex = 39;
            // 
            // tbxFrontImage
            // 
            this.tbxFrontImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbxFrontImage.Location = new System.Drawing.Point(272, 474);
            this.tbxFrontImage.Multiline = true;
            this.tbxFrontImage.Name = "tbxFrontImage";
            this.tbxFrontImage.ReadOnly = true;
            this.tbxFrontImage.Size = new System.Drawing.Size(108, 50);
            this.tbxFrontImage.TabIndex = 40;
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Location = new System.Drawing.Point(291, 84);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(89, 23);
            this.btnSetDefault.TabIndex = 41;
            this.btnSetDefault.Text = "Set Default";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(304, 561);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(89, 23);
            this.btnSaveAll.TabIndex = 42;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnSaveAllM
            // 
            this.btnSaveAllM.Location = new System.Drawing.Point(406, 561);
            this.btnSaveAllM.Name = "btnSaveAllM";
            this.btnSaveAllM.Size = new System.Drawing.Size(89, 23);
            this.btnSaveAllM.TabIndex = 43;
            this.btnSaveAllM.Text = "Save All M";
            this.btnSaveAllM.UseVisualStyleBackColor = true;
            this.btnSaveAllM.Click += new System.EventHandler(this.btnSaveAllM_Click);
            // 
            // btnSaveAllS
            // 
            this.btnSaveAllS.Location = new System.Drawing.Point(513, 561);
            this.btnSaveAllS.Name = "btnSaveAllS";
            this.btnSaveAllS.Size = new System.Drawing.Size(89, 23);
            this.btnSaveAllS.TabIndex = 44;
            this.btnSaveAllS.Text = "Save All S";
            this.btnSaveAllS.UseVisualStyleBackColor = true;
            this.btnSaveAllS.Click += new System.EventHandler(this.btnSaveAllS_Click);
            // 
            // btnSetDefaultM
            // 
            this.btnSetDefaultM.Location = new System.Drawing.Point(291, 113);
            this.btnSetDefaultM.Name = "btnSetDefaultM";
            this.btnSetDefaultM.Size = new System.Drawing.Size(89, 23);
            this.btnSetDefaultM.TabIndex = 45;
            this.btnSetDefaultM.Text = "Set Default M";
            this.btnSetDefaultM.UseVisualStyleBackColor = true;
            this.btnSetDefaultM.Click += new System.EventHandler(this.btnSetDefaultM_Click);
            // 
            // btnSetDefaultS
            // 
            this.btnSetDefaultS.Location = new System.Drawing.Point(291, 140);
            this.btnSetDefaultS.Name = "btnSetDefaultS";
            this.btnSetDefaultS.Size = new System.Drawing.Size(89, 23);
            this.btnSetDefaultS.TabIndex = 46;
            this.btnSetDefaultS.Text = "Set Default S";
            this.btnSetDefaultS.UseVisualStyleBackColor = true;
            this.btnSetDefaultS.Click += new System.EventHandler(this.btnSetDefaultS_Click);
            // 
            // btnSaveAllResolutions
            // 
            this.btnSaveAllResolutions.Location = new System.Drawing.Point(13, 561);
            this.btnSaveAllResolutions.Name = "btnSaveAllResolutions";
            this.btnSaveAllResolutions.Size = new System.Drawing.Size(250, 23);
            this.btnSaveAllResolutions.TabIndex = 47;
            this.btnSaveAllResolutions.Text = "Save All Resolutions With Default Values";
            this.btnSaveAllResolutions.UseVisualStyleBackColor = true;
            this.btnSaveAllResolutions.Click += new System.EventHandler(this.btnSaveAllResolutions_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 596);
            this.Controls.Add(this.btnSaveAllResolutions);
            this.Controls.Add(this.btnSetDefaultS);
            this.Controls.Add(this.btnSetDefaultM);
            this.Controls.Add(this.btnSaveAllS);
            this.Controls.Add(this.btnSaveAllM);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.btnSetDefault);
            this.Controls.Add(this.tbxFrontImage);
            this.Controls.Add(this.tbxBackImage);
            this.Controls.Add(this.cbxAllowQualityLoss);
            this.Controls.Add(this.cbxRetainScaleOffset);
            this.Controls.Add(this.lblResizeDesc1Title);
            this.Controls.Add(this.lblResizeDesc10Title);
            this.Controls.Add(this.btnResizeDownMuch);
            this.Controls.Add(this.btnResizeUpMuch);
            this.Controls.Add(this.lblFrontImageTitle);
            this.Controls.Add(this.lblBackImageTitle);
            this.Controls.Add(this.lblMoveTitle);
            this.Controls.Add(this.lblOpacityDesc01Title);
            this.Controls.Add(this.lblOpacityDesc1Title);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOpacityDownLittle);
            this.Controls.Add(this.btnOpacityUpLittle);
            this.Controls.Add(this.lblOpacityPercentage);
            this.Controls.Add(this.lblOpacityPercentageTitle);
            this.Controls.Add(this.btnOpacityDown);
            this.Controls.Add(this.btnOpacityUp);
            this.Controls.Add(this.lblOpacityTitle);
            this.Controls.Add(this.lblResizeTitle);
            this.Controls.Add(this.lblYPositionDeviation);
            this.Controls.Add(this.lblYPositionDeviationTitle);
            this.Controls.Add(this.lblXPositionDeviation);
            this.Controls.Add(this.lblXPositionDeviationTitle);
            this.Controls.Add(this.lblSizeDeviation);
            this.Controls.Add(this.lblSizeDeviationTitle);
            this.Controls.Add(this.btnResizeDown);
            this.Controls.Add(this.btnResizeUp);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnBrowseBot);
            this.Controls.Add(this.btnBrowseTop);
            this.Controls.Add(this.pbFinalPic);
            this.Controls.Add(this.pb2ndPic);
            this.Controls.Add(this.pb1stPic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb1stPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2ndPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1stPic;
        private System.Windows.Forms.PictureBox pb2ndPic;
        private System.Windows.Forms.PictureBox pbFinalPic;
        private System.Windows.Forms.Button btnBrowseTop;
        private System.Windows.Forms.Button btnBrowseBot;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnResizeUp;
        private System.Windows.Forms.Button btnResizeDown;
        private System.Windows.Forms.Label lblSizeDeviationTitle;
        private System.Windows.Forms.Label lblSizeDeviation;
        private System.Windows.Forms.Label lblXPositionDeviationTitle;
        private System.Windows.Forms.Label lblXPositionDeviation;
        private System.Windows.Forms.Label lblYPositionDeviationTitle;
        private System.Windows.Forms.Label lblYPositionDeviation;
        private System.Windows.Forms.Label lblResizeTitle;
        private System.Windows.Forms.Label lblOpacityTitle;
        private System.Windows.Forms.Button btnOpacityUp;
        private System.Windows.Forms.Button btnOpacityDown;
        private System.Windows.Forms.Label lblOpacityPercentageTitle;
        private System.Windows.Forms.Label lblOpacityPercentage;
        private System.Windows.Forms.Button btnOpacityUpLittle;
        private System.Windows.Forms.Button btnOpacityDownLittle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblOpacityDesc1Title;
        private System.Windows.Forms.Label lblOpacityDesc01Title;
        private System.Windows.Forms.Label lblMoveTitle;
        private System.Windows.Forms.Label lblBackImageTitle;
        private System.Windows.Forms.Label lblFrontImageTitle;
        private System.Windows.Forms.Button btnResizeUpMuch;
        private System.Windows.Forms.Button btnResizeDownMuch;
        private System.Windows.Forms.Label lblResizeDesc10Title;
        private System.Windows.Forms.Label lblResizeDesc1Title;
        private System.Windows.Forms.CheckBox cbxRetainScaleOffset;
        private System.Windows.Forms.CheckBox cbxAllowQualityLoss;
        private System.Windows.Forms.TextBox tbxBackImage;
        private System.Windows.Forms.TextBox tbxFrontImage;
        private System.Windows.Forms.Button btnSetDefault;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnSaveAllM;
        private System.Windows.Forms.Button btnSaveAllS;
        private System.Windows.Forms.Button btnSetDefaultM;
        private System.Windows.Forms.Button btnSetDefaultS;
        private System.Windows.Forms.Button btnSaveAllResolutions;
    }
}

