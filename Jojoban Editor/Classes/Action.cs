using System.Collections.Generic;

namespace Jojoban_Editor
{
    public class Action
    {
        public int Index { get; set; }
        public List<ActionFrame> Frames { get; set; }
        public bool HasHitbox { get; set; }

        public Action()
        {
            Frames = new List<ActionFrame>();
        }

        public override string ToString()
        {
            return Index + (HasHitbox ? "*" : string.Empty);
        }
    }
}
