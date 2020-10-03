using System;
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
        private Character character;

        public Hitbox()
        {
            Image = new Bitmap(16 * 32, 16 * 32);
        }

        public bool Update(int hitbox, Character character)
        {
            if (this.hitbox == hitbox && this.character == character) return false;
            this.hitbox = hitbox;
            this.character = character;
            GetHitboxes();
            DrawHitboxes();
            return true;
        }

        private void GetHitboxes()
        {
            var offset = character.HitboxOffset - 0x6000000;

            var atk1 = Rom.Ten.GetWordSigned(offset + hitbox * 0x10);
            var atk2 = Rom.Ten.GetWordSigned(offset + hitbox * 0x10 + 0x02);
            var head = Rom.Ten.GetWordSigned(offset + hitbox * 0x10 + 0x04);
            var torso = Rom.Ten.GetWordSigned(offset + hitbox * 0x10 + 0x06);
            var legs = Rom.Ten.GetWordSigned(offset + hitbox * 0x10 + 0x08);
            var col = Rom.Ten.GetWordSigned(offset + hitbox * 0x10 + 0x0A);

            var green = new Pen(Color.FromArgb(0x00, 0xFF, 0x00));
            var blue = new Pen(Color.FromArgb(0x00, 0x40, 0xFF));
            var orange = new Pen(Color.FromArgb(0xFF, 0x80, 0x00));
            var red = new Pen(Color.FromArgb(0xFF, 0x00, 0x00));

            Atk1 = GetBox(atk1, red, Type.Atk1);
            Atk2 = GetBox(atk2, orange, Type.Atk2);
            Head = GetBox(head, blue, Type.Head);
            Torso = GetBox(torso, blue, Type.Torso);
            Legs = GetBox(legs, blue, Type.Legs);
            Col = GetBox(col, green, Type.Col);
        }

        public void UpdateBoxIndex(Type type, int index)
        {
            switch (type)
            {
                case Type.Atk1:
                    if (Atk1.Index != index) Atk1 = WriteBox(index, 0x00, Atk1);
                    break;
                case Type.Atk2:
                    if (Atk2.Index != index) Atk2 = WriteBox(index, 0x02, Atk2);
                    break;
                case Type.Head:
                    if (Head.Index != index) Head = WriteBox(index, 0x04, Head);
                    break;
                case Type.Torso:
                    if (Torso.Index != index) Torso = WriteBox(index, 0x06, Torso);
                    break;
                case Type.Legs:
                    if (Legs.Index != index) Legs = WriteBox(index, 0x08, Legs);
                    break;
                case Type.Col:
                    if (Col.Index != index) Col = WriteBox(index, 0x0A, Col);
                    break;
            }
        }

        private Box WriteBox(int index, int boxOffset, Box box)
        {
            var hitboxOffset = character.HitboxOffset - 0x6000000;
            Rom.Ten.WriteWordSigned(hitboxOffset + hitbox * 0x10 + boxOffset, (short)index);
            return GetBox(index, box.Color, box.Type);
        }

        private Box GetBox(int index, Pen color, Type type)
        {
            var address = 0x700000 + character.Index * 0x1002 + index * 0x08 + 0x02;
            var x = Rom.Ten.GetWordSigned(address);
            var w = Rom.Ten.GetWordSigned(address + 0x02);
            var y = Rom.Ten.GetWordSigned(address + 0x04);
            var h = Rom.Ten.GetWordSigned(address + 0x06);
            return new Box()
            {
                Index = index,
                Address = address,
                Type = type,
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
