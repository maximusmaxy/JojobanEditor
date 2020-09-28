using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jojoban_Editor
{
    public partial class HitboxControl : UserControl
    {
        public string Title { get; set; }
        public Hitbox.Type Type { get; set; }
        
        public EditorForm Editor { get; set; }
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
            var groupBox = upDown.Parent as GroupBox;
            var index = groupBox.Controls.GetChildIndex(upDown);
            Editor.HitboxValueChanged(Type, index, (short)upDown.Value);
        }

        public void LoadBox(Box box)
        {
            groupBox.Enabled = (box != null);
            if (!groupBox.Enabled) return;
            boxX.Value = box.X;
            boxY.Value = box.Y;
            boxWidth.Value = box.W;
            boxHeight.Value = box.H;
        }
    }
}
