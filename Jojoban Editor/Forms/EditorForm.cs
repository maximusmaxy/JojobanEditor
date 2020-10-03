using System;
using System.Windows.Forms;
using System.IO;

namespace Jojoban_Editor
{
    public partial class EditorForm : Form
    {
        public static EditorForm Current;
        public EditorForm()
        {
            InitializeComponent();
            Current = this;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Open(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveAs(saveFileDialog.FileName);
            }
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Rom.IsUpdated())
                {
                    var result = MessageBox.Show("You have made unsaved changes to the Rom. Would you like to save them now?", "Unsaved Changes",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Save();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Open(string path)
        {
            if (Path.GetExtension(path) != ".zip")
            {
                MessageBox.Show("The selected path is not a zip file");
                return;
            }
            try
            {
                using (var progressDialog = new ProgressDialog(path, true))
                {
                    progressDialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Rom.Path == null)
            {
                return;
            }
            Character.LoadCharacters();
            tabControl.Enabled = true;

            hitboxPage.OnLoad();

            saveToolStripMenuItem.Enabled = true;
            //saveAsToolStripMenuItem.Enabled = true;
        }
   

        private void Save()
        {
            try
            {
                using (var progressDialog = new ProgressDialog(Rom.Path, false))
                {
                    progressDialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAs(string path)
        {
            try
            {
                using (var progressDialog = new ProgressDialog(path, false))
                {
                    progressDialog.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MarkUpdated()
        {
            Text = "Jojoban Editor*";
        }

        public void ClearUpdated()
        {
            Text = "Jojoban Editor";
        }
    }
}