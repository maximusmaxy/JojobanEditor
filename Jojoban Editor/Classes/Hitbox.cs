using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jojoban_Editor
{
    public class Hitbox
    {
        public enum Type
        {
            Atk1, Atk2, Head, Torso, Legs, Col
        }
        public Bitmap Image { get; set; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }
        public Box Atk1 { get; set; }
        public Box Atk2 { get; set; }
        public Box Head { get; set; }
        public Box Torso { get; set; }
        public Box Legs { get; set; }
        public Box Col { get; set; }

        private int hitbox;
        private int character;
        public Hitbox(int hitbox, int character)
        {
            this.hitbox = hitbox;
            this.character = character;
            Image = new Bitmap(16 * 32, 16 * 32);
            GetHitboxes();
            DrawHitboxes();
        }

        private void GetHitboxes()
        {
            var jotaroOffset = 0x61DEE9E;

            var offset = jotaroOffset - 0x6000000;

            var atk1 = Rom.Ten.Bytes.GetWordSigned(offset + hitbox * 0x10);
            var atk2 = Rom.Ten.Bytes.GetWordSigned(offset + hitbox * 0x10 + 0x02);
            var head = Rom.Ten.Bytes.GetWordSigned(offset + hitbox * 0x10 + 0x04);
            var torso = Rom.Ten.Bytes.GetWordSigned(offset + hitbox * 0x10 + 0x06);
            var legs = Rom.Ten.Bytes.GetWordSigned(offset + hitbox * 0x10 + 0x08);
            var col = Rom.Ten.Bytes.GetWordSigned(offset + hitbox * 0x10 + 0x0A);

            var green = new Pen(Color.FromArgb(0x00, 0xFF, 0x00));
            var blue = new Pen(Color.FromArgb(0x00, 0x40, 0xFF));
            var orange = new Pen(Color.FromArgb(0xFF, 0x80, 0x00));
            var red = new Pen(Color.FromArgb(0xFF, 0x00, 0x00));

            Atk1 = GetBox(atk1, character, red);
            Atk2 = GetBox(atk2, character, orange);
            Head = GetBox(head, character, blue);
            Torso = GetBox(torso, character, blue);
            Legs = GetBox(legs, character, blue);
            Col = GetBox(col, character, green);
        }

        private Box GetBox(int address, int character, Pen color)
        {
            if (address == 0) return null;
            var offset = 0x700000 + character * 0x1002 + address * 0x08 + 0x02;
            var x = Rom.Ten.Bytes.GetWordSigned(offset);
            var w = Rom.Ten.Bytes.GetWordSigned(offset + 0x02);
            var y = Rom.Ten.Bytes.GetWordSigned(offset + 0x04);
            var h = Rom.Ten.Bytes.GetWordSigned(offset + 0x06);
            return new Box()
            {
                Address = offset,
                X = x,
                Y = y,
                W = w,
                H = h,
                Color = color
            };
        }

        public void DrawHitboxes()
        {
            var graphics = Graphics.FromImage(Image);
            graphics.Clear(Color.Transparent);
            DrawBox(graphics, Col);
            DrawBox(graphics, Head);
            DrawBox(graphics, Torso);
            DrawBox(graphics, Legs);
            DrawBox(graphics, Atk1);
            DrawBox(graphics, Atk2);
            graphics.Dispose();
        }

        private void DrawBox(Graphics graphics, Box box)
        {
            if (box == null) return;
            graphics.DrawRectangle(box.Color, box.X + 256 + 7, 256 - box.Y - box.H + 10, box.W, box.H);
        }
    }
}
