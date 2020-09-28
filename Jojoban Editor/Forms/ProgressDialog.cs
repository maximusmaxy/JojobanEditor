using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (load)
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open))
                {
                    using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Read))
                    {
                        var simm = Rom.ArchiveType(archive);
                        Rom.Ten = LoadRom(worker, "10", archive, simm, true, 0x6000000);
                        Rom.Twenty = LoadRom(worker, "20", archive, simm, true, 0x6800000);
                        Rom.Thirty = LoadRom(worker, "30", archive, simm, false);
                        Rom.ThirtyOne = LoadRom(worker, "31", archive, simm, false);
                        Rom.Forty = LoadRom(worker, "40", archive, simm, false);
                        Rom.FortyOne = LoadRom(worker, "41", archive, simm, false);
                        Rom.Fifty = LoadRom(worker, "50", archive, simm, false);
                        Rom.FiftyOne = LoadRom(worker, "51", archive, simm, false);
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

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            infoLabel.Text = infoText;
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
            Close();
        }
    }
}