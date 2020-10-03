using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Jojoban_Editor
{
    public partial class ProgressDialog : Form
    {
        private string filePath;
        private bool load;
        private string infoText;
        private int progress;

        public ProgressDialog(string filePath, bool load)
        {
            InitializeComponent();
            this.filePath = filePath;
            this.load = load;
            infoText = load ? "Loading" : "Saving";
            Text = infoText;
            this.infoLabel.Text = infoText;
            this.progress = 0;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                if (load)
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Read))
                        {
                            var simm = Rom.ArchiveType(archive);
                            Rom.Ten = LoadRom(worker, "10", archive, simm, true, 0x6000000);
                            Rom.Twenty = LoadRom(worker, "20", archive, simm, true, 0x6800000);
                            Rom.Thirty = LoadRom(worker, "30", archive, simm, false, 0x0000000);
                            Rom.ThirtyOne = LoadRom(worker, "31", archive, simm, false, 0x0800000);
                            Rom.Forty = LoadRom(worker, "40", archive, simm, false, 0x1000000);
                            Rom.FortyOne = LoadRom(worker, "41", archive, simm, false, 0x1800000);
                            Rom.Fifty = LoadRom(worker, "50", archive, simm, false, 0x2000000);
                            Rom.FiftyOne = LoadRom(worker, "51", archive, simm, false, 0x2800000);
                            Rom.Path = filePath;
                            Rom.Roms = Rom.GetRoms();
                        }
                    }
                }
                else
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Update))
                        {
                            var simm = Rom.ArchiveType(archive);
                            var buffer = new byte[0x800000];
                            SaveRom(worker, Rom.Ten, archive, simm, buffer);
                            SaveRom(worker, Rom.Twenty, archive, simm, buffer);
                            SaveRom(worker, Rom.Thirty, archive, simm, buffer);
                            SaveRom(worker, Rom.ThirtyOne, archive, simm, buffer);
                            SaveRom(worker, Rom.Forty, archive, simm, buffer);
                            SaveRom(worker, Rom.FortyOne, archive, simm, buffer);
                            SaveRom(worker, Rom.Fifty, archive, simm, buffer);
                            SaveRom(worker, Rom.FiftyOne, archive, simm, buffer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            infoLabel.Text = infoText;
            progressBar.PerformStep();
            progressBar.Value = e.ProgressPercentage;
        }

        private Rom LoadRom(BackgroundWorker worker, string fileName, ZipArchive archive, bool simm, bool encrypted, int offset = 0)
        {
            infoText = $"Loading {fileName}";
            worker.ReportProgress(progress++);
            return new Rom(archive, fileName, simm, encrypted, offset);
        }

        private void SaveRom(BackgroundWorker worker, Rom rom, ZipArchive archive, bool simm, byte[] buffer = null)
        {
            infoText = $"Saving {rom.Name}";
            worker.ReportProgress(progress++);
            rom.Save(archive, simm, buffer);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EditorForm.Current.ClearUpdated();
            Close();
        }
    }
}