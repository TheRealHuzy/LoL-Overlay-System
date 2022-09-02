namespace LOS
{
    partial class SetupFormLoadingBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupFormLoadingBar));
            this.pbDownloading = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbDownloading
            // 
            this.pbDownloading.BackColor = System.Drawing.SystemColors.Control;
            this.pbDownloading.Location = new System.Drawing.Point(2, 22);
            this.pbDownloading.Name = "pbDownloading";
            this.pbDownloading.Size = new System.Drawing.Size(268, 5);
            this.pbDownloading.Step = 1;
            this.pbDownloading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDownloading.TabIndex = 7;
            // 
            // SetupFormLoadingBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 52);
            this.Controls.Add(this.pbDownloading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupFormLoadingBar";
            this.Text = "SetupFormLoadingBar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SetupFormLoadingBar_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ProgressBar pbDownloading;
    }
}