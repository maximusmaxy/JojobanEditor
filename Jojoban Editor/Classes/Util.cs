using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jojoban_Editor
{
    public static class Util
    {
        public static byte GetByte(this byte[] arr, int index)
        {
            return arr[index];
        }

        public static ushort GetWord(this byte[] arr, int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                int result = arr[index] << 8;
                result += arr[index + 1];
                return (ushort)result;
            }
            else
            {
                return BitConverter.ToUInt16(arr, index);
            }
        }

        public static short GetWordSigned(this byte[] arr, int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                int result = arr[index] << 8;
                result += arr[index + 1];
                if (result > 0x7FFF)
                    result -= 0x10000;
                return (short)result;
            }
            else
            {
                return BitConverter.ToInt16(arr, index);
            }
        }

        public static uint GetDoubleWord(this byte[] arr, int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                uint result = arr[index + 3];
                result += (uint)arr[index + 2] << 8;
                result += (uint)arr[index + 1] << 16;
                result += (uint)arr[index] << 24;
                return result;
            }
            else
            {
                return BitConverter.ToUInt32(arr, index);
            }
        }

        public static void SetDoubleWord(this byte[] arr, uint value, int index)
        {
            for (int i = 0; i < 4; i++)
            {
                arr[index + i] = (byte)((value >> 8 * (3 - i)) & 0xFF);
            }
        }

        public static void SetWordSigned(this byte[] arr, short value, int index)
        {
            arr[index] = (byte)(value >> 8);
            arr[index + 1] = (byte)(value & 0xFF);
        }

        public static bool EntryExists(this ZipArchive archive, string path)
        {
            return archive.GetEntry(path) != null;
        }

        public static void DrawPlus(this Bitmap bitmap, int x, int y)
        {
            bitmap.SetPixel(x - 2, y, Color.White);
            bitmap.SetPixel(x - 1, y, Color.White);
            bitmap.SetPixel(x, y, Color.White);
            bitmap.SetPixel(x + 1, y, Color.White);
            bitmap.SetPixel(x + 2, y, Color.White);
            bitmap.SetPixel(x, y - 2, Color.White);
            bitmap.SetPixel(x, y - 1, Color.White);
            bitmap.SetPixel(x, y + 1, Color.White);
            bitmap.SetPixel(x, y + 2, Color.White);
        }
    }
}
