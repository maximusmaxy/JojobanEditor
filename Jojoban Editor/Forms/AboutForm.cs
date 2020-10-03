using System.Diagnostics;
using System.Windows.Forms;

namespace Jojoban_Editor
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void githubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/maximusmaxy");
        }

        private void discordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://discord.gg/EFZyyJm");
        }
    }
}
