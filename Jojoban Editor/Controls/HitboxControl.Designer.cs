namespace Jojoban_Editor
{
    partial class HitboxControl
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.boxX = new System.Windows.Forms.NumericUpDown();
            this.boxY = new System.Windows.Forms.NumericUpDown();
            this.boxWidth = new System.Windows.Forms.NumericUpDown();
            this.boxHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.boxX);
            this.groupBox.Controls.Add(this.boxY);
            this.groupBox.Controls.Add(this.boxWidth);
            this.groupBox.Controls.Add(this.boxHeight);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(176, 130);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Box";
            // 
            // boxX
            // 
            this.boxX.Location = new System.Drawing.Point(48, 19);
            this.boxX.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.boxX.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.boxX.Name = "boxX";
            this.boxX.Size = new System.Drawing.Size(120, 20);
            this.boxX.TabIndex = 0;
            this.boxX.ValueChanged += new System.EventHandler(this.UpDownValueChanged);
            // 
            // boxY
            // 
            this.boxY.Location = new System.Drawing.Point(48, 45);
            this.boxY.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.boxY.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.boxY.Name = "boxY";
            this.boxY.Size = new System.Drawing.Size(120, 20);
            this.boxY.TabIndex = 1;
            this.boxY.ValueChanged += new System.EventHandler(this.UpDownValueChanged);
            // 
            // boxWidth
            // 
            this.boxWidth.Location = new System.Drawing.Point(48, 71);
            this.boxWidth.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.boxWidth.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.boxWidth.Name = "boxWidth";
            this.boxWidth.Size = new System.Drawing.Size(120, 20);
            this.boxWidth.TabIndex = 2;
            this.boxWidth.ValueChanged += new System.EventHandler(this.UpDownValueChanged);
            // 
            // boxHeight
            // 
            this.boxHeight.Location = new System.Drawing.Point(48, 97);
            this.boxHeight.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.boxHeight.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.boxHeight.Name = "boxHeight";
            this.boxHeight.Size = new System.Drawing.Size(120, 20);
            this.boxHeight.TabIndex = 3;
            this.boxHeight.ValueChanged += new System.EventHandler(this.UpDownValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // HitboxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "HitboxControl";
            this.Size = new System.Drawing.Size(182, 135);
            this.Load += new System.EventHandler(this.HitboxControl_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.NumericUpDown boxX;
        private System.Windows.Forms.NumericUpDown boxY;
        private System.Windows.Forms.NumericUpDown boxWidth;
        private System.Windows.Forms.NumericUpDown boxHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
