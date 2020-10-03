namespace Jojoban_Editor
{
    partial class AboutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.githubLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.discordLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Made by Maxie with help from the HFTF Stardust Romhackers";
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.Location = new System.Drawing.Point(12, 35);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(164, 13);
            this.githubLabel.TabIndex = 1;
            this.githubLabel.TabStop = true;
            this.githubLabel.Text = "https://github.com/maximusmaxy";
            this.githubLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Join the HFTF discord for romhacking support";
            // 
            // discordLabel
            // 
            this.discordLabel.AutoSize = true;
            this.discordLabel.Location = new System.Drawing.Point(12, 90);
            this.discordLabel.Name = "discordLabel";
            this.discordLabel.Size = new System.Drawing.Size(140, 13);
            this.discordLabel.TabIndex = 3;
            this.discordLabel.TabStop = true;
            this.discordLabel.Text = "https://discord.gg/EFZyyJm";
            this.discordLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.discordLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 123);
            this.Controls.Add(this.discordLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.githubLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel githubLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel discordLabel;
    }
}