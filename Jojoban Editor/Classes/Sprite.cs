using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jojoban_Editor
{
    public class Sprite
    {
        public int Address { get; set; }
        public Bitmap Image { get; set; }
        public Color BackColor { get; set; }

        private Color[] palette;
        private ushort[] lookupBlock;
        private Color[] cRam;
        private int cRamIndex;
        private Color previousColor;
        private int character;

        public Sprite(int address, int character)
        {
            Address = address;

            BackColor = Color.Green;
            this.character = character;
            Image = GetImage();
        }

        public Bitmap GetImage() { 
            //Palette
            palette = new Color[0x40];
            var paletteAddress = 0x0336400 + character * 0xC80;
            for (int i = 0; i < palette.Length; i++)
            {
                var colorBytes = Rom.FiftyOne.Bytes.GetWord(paletteAddress + i * 2);
                var r = colorBytes & 0x1F;
                var g = (colorBytes >> 5) & 0x1F;
                var b = (colorBytes >> 10) & 0x1F;
                palette[i] = Color.FromArgb(r * 8, g * 8, b * 8);
            }

            //Lookup Block
            lookupBlock = new ushort[0x80];
            for (int i = 0; i < lookupBlock.Length; i++)
            {
                lookupBlock[i] = Rom.Forty.Bytes.GetWord(0x430000 + i * 2);
            }

            //Tile Data
            var headerOffset = Address - 0x6800000;
            var header1 = Rom.Twenty.Bytes.GetWord(headerOffset);
            var header2 = Rom.Twenty.Bytes.GetWord(headerOffset + 0x2);
            var header3 = Rom.Twenty.Bytes.GetWord(headerOffset + 0x4);
            var cRamSize = Rom.Twenty.Bytes.GetWord(headerOffset + 0x6);
            var tileDataSize = Rom.Twenty.Bytes.GetWord(headerOffset + 0x8);
            var tileGroupSize = Rom.Twenty.Bytes.GetWord(headerOffset + 0xA);
            var tileCount = (cRamSize + 1) / 2;
            cRam = new Color[tileCount * 0x100];
            for (int i = 0; i < tileDataSize; i++)
            {
                var tileAddress = Rom.Twenty.Bytes.GetDoubleWord(headerOffset + i * 0x08 + 0xC);
                var tileSize = Rom.Twenty.Bytes.GetWord(headerOffset + i * 0x08 + 0x10);
                var tilePosition = Rom.Twenty.Bytes.GetWord(headerOffset + i * 0x08 + 0x12);
                AddCRam(tileAddress, tileSize, tilePosition);
            }

            //Tile Group
            TileGroup[] tileGroups = new TileGroup[tileGroupSize];
            int groupOffset = headerOffset + tileDataSize * 0x08 + 0xC;
            for (int i = 0; i < tileGroupSize; i++)
            {
                var unknown = Rom.Twenty.Bytes.GetByte(groupOffset + i * 0x08);
                var tileStartOffset = Rom.Twenty.Bytes.GetByte(groupOffset + i * 0x08 + 0x01);
                var flags = Rom.Twenty.Bytes.GetByte(groupOffset + i * 0x08 + 0x02);
                var flipVertical = (flags & 0x08) == 0x08;
                var flipHorizontal = (flags & 0x10) == 0x10;
                var unknown2 = Rom.Twenty.Bytes.GetByte(groupOffset + i * 0x08 + 0x03);
                //12 bit signed numbers using the first 3 nibbles
                var xOffset = Rom.Twenty.Bytes.GetWord(groupOffset + i * 0x08 + 0x04) & 0x0FFF;
                var yOffset = Rom.Twenty.Bytes.GetWord(groupOffset + i * 0x08 + 0x06) & 0x0FFF;
                if (xOffset > 0x7FF)
                {
                    xOffset -= 0x1000;
                }
                if (yOffset > 0x7FF)
                {
                    yOffset -= 0x1000;
                }

                var tileNum = Rom.Twenty.Bytes.GetByte(groupOffset + i * 0x08 + 0x06);
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
                for (int x = 0; x < tileGroup.NumX; x++)
                {
                    for (int y = 0; y < tileGroup.NumY; y++)
                    {
                        int xPos = w + (x * 16);
                        int yPos = h + (y * 16);
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
            var realSize = (size * 2 + 2) * 8;
            var realAddress = address * 2 - 0x1400000;
            var realPosition = position * 0x10;
            cRamIndex = 0;
            int i = 0;
            while (cRamIndex < realSize)
            {
                var data = Rom.Forty.Bytes[realAddress + i];
                if (data < 0x80)
                {
                    AddPixel(data, realPosition, realSize);
                }
                else
                {
                    var word = lookupBlock[data - 0x80];
                    AddPixel(word >> 8, realPosition, realSize);
                    AddPixel(word & 0xFF, realPosition, realSize);
                }
                i++;
            }
        }

        private void AddPixel(int data, int position, int size)
        {
            if (data < 0x40)
            {
                previousColor = data == 0 ? BackColor : palette[data];
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
    }
}
