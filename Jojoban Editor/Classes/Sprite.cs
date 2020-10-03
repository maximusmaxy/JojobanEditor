using System;
using System.Drawing;

namespace Jojoban_Editor
{
    public class Sprite
    {
        public int Address { get; set; }
        public Bitmap Image { get; set; }
        public Color BackColor { get; set; }
        public int Index { get; set; }
        public Character Character { get; set; }

        private Color[] cRam;
        private int cRamIndex;
        private Color previousColor;

        public Sprite(int address, Character character)
        {
            Address = address;
            BackColor = Color.Green;
            Character = character;

            Image = GetImage();
        }

        public Bitmap GetImage()
        {
            if (Address == 0)
            {
                return new Bitmap(16 * 32, 16 * 32);
            }
            //Tile Data
            var headerOffset = Address - 0x6800000;
            Index = Rom.Twenty.GetWord(headerOffset);
            //var header2 = Rom.Twenty.GetWord(headerOffset + 0x2);
            //var header3 = Rom.Twenty.GetWord(headerOffset + 0x4);
            var cRamSize = Rom.Twenty.GetWord(headerOffset + 0x6);
            var tileDataSize = Rom.Twenty.GetWord(headerOffset + 0x8);
            var tileGroupSize = Rom.Twenty.GetWord(headerOffset + 0xA);
            var tileCount = (cRamSize + 1) / 2;
            cRam = new Color[tileCount * 0x100];
            for (int i = 0; i < tileDataSize; i++)
            {
                var tileAddress = Rom.Twenty.GetDoubleWord(headerOffset + i * 0x08 + 0xC);
                var realAddress = tileAddress * 2 - Character.SpriteRom.Offset - 0x400000;
                if (realAddress < 0 || realAddress >= 0x800000)
                {
                    return new Bitmap(16 * 32, 16 * 32);
                }
                var tileSize = Rom.Twenty.GetWord(headerOffset + i * 0x08 + 0x10);
                var tilePosition = Rom.Twenty.GetWord(headerOffset + i * 0x08 + 0x12);
                var realSize = (tileSize * 2 + 2) * 8;
                var realPosition = tilePosition * 0x10;
                AddCRam((uint)realAddress, realSize, realPosition);
            }

            //Tile Group
            TileGroup[] tileGroups = new TileGroup[tileGroupSize];
            int groupOffset = headerOffset + tileDataSize * 0x08 + 0xC;
            for (int i = 0; i < tileGroupSize; i++)
            {
                var unknown = Rom.Twenty.GetByte(groupOffset + i * 0x08);
                var tileStartOffset = Rom.Twenty.GetByte(groupOffset + i * 0x08 + 0x01);
                var flags = Rom.Twenty.GetByte(groupOffset + i * 0x08 + 0x02);
                var flipVertical = (flags & 0x08) == 0x08;
                var flipHorizontal = (flags & 0x10) == 0x10;
                var unknown2 = Rom.Twenty.GetByte(groupOffset + i * 0x08 + 0x03);
                //12 bit signed numbers using the first 3 nibbles
                var xOffset = Rom.Twenty.GetWord(groupOffset + i * 0x08 + 0x04) & 0x0FFF;
                var yOffset = Rom.Twenty.GetWord(groupOffset + i * 0x08 + 0x06) & 0x0FFF;
                if (xOffset > 0x7FF)
                {
                    xOffset -= 0x1000;
                }
                if (yOffset > 0x7FF)
                {
                    yOffset -= 0x1000;
                }

                var tileNum = Rom.Twenty.GetByte(groupOffset + i * 0x08 + 0x06);
                var numX = (tileNum & 0x30) >> 4;
                var numY = (tileNum & 0xC0) >> 6;

                //1, 2, 4, 8 ect.
                numX = 1 << numX - 1;
                numY = 1 << numY - 1;

                //adjusted offset
                xOffset += (1 - numX) * 8;
                yOffset += (1 - numY) * 8;

                tileGroups[i] = new TileGroup
                {
                    StartOffset = tileStartOffset,
                    FlipHorizontal = flipHorizontal,
                    FlipVertical = flipVertical,
                    XOffset = xOffset,
                    YOffset = yOffset,
                    NumX = numX,
                    NumY = numY
                };
            }

            //Bitmap
            //var xMax = tileGroups[0].XOffset + 16 * tileGroups[0].NumX;
            //var xMin = tileGroups[0].XOffset;
            //var yMax = tileGroups[0].YOffset + 16 * tileGroups[0].NumY;
            //var yMin = tileGroups[0].YOffset;
            //for (int i = 1; i < tileGroups.Length; i++)
            //{
            //    var tileGroup = tileGroups[i];
            //    if (tileGroup.XOffset + 16 * tileGroup.NumX > xMax) xMax = tileGroup.XOffset + 16 * tileGroup.NumX;
            //    if (tileGroup.XOffset < xMin) xMin = tileGroup.XOffset;
            //    if (tileGroup.YOffset + 16 * tileGroup.NumY > yMax) yMax = tileGroup.YOffset + 16 * tileGroup.NumY;
            //    if (tileGroup.YOffset < yMin) yMin = tileGroup.YOffset;
            //}

            //var bitmap = new Bitmap(xMax - xMin, yMax - yMin);
            //XOffset = xMin;
            //YOffset = yMin;

            var bitmap = new Bitmap(16 * 32, 16 * 32);

            for (int i = 0; i < tileGroups.Length; i++)
            {
                var tileGroup = tileGroups[i];
                //int w = tileGroup.XOffset - xMin;
                //int h = tileGroup.YOffset - yMin;
                int w = tileGroup.XOffset + 256;
                int h = tileGroup.YOffset + 256;
                if (w < 0 || w >= bitmap.Width || h < 0 || h >= bitmap.Height)
                {
                    continue;
                }
                for (int x = 0; x < tileGroup.NumX; x++)
                {
                    for (int y = 0; y < tileGroup.NumY; y++)
                    {
                        int xPos = w + ((tileGroup.FlipHorizontal ? tileGroup.NumX - x - 1 : x) * 16);
                        int yPos = h + ((tileGroup.FlipVertical ? tileGroup.NumY - y - 1 : y) * 16);
                        int tile = x * tileGroup.NumY + y;
                        DrawTile(bitmap, tileGroup.StartOffset / 2 + tile, xPos, yPos,
                            tileGroup.FlipHorizontal, tileGroup.FlipVertical);
                    }
                }
            }

            return bitmap;
        }

        private void AddCRam(uint address, int size, int position)
        {
            cRamIndex = 0;
            int i = 0;
            while (cRamIndex < size)
            {
                var data = Character.SpriteRom.Bytes[address + i];
                if (data < 0x80)
                {
                    AddPixel(data, position, size);
                }
                else
                {
                    var word = Character.LookupBlock[data - 0x80];
                    AddPixel(word >> 8, position, size);
                    AddPixel(word & 0xFF, position, size);
                }
                i++;
            }
        }

        private void AddPixel(int data, int position, int size)
        {
            if (data < 0x40)
            {
                previousColor = data == 0 ? BackColor : Character.Palettes[0][data];
                cRam[cRamIndex + position] = previousColor;
                cRamIndex++;
            }
            else
            {
                for (int i = 0; i < data - 0x3F; i++)
                {
                    cRam[cRamIndex + position] = previousColor;
                    cRamIndex++;
                    if (cRamIndex > size) return;
                }
            }
        }

        private void DrawTile(Bitmap bitmap, int tile, int w, int h, bool flipX, bool flipY)
        {
            for (int i = 0; i < 256; i++)
            {
                int x = flipX ? 15 - i % 16 : i % 16;
                int y = flipY ? 15 - i / 16 : i / 16;
                bitmap.SetPixel(x + w, y + h, cRam[tile * 0x100 + i]);
            }
        }

        public void Dispose()
        {
            Image?.Dispose();
        }
    }
}