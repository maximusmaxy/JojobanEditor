namespace Jojoban_Editor
{
    public class ActionFrame
    {
        public int Index { get; set; }
        public int Address { get; set; }
        public int Type { get; set; }
        public int Count { get; set; }
        public int SpriteAddress { get; set; }
        public int Hitbox { get; set; }
        public uint Jump { get; set; }
        public int Stop { get; set; }
        public bool HasHitbox { get; set; }
        public override string ToString()
        {
            return Index + (HasHitbox ? "*" : string.Empty);
        }

        //private ushort ct;
        //private ushort ch;
        //private byte cg;
        //private byte c2;
        //private bool s;
        //private byte ac;
        //private byte hc;
        //private byte mc;
        //private byte pr;
        //private byte hv; //hor/ver flag??
    }
}
