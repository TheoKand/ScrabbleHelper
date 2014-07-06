namespace ScrabbleHelper2
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.lstLanguage = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // lstLanguage
            // 
            this.lstLanguage.AccessibleDescription = null;
            this.lstLanguage.AccessibleName = null;
            resources.ApplyResources(this.lstLanguage, "lstLanguage");
            this.lstLanguage.BackgroundImage = null;
            this.lstLanguage.Font = null;
            this.lstLanguage.FormattingEnabled = true;
            this.lstLanguage.Items.AddRange(new object[] {
            resources.GetString("lstLanguage.Items"),
            resources.GetString("lstLanguage.Items1")});
            this.lstLanguage.Name = "lstLanguage";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackgroundImage = null;
            this.btnOK.Font = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.AccessibleDescription = null;
            this.chkTopMost.AccessibleName = null;
            resources.ApplyResources(this.chkTopMost, "chkTopMost");
            this.chkTopMost.BackgroundImage = null;
            this.chkTopMost.Font = null;
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstLanguage);
            this.Controls.Add(this.label1);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Load += new System.EventHandler(this.frmLanguage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstLanguage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkTopMost;
    }
}