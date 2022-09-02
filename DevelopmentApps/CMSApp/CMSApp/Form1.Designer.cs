namespace CMSApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBrowsePic1 = new System.Windows.Forms.Button();
            this.btnBrowsePic2 = new System.Windows.Forms.Button();
            this.btnShowSimilarity = new System.Windows.Forms.Button();
            this.txtbxPic1 = new System.Windows.Forms.TextBox();
            this.txtbxPic2 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtbxCertainty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSwitchPic = new System.Windows.Forms.Button();
            this.txtbxSimilarity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btxRemovePoints = new System.Windows.Forms.Button();
            this.btnFindMatch = new System.Windows.Forms.Button();
            this.btnFindMatchTop = new System.Windows.Forms.Button();
            this.btnFindMatchM = new System.Windows.Forms.Button();
            this.btnFindMatchTopM = new System.Windows.Forms.Button();
            this.btnFindMatchS = new System.Windows.Forms.Button();
            this.btnFindMatchTopS = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 187);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(326, 194);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnBrowsePic1
            // 
            this.btnBrowsePic1.Location = new System.Drawing.Point(12, 201);
            this.btnBrowsePic1.Name = "btnBrowsePic1";
            this.btnBrowsePic1.Size = new System.Drawing.Size(106, 23);
            this.btnBrowsePic1.TabIndex = 2;
            this.btnBrowsePic1.Text = "Browse Picture 1";
            this.btnBrowsePic1.UseVisualStyleBackColor = true;
            this.btnBrowsePic1.Click += new System.EventHandler(this.btnBrowsePic1_Click);
            // 
            // btnBrowsePic2
            // 
            this.btnBrowsePic2.Location = new System.Drawing.Point(232, 218);
            this.btnBrowsePic2.Name = "btnBrowsePic2";
            this.btnBrowsePic2.Size = new System.Drawing.Size(106, 23);
            this.btnBrowsePic2.TabIndex = 3;
            this.btnBrowsePic2.Text = "Browse Picture 2";
            this.btnBrowsePic2.UseVisualStyleBackColor = true;
            this.btnBrowsePic2.Click += new System.EventHandler(this.btnBrowsePic2_Click);
            // 
            // btnShowSimilarity
            // 
            this.btnShowSimilarity.Location = new System.Drawing.Point(344, 209);
            this.btnShowSimilarity.Name = "btnShowSimilarity";
            this.btnShowSimilarity.Size = new System.Drawing.Size(100, 23);
            this.btnShowSimilarity.TabIndex = 4;
            this.btnShowSimilarity.Text = "Show Similarity";
            this.btnShowSimilarity.UseVisualStyleBackColor = true;
            this.btnShowSimilarity.Click += new System.EventHandler(this.btnShowSimilarity_Click);
            // 
            // txtbxPic1
            // 
            this.txtbxPic1.Enabled = false;
            this.txtbxPic1.Location = new System.Drawing.Point(344, 125);
            this.txtbxPic1.Name = "txtbxPic1";
            this.txtbxPic1.Size = new System.Drawing.Size(100, 23);
            this.txtbxPic1.TabIndex = 5;
            // 
            // txtbxPic2
            // 
            this.txtbxPic2.Enabled = false;
            this.txtbxPic2.Location = new System.Drawing.Point(344, 173);
            this.txtbxPic2.Name = "txtbxPic2";
            this.txtbxPic2.Size = new System.Drawing.Size(100, 23);
            this.txtbxPic2.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(450, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(338, 426);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // txtbxCertainty
            // 
            this.txtbxCertainty.Enabled = false;
            this.txtbxCertainty.Location = new System.Drawing.Point(344, 29);
            this.txtbxCertainty.Name = "txtbxCertainty";
            this.txtbxCertainty.Size = new System.Drawing.Size(100, 23);
            this.txtbxCertainty.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Similarity";
            // 
            // btnSwitchPic
            // 
            this.btnSwitchPic.Location = new System.Drawing.Point(137, 210);
            this.btnSwitchPic.Name = "btnSwitchPic";
            this.btnSwitchPic.Size = new System.Drawing.Size(75, 23);
            this.btnSwitchPic.TabIndex = 10;
            this.btnSwitchPic.Text = "Switch";
            this.btnSwitchPic.UseVisualStyleBackColor = true;
            this.btnSwitchPic.Click += new System.EventHandler(this.btnSwitchPic_Click);
            // 
            // txtbxSimilarity
            // 
            this.txtbxSimilarity.Enabled = false;
            this.txtbxSimilarity.Location = new System.Drawing.Point(344, 77);
            this.txtbxSimilarity.Name = "txtbxSimilarity";
            this.txtbxSimilarity.Size = new System.Drawing.Size(100, 23);
            this.txtbxSimilarity.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Certainty";
            // 
            // btxRemovePoints
            // 
            this.btxRemovePoints.Location = new System.Drawing.Point(351, 415);
            this.btxRemovePoints.Name = "btxRemovePoints";
            this.btxRemovePoints.Size = new System.Drawing.Size(100, 23);
            this.btxRemovePoints.TabIndex = 13;
            this.btxRemovePoints.Text = "Remove points";
            this.btxRemovePoints.UseVisualStyleBackColor = true;
            this.btxRemovePoints.Click += new System.EventHandler(this.btxRemovePoints_Click);
            // 
            // btnFindMatch
            // 
            this.btnFindMatch.Location = new System.Drawing.Point(344, 244);
            this.btnFindMatch.Name = "btnFindMatch";
            this.btnFindMatch.Size = new System.Drawing.Size(100, 23);
            this.btnFindMatch.TabIndex = 14;
            this.btnFindMatch.Text = "Find Match";
            this.btnFindMatch.UseVisualStyleBackColor = true;
            this.btnFindMatch.Click += new System.EventHandler(this.btnFindMatch_Click);
            // 
            // btnFindMatchTop
            // 
            this.btnFindMatchTop.Location = new System.Drawing.Point(344, 267);
            this.btnFindMatchTop.Name = "btnFindMatchTop";
            this.btnFindMatchTop.Size = new System.Drawing.Size(100, 23);
            this.btnFindMatchTop.TabIndex = 15;
            this.btnFindMatchTop.Text = "Find Match Top";
            this.btnFindMatchTop.UseVisualStyleBackColor = true;
            this.btnFindMatchTop.Click += new System.EventHandler(this.btnFindMatchTop_Click);
            // 
            // btnFindMatchM
            // 
            this.btnFindMatchM.Location = new System.Drawing.Point(344, 302);
            this.btnFindMatchM.Name = "btnFindMatchM";
            this.btnFindMatchM.Size = new System.Drawing.Size(100, 23);
            this.btnFindMatchM.TabIndex = 16;
            this.btnFindMatchM.Text = "M Find Match";
            this.btnFindMatchM.UseVisualStyleBackColor = true;
            this.btnFindMatchM.Click += new System.EventHandler(this.btnFindMatchM_Click);
            // 
            // btnFindMatchTopM
            // 
            this.btnFindMatchTopM.Location = new System.Drawing.Point(338, 325);
            this.btnFindMatchTopM.Name = "btnFindMatchTopM";
            this.btnFindMatchTopM.Size = new System.Drawing.Size(111, 23);
            this.btnFindMatchTopM.TabIndex = 17;
            this.btnFindMatchTopM.Text = "M Find Match Top";
            this.btnFindMatchTopM.UseVisualStyleBackColor = true;
            this.btnFindMatchTopM.Click += new System.EventHandler(this.btnFindMatchTopM_Click);
            // 
            // btnFindMatchS
            // 
            this.btnFindMatchS.Location = new System.Drawing.Point(344, 360);
            this.btnFindMatchS.Name = "btnFindMatchS";
            this.btnFindMatchS.Size = new System.Drawing.Size(100, 23);
            this.btnFindMatchS.TabIndex = 18;
            this.btnFindMatchS.Text = "S Find Match";
            this.btnFindMatchS.UseVisualStyleBackColor = true;
            this.btnFindMatchS.Click += new System.EventHandler(this.btnFindMatchS_Click);
            // 
            // btnFindMatchTopS
            // 
            this.btnFindMatchTopS.Location = new System.Drawing.Point(340, 383);
            this.btnFindMatchTopS.Name = "btnFindMatchTopS";
            this.btnFindMatchTopS.Size = new System.Drawing.Size(108, 23);
            this.btnFindMatchTopS.TabIndex = 19;
            this.btnFindMatchTopS.Text = "S Find Match Top";
            this.btnFindMatchTopS.UseVisualStyleBackColor = true;
            this.btnFindMatchTopS.Click += new System.EventHandler(this.btnFindMatchTopS_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Pic 1 rgb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Pic 2 rgb";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFindMatchTopS);
            this.Controls.Add(this.btnFindMatchS);
            this.Controls.Add(this.btnFindMatchTopM);
            this.Controls.Add(this.btnFindMatchM);
            this.Controls.Add(this.btnFindMatchTop);
            this.Controls.Add(this.btnFindMatch);
            this.Controls.Add(this.btxRemovePoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbxSimilarity);
            this.Controls.Add(this.btnSwitchPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxCertainty);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtbxPic2);
            this.Controls.Add(this.txtbxPic1);
            this.Controls.Add(this.btnShowSimilarity);
            this.Controls.Add(this.btnBrowsePic2);
            this.Controls.Add(this.btnBrowsePic1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnBrowsePic1;
        private Button btnBrowsePic2;
        private Button btnShowSimilarity;
        private TextBox txtbxPic1;
        private TextBox txtbxPic2;
        private PictureBox pictureBox3;
        private TextBox txtbxCertainty;
        private Label label1;
        private Button btnSwitchPic;
        private TextBox txtbxSimilarity;
        private Label label2;
        private Button btxRemovePoints;
        private Button btnFindMatch;
        private Button btnFindMatchTop;
        private Button btnFindMatchM;
        private Button btnFindMatchTopM;
        private Button btnFindMatchS;
        private Button btnFindMatchTopS;
        private Label label3;
        private Label label4;
    }
}