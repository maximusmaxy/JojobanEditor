namespace Jojoban_Editor
{
    partial class EditorForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.hitboxPage = new System.Windows.Forms.TabPage();
            this.moveComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.characterComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.hitboxControlCol = new Jojoban_Editor.HitboxControl();
            this.hitboxControlLegs = new Jojoban_Editor.HitboxControl();
            this.hitboxControlTorso = new Jojoban_Editor.HitboxControl();
            this.hitboxControlHead = new Jojoban_Editor.HitboxControl();
            this.hitboxControlAtk2 = new Jojoban_Editor.HitboxControl();
            this.hitboxControlAtk1 = new Jojoban_Editor.HitboxControl();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.hitboxPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spritePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spritePictureBox.Location = new System.Drawing.Point(380, 6);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(666, 584);
            this.spritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spritePictureBox.TabIndex = 1;
            this.spritePictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.hitboxPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1060, 622);
            this.tabControl.TabIndex = 4;
            // 
            // hitboxPage
            // 
            this.hitboxPage.BackColor = System.Drawing.SystemColors.Control;
            this.hitboxPage.Controls.Add(this.hitboxControlCol);
            this.hitboxPage.Controls.Add(this.hitboxControlLegs);
            this.hitboxPage.Controls.Add(this.hitboxControlTorso);
            this.hitboxPage.Controls.Add(this.hitboxControlHead);
            this.hitboxPage.Controls.Add(this.hitboxControlAtk2);
            this.hitboxPage.Controls.Add(this.hitboxControlAtk1);
            this.hitboxPage.Controls.Add(this.moveComboBox);
            this.hitboxPage.Controls.Add(this.label6);
            this.hitboxPage.Controls.Add(this.label5);
            this.hitboxPage.Controls.Add(this.characterComboBox);
            this.hitboxPage.Controls.Add(this.spritePictureBox);
            this.hitboxPage.Location = new System.Drawing.Point(4, 22);
            this.hitboxPage.Name = "hitboxPage";
            this.hitboxPage.Padding = new System.Windows.Forms.Padding(3);
            this.hitboxPage.Size = new System.Drawing.Size(1052, 596);
            this.hitboxPage.TabIndex = 0;
            this.hitboxPage.Text = "Hitbox";
            // 
            // moveComboBox
            // 
            this.moveComboBox.FormattingEnabled = true;
            this.moveComboBox.Items.AddRange(new object[] {
            "5A"});
            this.moveComboBox.Location = new System.Drawing.Point(65, 30);
            this.moveComboBox.Name = "moveComboBox";
            this.moveComboBox.Size = new System.Drawing.Size(121, 21);
            this.moveComboBox.TabIndex = 7;
            this.moveComboBox.Text = "5A";
            this.moveComboBox.SelectedIndexChanged += new System.EventHandler(this.moveComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Move";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Character";
            // 
            // characterComboBox
            // 
            this.characterComboBox.FormattingEnabled = true;
            this.characterComboBox.Items.AddRange(new object[] {
            "Jotaro"});
            this.characterComboBox.Location = new System.Drawing.Point(65, 3);
            this.characterComboBox.Name = "characterComboBox";
            this.characterComboBox.Size = new System.Drawing.Size(121, 21);
            this.characterComboBox.TabIndex = 4;
            this.characterComboBox.Text = "Jotaro";
            this.characterComboBox.SelectedIndexChanged += new System.EventHandler(this.characterComboBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1052, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // hitboxControlCol
            // 
            this.hitboxControlCol.Editor = null;
            this.hitboxControlCol.Location = new System.Drawing.Point(192, 334);
            this.hitboxControlCol.Name = "hitboxControlCol";
            this.hitboxControlCol.Size = new System.Drawing.Size(182, 135);
            this.hitboxControlCol.TabIndex = 18;
            this.hitboxControlCol.Title = "Collision ";
            this.hitboxControlCol.Type = Jojoban_Editor.Hitbox.Type.Col;
            // 
            // hitboxControlLegs
            // 
            this.hitboxControlLegs.Editor = null;
            this.hitboxControlLegs.Location = new System.Drawing.Point(3, 334);
            this.hitboxControlLegs.Name = "hitboxControlLegs";
            this.hitboxControlLegs.Size = new System.Drawing.Size(182, 135);
            this.hitboxControlLegs.TabIndex = 17;
            this.hitboxControlLegs.Title = "Legs";
            this.hitboxControlLegs.Type = Jojoban_Editor.Hitbox.Type.Legs;
            // 
            // hitboxControlTorso
            // 
            this.hitboxControlTorso.Editor = null;
            this.hitboxControlTorso.Location = new System.Drawing.Point(192, 193);
            this.hitboxControlTorso.Name = "hitboxControlTorso";
            this.hitboxControlTorso.Size = new System.Drawing.Size(182, 135);
            this.hitboxControlTorso.TabIndex = 16;
            this.hitboxControlTorso.Title = "Torso";
            this.hitboxControlTorso.Type = Jojoban_Editor.Hitbox.Type.Torso;
            // 
            // hitboxControlHead
            // 
            this.hitboxControlHead.Editor = null;
            this.hitboxControlHead.Location = new System.Drawing.Point(4, 193);
            this.hitboxControlHead.Name = "hitboxControlHead";
            this.hitboxControlHead.Size = new System.Drawing.Size(182, 135);
            this.hitboxControlHead.TabIndex = 15;
            this.hitboxControlHead.Title = "Head";
            this.hitboxControlHead.Type = Jojoban_Editor.Hitbox.Type.Head;
            // 
            // hitboxControlAtk2
            // 
            this.hitboxControlAtk2.Editor = null;
            this.hitboxControlAtk2.Location = new System.Drawing.Point(191, 52);
            this.hitboxControlAtk2.Name = "hitboxControlAtk2";
            this.hitboxControlAtk2.Size = new System.Drawing.Size(182, 135);
            this.hitboxControlAtk2.TabIndex = 14;
            this.hitboxControlAtk2.Title = "Attack 2";
            this.hitboxControlAtk2.Type = Jojoban_Editor.Hitbox.Type.Atk2;
            // 
            // hitboxControlAtk1
            // 
            this.hitboxControlAtk1.Editor = null;
            this.hitboxControlAtk1.Location = new System.Drawing.Point(3, 52);
            this.hitboxControlAtk1.Name = "hitboxControlAtk1";
            this.hitboxControlAtk1.Size = new System.Drawing.Size(182, 135);
            this.hitboxControlAtk1.TabIndex = 13;
            this.hitboxControlAtk1.Title = "Attack 1";
            this.hitboxControlAtk1.Type = Jojoban_Editor.Hitbox.Type.Atk1;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "EditorForm";
            this.Text = "Jojoban Editor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.hitboxPage.ResumeLayout(false);
            this.hitboxPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage hitboxPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox moveComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox characterComboBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private HitboxControl hitboxControlAtk1;
        private HitboxControl hitboxControlCol;
        private HitboxControl hitboxControlLegs;
        private HitboxControl hitboxControlTorso;
        private HitboxControl hitboxControlHead;
        private HitboxControl hitboxControlAtk2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

