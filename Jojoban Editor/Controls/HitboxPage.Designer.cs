namespace Jojoban_Editor
{
    partial class HitboxPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.characterComboBox = new System.Windows.Forms.ComboBox();
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            this.frameComboBox = new System.Windows.Forms.ComboBox();
            this.hitboxCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.spritePanel = new System.Windows.Forms.Panel();
            this.hitboxControlCol = new Jojoban_Editor.HitboxControl();
            this.hitboxControlLegs = new Jojoban_Editor.HitboxControl();
            this.hitboxControlTorso = new Jojoban_Editor.HitboxControl();
            this.hitboxControlHead = new Jojoban_Editor.HitboxControl();
            this.hitboxControlAtk2 = new Jojoban_Editor.HitboxControl();
            this.hitboxControlAtk1 = new Jojoban_Editor.HitboxControl();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            this.spritePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionComboBox
            // 
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(68, 37);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(121, 21);
            this.actionComboBox.TabIndex = 23;
            this.actionComboBox.Text = "0";
            this.actionComboBox.SelectedIndexChanged += new System.EventHandler(this.actionComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Action";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Character";
            // 
            // characterComboBox
            // 
            this.characterComboBox.FormattingEnabled = true;
            this.characterComboBox.Location = new System.Drawing.Point(68, 10);
            this.characterComboBox.Name = "characterComboBox";
            this.characterComboBox.Size = new System.Drawing.Size(121, 21);
            this.characterComboBox.TabIndex = 20;
            this.characterComboBox.Text = "Jotaro";
            this.characterComboBox.SelectedIndexChanged += new System.EventHandler(this.characterComboBox_SelectedIndexChanged);
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spritePictureBox.Location = new System.Drawing.Point(-2, -2);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(690, 584);
            this.spritePictureBox.TabIndex = 19;
            this.spritePictureBox.TabStop = false;
            this.spritePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spritePictureBox_MouseDown);
            this.spritePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spritePictureBox_MouseMove);
            this.spritePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spritePictureBox_MouseUp);
            // 
            // frameComboBox
            // 
            this.frameComboBox.FormattingEnabled = true;
            this.frameComboBox.Location = new System.Drawing.Point(68, 64);
            this.frameComboBox.Name = "frameComboBox";
            this.frameComboBox.Size = new System.Drawing.Size(121, 21);
            this.frameComboBox.TabIndex = 30;
            this.frameComboBox.Text = "0";
            this.frameComboBox.SelectedIndexChanged += new System.EventHandler(this.frameComboBox_SelectedIndexChanged);
            // 
            // hitboxCheckBox
            // 
            this.hitboxCheckBox.AutoSize = true;
            this.hitboxCheckBox.Location = new System.Drawing.Point(198, 12);
            this.hitboxCheckBox.Name = "hitboxCheckBox";
            this.hitboxCheckBox.Size = new System.Drawing.Size(176, 17);
            this.hitboxCheckBox.TabIndex = 31;
            this.hitboxCheckBox.Text = "Show actions with hitboxes only";
            this.hitboxCheckBox.UseVisualStyleBackColor = true;
            this.hitboxCheckBox.CheckedChanged += new System.EventHandler(this.hitboxCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Frame";
            // 
            // spritePanel
            // 
            this.spritePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spritePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spritePanel.Controls.Add(this.spritePictureBox);
            this.spritePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.spritePanel.Location = new System.Drawing.Point(396, 0);
            this.spritePanel.Name = "spritePanel";
            this.spritePanel.Size = new System.Drawing.Size(690, 584);
            this.spritePanel.TabIndex = 33;
            // 
            // hitboxControlCol
            // 
            this.hitboxControlCol.Box = null;
            this.hitboxControlCol.Hitbox = null;
            this.hitboxControlCol.Location = new System.Drawing.Point(198, 426);
            this.hitboxControlCol.Name = "hitboxControlCol";
            this.hitboxControlCol.Page = null;
            this.hitboxControlCol.Size = new System.Drawing.Size(192, 158);
            this.hitboxControlCol.TabIndex = 29;
            this.hitboxControlCol.Title = "Collision ";
            // 
            // hitboxControlLegs
            // 
            this.hitboxControlLegs.Box = null;
            this.hitboxControlLegs.Hitbox = null;
            this.hitboxControlLegs.Location = new System.Drawing.Point(3, 426);
            this.hitboxControlLegs.Name = "hitboxControlLegs";
            this.hitboxControlLegs.Page = null;
            this.hitboxControlLegs.Size = new System.Drawing.Size(189, 158);
            this.hitboxControlLegs.TabIndex = 28;
            this.hitboxControlLegs.Title = "Legs";
            // 
            // hitboxControlTorso
            // 
            this.hitboxControlTorso.Box = null;
            this.hitboxControlTorso.Hitbox = null;
            this.hitboxControlTorso.Location = new System.Drawing.Point(198, 261);
            this.hitboxControlTorso.Name = "hitboxControlTorso";
            this.hitboxControlTorso.Page = null;
            this.hitboxControlTorso.Size = new System.Drawing.Size(192, 159);
            this.hitboxControlTorso.TabIndex = 27;
            this.hitboxControlTorso.Title = "Torso";
            // 
            // hitboxControlHead
            // 
            this.hitboxControlHead.Box = null;
            this.hitboxControlHead.Hitbox = null;
            this.hitboxControlHead.Location = new System.Drawing.Point(3, 261);
            this.hitboxControlHead.Name = "hitboxControlHead";
            this.hitboxControlHead.Page = null;
            this.hitboxControlHead.Size = new System.Drawing.Size(189, 159);
            this.hitboxControlHead.TabIndex = 26;
            this.hitboxControlHead.Title = "Head";
            // 
            // hitboxControlAtk2
            // 
            this.hitboxControlAtk2.Box = null;
            this.hitboxControlAtk2.Hitbox = null;
            this.hitboxControlAtk2.Location = new System.Drawing.Point(198, 97);
            this.hitboxControlAtk2.Name = "hitboxControlAtk2";
            this.hitboxControlAtk2.Page = null;
            this.hitboxControlAtk2.Size = new System.Drawing.Size(192, 158);
            this.hitboxControlAtk2.TabIndex = 25;
            this.hitboxControlAtk2.Title = "Attack 2";
            // 
            // hitboxControlAtk1
            // 
            this.hitboxControlAtk1.Box = null;
            this.hitboxControlAtk1.Hitbox = null;
            this.hitboxControlAtk1.Location = new System.Drawing.Point(3, 97);
            this.hitboxControlAtk1.Name = "hitboxControlAtk1";
            this.hitboxControlAtk1.Page = null;
            this.hitboxControlAtk1.Size = new System.Drawing.Size(196, 158);
            this.hitboxControlAtk1.TabIndex = 24;
            this.hitboxControlAtk1.Title = "Attack 1";
            // 
            // HitboxPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spritePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hitboxCheckBox);
            this.Controls.Add(this.frameComboBox);
            this.Controls.Add(this.hitboxControlCol);
            this.Controls.Add(this.hitboxControlLegs);
            this.Controls.Add(this.hitboxControlTorso);
            this.Controls.Add(this.hitboxControlHead);
            this.Controls.Add(this.hitboxControlAtk2);
            this.Controls.Add(this.hitboxControlAtk1);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.characterComboBox);
            this.Name = "HitboxPage";
            this.Size = new System.Drawing.Size(1089, 588);
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            this.spritePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HitboxControl hitboxControlCol;
        private HitboxControl hitboxControlLegs;
        private HitboxControl hitboxControlTorso;
        private HitboxControl hitboxControlHead;
        private HitboxControl hitboxControlAtk2;
        private HitboxControl hitboxControlAtk1;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox characterComboBox;
        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.ComboBox frameComboBox;
        private System.Windows.Forms.CheckBox hitboxCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel spritePanel;
    }
}
