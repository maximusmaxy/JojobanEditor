using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Jojoban_Editor
{
    public partial class EditorForm : Form
    {
        private Sprite sprite;
        private Hitbox hitbox;
        public EditorForm()
        {
            InitializeComponent();

            characterComboBox.DataSource = new[]
            {
                new { Name = "Jotaro", Value = 0 },
                new { Name = "Kakyoin", Value = 1 },
                new { Name = "Avdol", Value = 2 },
                new { Name = "Polnareff", Value = 3 },
                new { Name = "Old Joseph", Value = 4 },
                new { Name = "Iggy", Value = 5 },
                new { Name = "Alessy", Value = 6 },
                new { Name = "Chaka", Value = 7 },
                new { Name = "Devo", Value = 8 },
                new { Name = "N. Doul", Value = 9 },
                new { Name = "Midler", Value = 10 },
                new { Name = "Dio", Value = 11 },
                new { Name = "Vanilla Ice", Value = 12 },
                new { Name = "Death 13", Value = 13 },
                new { Name = "Shadow Dio", Value = 14 },
                new { Name = "Young Joseph", Value = 15 },
                new { Name = "Hol Horse", Value = 16 },
                new { Name = "Boss Ice", Value = 17 },
                new { Name = "New Kakyoin", Value = 18 },
                new { Name = "Black Polnareff", Value = 19 },
                new { Name = "Petshop", Value = 20 },
                new { Name = "Grey Fly", Value = 21},
                new { Name = "Mariah", Value = 22 }, 
                new { Name = "Hoingo", Value = 23 }, 
                new { Name = "Rubber Soul", Value = 24 }, 
                new { Name = "Khan", Value = 25 }
            };
            characterComboBox.DisplayMember = "Name";
            characterComboBox.ValueMember = "Value";

            hitboxControlAtk1.Editor = this;
            hitboxControlAtk2.Editor = this;
            hitboxControlHead.Editor = this;
            hitboxControlTorso.Editor = this;
            hitboxControlLegs.Editor = this;
            hitboxControlCol.Editor = this;
        }

        private void drawResizedImage()
        {
            var bitmap = new Bitmap(16 * 32, 16 * 32);
            spritePictureBox.BackColor = sprite.BackColor;
            var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(sprite.BackColor);
            //graphics.DrawImage(sprite.Image, new Rectangle(256 + sprite.XOffset, 256 + sprite.YOffset, sprite.Image.Width, sprite.Image.Height),
            //    new Rectangle(0, 0 ,sprite.Image.Width, sprite.Image.Height), GraphicsUnit.Pixel);
            graphics.DrawImage(sprite.Image, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                new Rectangle(0, 0, sprite.Image.Width, sprite.Image.Height), GraphicsUnit.Pixel);
            
            graphics.DrawImage(hitbox.Image, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                new Rectangle(0, 0, hitbox.Image.Width, hitbox.Image.Height), GraphicsUnit.Pixel);
            graphics.Dispose();

            if (spritePictureBox.Image == null)
            {
                spritePictureBox.Image = new Bitmap(bitmap.Width * 2, bitmap.Height * 2);
            }
            graphics = Graphics.FromImage(spritePictureBox.Image);
            graphics.Clear(sprite.BackColor);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics.DrawImage(bitmap, new Rectangle(0, 0, spritePictureBox.Image.Width, spritePictureBox.Image.Height),
                new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
            graphics.Dispose();
            bitmap.Dispose();

            spritePictureBox.Refresh();
        }

        private void drawBlack()
        {
            var w = spritePictureBox.Width;
            var h = spritePictureBox.Height;
            var bitmap = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    bitmap.SetPixel(x, y, Color.Black);
                }
            }
            spritePictureBox.Image = bitmap;
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {

        }

        public void HitboxValueChanged(Hitbox.Type type, int index, short value)
        {
            if (hitbox == null) return;
            Box box = null;
            switch (type)
            {
                case Hitbox.Type.Atk1: box = hitbox.Atk1; break;
                case Hitbox.Type.Atk2: box = hitbox.Atk2; break;
                case Hitbox.Type.Head: box = hitbox.Head; break;
                case Hitbox.Type.Torso: box = hitbox.Torso; break;
                case Hitbox.Type.Legs: box = hitbox.Legs; break;
                case Hitbox.Type.Col: box = hitbox.Col; break;
            }
            switch (index)
            {
                case 0: box.X = value;  break;
                case 1: box.Y = value; break;
                case 2: box.W = value; break;
                case 3: box.H = value; break;
            }
            hitbox.DrawHitboxes();
            drawResizedImage();
        }

        private void LoadMoves()
        {
            moveComboBox.DataSource = new MoveItem[]
            {
                new MoveItem() { Name = "5A", Sprite = 0x69DA650, Hitbox = 4},
                new MoveItem() { Name = "6B", Sprite = 0x69DAC70, Hitbox = 5},
                new MoveItem() { Name = "5B", Sprite = 0x69DB3CC, Hitbox = 6},
                new MoveItem() { Name = "2A", Sprite = 0x69DC7F8, Hitbox = 8}
            };
            moveComboBox.DisplayMember = "Name";
        }

        private void LoadBoxes()
        {
            hitboxControlAtk1.LoadBox(hitbox.Atk1);
            hitboxControlAtk2.LoadBox(hitbox.Atk2);
            hitboxControlHead.LoadBox(hitbox.Head);
            hitboxControlTorso.LoadBox(hitbox.Torso);
            hitboxControlLegs.LoadBox(hitbox.Legs);
            hitboxControlCol.LoadBox(hitbox.Col);
        }

        private void moveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var moveItem = moveComboBox.SelectedItem as MoveItem;
            var character = (int)characterComboBox.SelectedValue;
            sprite = new Sprite(moveItem.Sprite, character);
            hitbox = new Hitbox(moveItem.Hitbox, character);
            LoadBoxes();
            drawResizedImage();
        }
        private void characterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var moveItem = moveComboBox.SelectedItem as MoveItem;
            var character = (int)characterComboBox.SelectedValue;
            sprite = new Sprite(moveItem.Sprite, character);
            hitbox = new Hitbox(moveItem.Hitbox, character);
            LoadBoxes();
            drawResizedImage();
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
                try
                {
                    using (var progressDialog = new ProgressDialog(openFileDialog.FileName, true))
                    {
                        progressDialog.ShowDialog(this);
                    }

                    tabControl.Enabled = true;

                    LoadMoves();
                    LoadBoxes();
                    drawResizedImage();

                    Rom.Path = openFileDialog.FileName;
                    saveToolStripMenuItem.Enabled = true;
                    saveAsToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var progressDialog = new ProgressDialog(saveFileDialog.FileName, false))
                    {
                        progressDialog.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}