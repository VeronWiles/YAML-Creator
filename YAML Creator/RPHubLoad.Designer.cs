
namespace YAML_Creator
{
    partial class RPHubLoad
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
            this.AreaList = new System.Windows.Forms.ListBox();
            this.RpHubQuestion = new System.Windows.Forms.Label();
            this.RPHubConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AreaList
            // 
            this.AreaList.FormattingEnabled = true;
            this.AreaList.ItemHeight = 16;
            this.AreaList.Location = new System.Drawing.Point(109, 29);
            this.AreaList.Name = "AreaList";
            this.AreaList.Size = new System.Drawing.Size(120, 84);
            this.AreaList.TabIndex = 0;
            // 
            // RpHubQuestion
            // 
            this.RpHubQuestion.AutoSize = true;
            this.RpHubQuestion.Location = new System.Drawing.Point(12, 9);
            this.RpHubQuestion.Name = "RpHubQuestion";
            this.RpHubQuestion.Size = new System.Drawing.Size(327, 17);
            this.RpHubQuestion.TabIndex = 1;
            this.RpHubQuestion.Text = "Please select which area in your list is the RP Hub.";
            // 
            // RPHubConfirm
            // 
            this.RPHubConfirm.Location = new System.Drawing.Point(133, 119);
            this.RPHubConfirm.Name = "RPHubConfirm";
            this.RPHubConfirm.Size = new System.Drawing.Size(75, 23);
            this.RPHubConfirm.TabIndex = 2;
            this.RPHubConfirm.Text = "Confirm";
            this.RPHubConfirm.UseVisualStyleBackColor = true;
            this.RPHubConfirm.Click += new System.EventHandler(this.RPHubConfirm_Click);
            // 
            // RPHubLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 153);
            this.Controls.Add(this.RPHubConfirm);
            this.Controls.Add(this.RpHubQuestion);
            this.Controls.Add(this.AreaList);
            this.Name = "RPHubLoad";
            this.Text = "Choose RP Hub";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AreaList;
        private System.Windows.Forms.Label RpHubQuestion;
        private System.Windows.Forms.Button RPHubConfirm;
    }
}