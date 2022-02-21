namespace YAML_Creator
{
    partial class YAMLNameWindow
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
            this.YAMLNameConfirm = new System.Windows.Forms.Button();
            this.YAMLNameLabel = new System.Windows.Forms.Label();
            this.YAMLName = new System.Windows.Forms.TextBox();
            this.SaveLabel = new System.Windows.Forms.Label();
            this.LoadLabel = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YAMLNameConfirm
            // 
            this.YAMLNameConfirm.Location = new System.Drawing.Point(53, 70);
            this.YAMLNameConfirm.Name = "YAMLNameConfirm";
            this.YAMLNameConfirm.Size = new System.Drawing.Size(75, 24);
            this.YAMLNameConfirm.TabIndex = 0;
            this.YAMLNameConfirm.Text = "Confirm";
            this.YAMLNameConfirm.UseVisualStyleBackColor = true;
            this.YAMLNameConfirm.Click += new System.EventHandler(this.YAMLNameConfirm_Click);
            // 
            // YAMLNameLabel
            // 
            this.YAMLNameLabel.AutoSize = true;
            this.YAMLNameLabel.Location = new System.Drawing.Point(24, 3);
            this.YAMLNameLabel.Name = "YAMLNameLabel";
            this.YAMLNameLabel.Size = new System.Drawing.Size(143, 13);
            this.YAMLNameLabel.TabIndex = 1;
            this.YAMLNameLabel.Text = "Enter a name for your YAML.";
            // 
            // YAMLName
            // 
            this.YAMLName.Location = new System.Drawing.Point(42, 19);
            this.YAMLName.Name = "YAMLName";
            this.YAMLName.Size = new System.Drawing.Size(100, 20);
            this.YAMLName.TabIndex = 2;
            // 
            // SaveLabel
            // 
            this.SaveLabel.AutoSize = true;
            this.SaveLabel.Location = new System.Drawing.Point(12, 42);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(155, 26);
            this.SaveLabel.TabIndex = 3;
            this.SaveLabel.Text = "Once you confirm you\'ll need to\r\nselect a save location.";
            this.SaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadLabel
            // 
            this.LoadLabel.AutoSize = true;
            this.LoadLabel.Location = new System.Drawing.Point(173, 22);
            this.LoadLabel.Name = "LoadLabel";
            this.LoadLabel.Size = new System.Drawing.Size(118, 26);
            this.LoadLabel.TabIndex = 4;
            this.LoadLabel.Text = "Or Click here to load a \r\npreviously made YAML.";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(194, 59);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 24);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // YAMLNameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 105);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.LoadLabel);
            this.Controls.Add(this.SaveLabel);
            this.Controls.Add(this.YAMLName);
            this.Controls.Add(this.YAMLNameLabel);
            this.Controls.Add(this.YAMLNameConfirm);
            this.Name = "YAMLNameWindow";
            this.Text = "YAML Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YAMLNameConfirm;
        private System.Windows.Forms.Label YAMLNameLabel;
        private System.Windows.Forms.TextBox YAMLName;
        private System.Windows.Forms.Label SaveLabel;
        private System.Windows.Forms.Label LoadLabel;
        private System.Windows.Forms.Button LoadButton;
    }
}