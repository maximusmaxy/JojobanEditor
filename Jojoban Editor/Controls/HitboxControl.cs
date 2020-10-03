using System;
using System.Windows.Forms;

namespace Jojoban_Editor
{
    public partial class HitboxControl : UserControl
    {
        public string Title { get; set; }
        public Hitbox Hitbox { get; set; }
        public Box Box { get; set; }
        public HitboxPage Page { get; set; }
        public HitboxControl()
        {
            InitializeComponent();
        }

        private void HitboxControl_Load(object sender, EventArgs e)
        {
            groupBox.Text = Title;
        }

        private void UpDownValueChanged(object sender, EventArgs e)
        {
            var upDown = sender as NumericUpDown;
            var index = groupBox.Controls.GetChildIndex(upDown);
            var value = (short)upDown.Value;
            short previousValue = 0;
            switch (index)
            {
                case 1:
                    previousValue = Box.X;
                    Box.X = value;
                    break;
                case 2:
                    previousValue = Box.Y;
                    Box.Y = value;
                    break;
                case 3:
                    previousValue = Box.W;
                    Box.W = value;
                    break;
                case 4:
                    previousValue = Box.H;
                    Box.H = value;
                    break;
            }
            if (previousValue != value)
            {
                Page.UpdateHitbox();
            }
        }

        private void NumChanged(object sender, EventArgs e)
        {
            var upDown = sender as NumericUpDown;
            Hitbox.UpdateBoxIndex(Box.Type, (int)upDown.Value);
            Page.LoadBoxes();
            Page.UpdateHitbox();
        }

        public void LoadBox(Hitbox hitbox, Box box)
        {
            Hitbox = hitbox;
            Box = box;
            if (box.Index == 0)
            {
                boxNum.Value = 0;
                boxX.Enabled = false;
                boxY.Enabled = false;
                boxWidth.Enabled = false;
                boxHeight.Enabled = false;
            }
            else
            {
                boxX.Enabled = true;
                boxY.Enabled = true;
                boxWidth.Enabled = true;
                boxHeight.Enabled = true;
                boxNum.Value = box.Index;
                boxX.Value = box.X;
                boxY.Value = box.Y;
                boxWidth.Value = box.W;
                boxHeight.Value = box.H;
            }
        }
    }
}
