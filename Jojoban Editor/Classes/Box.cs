using System.Drawing;

namespace Jojoban_Editor
{
    public class Box
    {
        public int Index { get; set; }
        public int Address { get; set; }
        public Pen Color { get; set; }
        public Hitbox.Type Type { get; set; }
        public Character Character { get; set; }
        private short x;
        private short y;
        private short w;
        private short h;

        public short X
        {
            get { return x; }
            set
            {
                x = value;
                Rom.Ten.WriteWordSigned(Address + 0x00, value);
            }
        }
        public short Y
        {
            get { return y; }
            set
            {
                y = value;
                Rom.Ten.WriteWordSigned(Address + 0x04, value);
            }
        }
        public short W
        {
            get { return w; }
            set
            {
                w = value;
                Rom.Ten.WriteWordSigned(Address + 0x02, value);
            }
        }
        public short H
        {
            get { return h; }
            set
            {
                h = value;
                Rom.Ten.WriteWordSigned(Address + 0x06, value);
            }
        }
    }
}
