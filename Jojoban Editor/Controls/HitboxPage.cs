using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Jojoban_Editor
{
    public partial class HitboxPage : UserControl
    {
        private bool loaded;
        private Sprite sprite;
        private Hitbox hitbox;

        public HitboxPage()
        {
            InitializeComponent();

            hitboxControlAtk1.Page = this;
            hitboxControlAtk2.Page = this;
            hitboxControlHead.Page = this;
            hitboxControlTorso.Page = this;
            hitboxControlLegs.Page = this;
            hitboxControlCol.Page = this;

            hitbox = new Hitbox();
        }

        public void OnLoad()
        {
            characterComboBox.DataSource = Character.Characters;
            characterComboBox.DisplayMember = "Name";
            LoadActions();
            loaded = true;
            UpdateHitboxes();
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

        public void UpdateHitbox()
        { 
            hitbox.DrawHitboxes();
            drawResizedImage();
        }

        private void LoadActions()
        {
            var character = (Character)characterComboBox.SelectedItem;
            var actions = character.Actions.Where(a =>
            {
                return a.Frames.Any(f => f.Type == 0);
            });
            if (hitboxCheckBox.Checked)
            {
                actionComboBox.DataSource = actions.Where(a => a.HasHitbox).ToList();
            }
            else
            {
                actionComboBox.DataSource = actions.ToList();
            }
            LoadFrames();
        }

        private void LoadFrames()
        {
            var action = (Action)actionComboBox.SelectedItem;
            if (action == null) return;
            var frames = action.Frames.Where(f => f.Type == 0);
            if (hitboxCheckBox.Checked)
            {
                frameComboBox.DataSource = frames.Where(f => f.HasHitbox).ToList();
            }
            else
            {
                frameComboBox.DataSource = frames.ToList();
            }
        }

        public void LoadBoxes()
        {
            hitboxControlAtk1.LoadBox(hitbox, hitbox.Atk1);
            hitboxControlAtk2.LoadBox(hitbox, hitbox.Atk2);
            hitboxControlHead.LoadBox(hitbox, hitbox.Head);
            hitboxControlTorso.LoadBox(hitbox, hitbox.Torso);
            hitboxControlLegs.LoadBox(hitbox, hitbox.Legs);
            hitboxControlCol.LoadBox(hitbox, hitbox.Col);
        }

        private void actionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loaded) return;
            LoadFrames();
            UpdateHitboxes();

        }
        private void characterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loaded) return;
            LoadActions();
            UpdateHitboxes();
        }

        private void UpdateHitboxes()
        {
            var character = (Character)characterComboBox.SelectedItem;
            var actionFrame = frameComboBox.SelectedItem as ActionFrame;
            if (actionFrame == null) return;
            var update = false;
            if (sprite == null || sprite.Address != actionFrame.SpriteAddress || character != sprite.Character)
            {
                sprite?.Dispose();
                sprite = new Sprite(actionFrame.SpriteAddress, character);
                update = true;
            }
            if (hitbox.Update(actionFrame.Hitbox, character))
            { 
                LoadBoxes();
                update = true;
            }
            if (update)
            {
                drawResizedImage();
            }
        }

        private void hitboxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var action = actionComboBox.SelectedItem as Action;
            var frame = frameComboBox.SelectedItem as ActionFrame;
            LoadActions();
            var actionIndex = actionComboBox.Items.IndexOf(action);
            if (actionIndex > -1)
            {
                actionComboBox.SelectedIndex = actionIndex;
                var frameIndex = frameComboBox.Items.IndexOf(frame);
                if (frameIndex > -1)
                {
                    frameComboBox.SelectedIndex = frameIndex;
                }
            }
            UpdateHitboxes();
        }

        private void frameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loaded) return;
            UpdateHitboxes();
        }
    }
}
