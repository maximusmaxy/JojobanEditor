using System;
using System.Collections.Generic;
using System.Drawing;

namespace Jojoban_Editor
{
    public class Character
    {
        public static List<Character> Characters { get; set; }

        public static void LoadCharacters()
        {
            Characters = new List<Character>()
            {
                new Character(0, "Jotaro", 0x00, 0x61DEE9E, 0x430000, Rom.Forty),
                new Character(0, "Star Platinum", 0x00E7EC8, 0x61DEE9E, 0x00, Rom.Fifty),
                new Character(1, "Kakyoin", 0xC408, 0x61E0FCA, 0x4AB500, Rom.Forty),
                new Character(1, "Heirophant Green", 0xF55B8, 0x61E0FCA, 0x09C100, Rom.Fifty),
                new Character(2, "Avdol", 0x015960, 0x61E52DC, 0x50E500, Rom.Forty),
                new Character(2, "Magicians Red", 0xFE540, 0x61E52DC, 0x0FA700, Rom.Fifty),
                new Character(3, "Polnareff", 0x1CE04, 0x61E73A2, 0x583100, Rom.Forty),
                new Character(3, "Silver Chariot", 0x10C838, 0x61E73A2, 0x197D00, Rom.Fifty),
                new Character(4, "Old Joseph", 0x27028, 0x61EA1EA, 0x5F9800, Rom.Forty),
                new Character(4, "Hermit Purple", 0x11998C, 0x61EA1EA, 0x22A300, Rom.Fifty),
                new Character(5, "Iggy", 0x339D0, 0x61EF37E, 0x6E4200, Rom.Forty),
                new Character(5, "The Fool", 0x126538, 0x61EF37E, 0x3A6A00, Rom.Fifty),
                new Character(6, "Alessy", 0x3B76C, 0x61F18B2, 0x703900, Rom.Forty),
                new Character(6, "Alessy Axe", 0x435DC, 0x61F18B2, 0x703900, Rom.Forty),
                new Character(6, "Sethan", 0x12FDD8, 0x61F18B2, 0x439200, Rom.Fifty),
                new Character(7, "Chaka", 0x49048, 0x61F45D2, 0x00, Rom.FortyOne),
                new Character(7, "Anubis", 0x133AD4, 0x61F45D2, 0xC6D00, Rom.FiftyOne),
                new Character(8, "Devo", 0x514F4, 0x61F66EA, 0x062B00, Rom.FortyOne),
                new Character(8, "Ebony Devil", 0x13D9D4, 0x61F66EA, 0x44F900, Rom.Fifty),
                new Character(9, "N'Doul", 0x5A3F8, 0x61F9372, 0x7C5A00, Rom.Forty),
                new Character(9, "Geb", 0x14D9E8, 0x61F9372, 0x493E00, Rom.Fifty),
                new Character(10, "Midler", 0x5A910, 0x61FC7B8, 0x0D0E00, Rom.FortyOne),
                new Character(10, "High Priestess", 0x155C3C, 0x61FC7B8, 0x4BC700, Rom.Fifty),
                new Character(11, "Dio", 0x196D30, 0x61FDB7E, 0x162B00, Rom.FortyOne),
                new Character(11, "The World", 0x1AE204, 0x61FDB7E, 0x54A700, Rom.Fifty),
                new Character(12, "Boss Ice", 0x192924, 0x61FFE3E, 0x7A5E00, Rom.Forty),
                new Character(12, "Boss Cream", 0x1A9564, 0x61FFE3E, 0x5C9300, Rom.Fifty),
                new Character(13, "Death 13", 0x18F414, 0x62014E2, 0x5E2D00, Rom.Fifty),
                //new Character(13, "Death 13 Scythe", 0x00, 0x62014E2, 0x5E2D00, Rom.Fifty),
                new Character(14, "Shadow Dio", 0x66284, 0x62023EE, 0x20CB00, Rom.FortyOne),
                new Character(14, "Shadow World", 0x16A644, 0x62023EE, 0x621700, Rom.Fifty),
                new Character(15, "Young Joseph", 0x72854, 0x62043BA, 0x278A00, Rom.FortyOne),
                new Character(16, "Hol Horse", 0x07E9A8, 0x620608E, 0x315A00, Rom.FortyOne),
                new Character(17, "Vanilla Ice", 0x87F2C, 0x6208702, 0x3E6A00, Rom.FortyOne),
                new Character(17, "Cream", 0x17357C, 0x6208702, 0x624700, Rom.Fifty),
                new Character(18, "New Kakyoin", 0x90724, 0x620B042, 0x4CE500, Rom.FortyOne),
                new Character(18, "New Heirophant", 0x17C254, 0x620B042, 0x9C100, Rom.Fifty),
                new Character(19, "Black Polnareff", 0x99C1C, 0x620D986, 0x533600, Rom.FortyOne),
                new Character(19, "Anubis Chariot", 0x18520C, 0x620D986, 0x712000, Rom.Fifty),
                new Character(20, "Petshop", 0xA3C7C, 0x620F196, 0x5BF600, Rom.FortyOne),
                new Character(22, "Mariah", 0xAAD3C, 0x62104BE, 0x611600, Rom.FortyOne),
                new Character(23, "Hoingo", 0xB1888, 0x621125C, 0x676600, Rom.FortyOne),
                new Character(24, "Rubber Soul", 0xB9ADC, 0x6212418, 0x6F8600, Rom.FortyOne),
                new Character(24, "Golden Temperance", 0x18B730, 0x6212418, 0x6F8600, Rom.FortyOne),
                new Character(25, "Khan", 0xBEC10, 0x62145B6, 0x75E600, Rom.FortyOne)
            };
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public int HitboxOffset { get; set; }
        public int ActionOffset { get; set; }
        public ushort[] LookupBlock { get; set; }
        public Rom SpriteRom { get; set; }
        public List<Action> Actions { get; set; }
        public Color[][] Palettes { get; set; }
        public Character(int index, string name, int actionOffset, int hitboxOffset, int lookupOffset, Rom spriteRom)
        {
            Index = index;
            Name = name;
            ActionOffset = actionOffset;
            HitboxOffset = hitboxOffset;
            SpriteRom = spriteRom;

            LoadPalettes();
            LoadActions();
            LoadLookupBlock(lookupOffset);
        }

        private void LoadPalettes()
        {
            Palettes = new Color[5][];
            for (int i = 0; i < 5; i++)
            {
                Palettes[i] = new Color[0x40];
                var paletteAddress = 0x0336400 + Index * 0xC80 + i * 0x14500;
                for (int j = 0; j < Palettes[i].Length; j++)
                {
                    var colorBytes = Rom.FiftyOne.GetWord(paletteAddress + j * 2);
                    var r = colorBytes & 0x1F;
                    var g = (colorBytes >> 5) & 0x1F;
                    var b = (colorBytes >> 10) & 0x1F;
                    Palettes[i][j] = Color.FromArgb(Math.Min(r * 8, 0xFF), Math.Min(g * 8, 0xFF), Math.Min(b * 8, 0xFF));
                }
            }
        }

        private void LoadActions()
        {
            var actionLength = Rom.Twenty.GetWord(ActionOffset + 0x02);
            Actions = new List<Action>(actionLength);
            var hitboxDictionary = new Dictionary<int, bool>();
            for (int i = 0; i < actionLength; i++)
            {
                var actionHex = Rom.Twenty.GetDoubleWord(ActionOffset + 0x04 + i * 0x04);
                var actionPointer = (int)(actionHex - 0x6800000);

                var action = new Action()
                {
                    Index = i
                };
                var complete = false;
                int j = 0;
                while (!complete)
                {
                    var type = Rom.Twenty.GetByte(actionPointer);
                    var length = Rom.Twenty.GetByte(actionPointer + 0x01);
                    if (length == 0) break;
                    ActionFrame actionFrame;
                    switch (type)
                    {
                        case 0x00:
                            actionFrame = new ActionFrame()
                            {
                                Address = actionPointer,
                                Stop = Rom.Twenty.GetByte(actionPointer + 0x02),
                                Count = Rom.Twenty.GetByte(actionPointer + 0x03),
                                SpriteAddress = (int)Rom.Twenty.GetDoubleWord(actionPointer + 0x04),
                                Hitbox = Rom.Twenty.GetWord(actionPointer + 0x0C)
                            };
                            if (actionFrame.Stop == 0x80) complete = true;
                            actionFrame.HasHitbox = CheckForHitbox(action, hitboxDictionary, actionFrame.Hitbox);
                            break;
                        case 0x01:
                            actionFrame = new ActionFrame()
                            {
                                Jump = Rom.Twenty.GetDoubleWord(actionPointer + 0x04)
                            };
                            complete = true;
                            break;
                        case 0x02:
                            actionFrame = new ActionFrame()
                            {
                                Stop = Rom.Twenty.GetByte(actionPointer + 0x02),
                                Count = Rom.Twenty.GetByte(actionPointer + 0x03),
                                SpriteAddress = (int)Rom.Twenty.GetDoubleWord(actionPointer + 0x04)
                            };
                            if (actionFrame.Stop == 0x80) complete = true;
                            break;
                        case 0x03:
                            actionFrame = new ActionFrame()
                            {
                                Jump = Rom.Twenty.GetDoubleWord(actionPointer + 0x04)
                            };
                            complete = true;
                            break;
                        case 0x04:
                            actionFrame = new ActionFrame()
                            {
                                Jump = Rom.Twenty.GetDoubleWord(actionPointer + 0x04)
                            };
                            break;
                        case 0x06: //6228 +2 = 1, +3 = 2
                            actionFrame = new ActionFrame()
                            {

                            };
                            break;
                        case 0x07: //62EC +2 = 1, +3 = FF
                            actionFrame = new ActionFrame()
                            {
                            };
                            break;
                        case 0x08: //62F0 +2 = 1, +3 = 0
                            actionFrame = new ActionFrame()
                            {
                            };
                            break;
                        case 0x0B: //
                            actionFrame = new ActionFrame()
                            {
                                Jump = Rom.Twenty.GetDoubleWord(actionPointer + 0x04)
                            };
                            break;
                        case 0x0D: //F1CC0 +2 = 3, +3 = 1
                            actionFrame = new ActionFrame()
                            {
                            };
                            break;
                        case 0x0E: //39D6C +2 = 0 , +3 = 2
                            actionFrame = new ActionFrame()
                            {
                            };
                            complete = true;
                            break;
                        case 0x10: //DB44 +2 = 0, +3 = 2
                            actionFrame = new ActionFrame()
                            {
                            };
                            break;
                        default:
                            actionFrame = new ActionFrame()
                            {
                            };
                            Console.WriteLine(type);
                            break;
                    }
                    actionFrame.Type = type;
                    actionFrame.Index = j;
                    action.Frames.Add(actionFrame);
                    j++;
                    actionPointer += length;
                }
                Actions.Add(action);
            }
        }

        private bool CheckForHitbox(Action action, Dictionary<int, bool> dictionary, int hitbox)
        {
            if (dictionary.ContainsKey(hitbox))
            {
                if (dictionary[hitbox]) action.HasHitbox = true;
                return dictionary[hitbox];
            }
            else
            {
                var offset = HitboxOffset - 0x6000000;
                var atk1 = Rom.Ten.GetWordSigned(offset + hitbox * 0x10);
                var atk2 = Rom.Ten.GetWordSigned(offset + hitbox * 0x10 + 0x02);
                dictionary[hitbox] = atk1 != 0 || atk2 != 0;
                if (dictionary[hitbox]) action.HasHitbox = true;
                return dictionary[hitbox];
            }
        }

        private void LoadLookupBlock(int lookupOffset)
        {
            LookupBlock = new ushort[0x80];
            for (int i = 0; i < LookupBlock.Length; i++)
            {
                LookupBlock[i] = SpriteRom.GetWord(lookupOffset + i * 2);
            }
        }
    }
}
