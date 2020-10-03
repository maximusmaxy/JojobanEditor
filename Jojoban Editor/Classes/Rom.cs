using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Jojoban_Editor
{
    public class Rom
    {
        public static string Path { get; set; }
        public static Rom Ten { get; set; }
        public static Rom Twenty { get; set; }
        public static Rom Thirty { get; set; }
        public static Rom ThirtyOne { get; set; }
        public static Rom Forty { get; set; }
        public static Rom FortyOne { get; set; }
        public static Rom Fifty { get; set; }
        public static Rom FiftyOne { get; set; }

        public static Rom[] Roms { get; set; }

        public static uint key1 = 0x23323EE3;
        public static uint key2 = 0x03021972;

        public static void LoadRoms(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    var simm = ArchiveType(archive);
                    Ten = new Rom(archive, "10", simm, true, 0x6000000);
                    Twenty = new Rom(archive, "20", simm, true, 0x6800000);
                    Thirty = new Rom(archive, "30", simm, false, 0x0000000);
                    ThirtyOne = new Rom(archive, "31", simm, false, 0x0800000);
                    Forty = new Rom(archive, "40", simm, false, 0x1000000);
                    FortyOne = new Rom(archive, "41", simm, false, 0x1800000);
                    Fifty = new Rom(archive, "50", simm, false, 0x2000000);
                    FiftyOne = new Rom(archive, "51", simm, false, 0x2800000);
                    Path = path;
                }
            }
        }

        public static void SaveRoms(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Update))
                {
                    var simm = ArchiveType(archive);
                    var buffer = new byte[0x800000];
                    Ten.Save(archive, simm, buffer);
                    Twenty.Save(archive, simm, buffer);
                    Thirty.Save(archive, simm);
                    ThirtyOne.Save(archive, simm);
                    Forty.Save(archive, simm);
                    FortyOne.Save(archive, simm);
                    Fifty.Save(archive, simm);
                    FiftyOne.Save(archive, simm);
                }
            }
        }

        public static bool ArchiveType(ZipArchive archive)
        {
            if (archive.EntryExists("jojoba-simm1.0"))
            {
                return true;
            }
            else if (archive.EntryExists("10"))
            {
                return false;
            }
            else
            {
                throw new Exception("No 10 or jojoba-simm1.0 file found.");
            }
        }

        public static bool IsUpdated()
        {
            if (Path == null)
            {
                return false;
            }
            return GetRoms().Any(r => r.updated);
        }

        public static Rom[] GetRoms()
        {
            return new Rom[] { Ten, Twenty, Thirty, ThirtyOne, Forty, FortyOne, Fifty, FiftyOne };
        }

        public byte[] Bytes { get; set; }
        public int Offset { get; set; }
        public string Name { get; set; }
        public bool Encrypted { get; set; }

        private bool updated { get; set; }

        public Rom(ZipArchive archive, string name, bool simm, bool encrypted, int offset = 0)
        {
            Name = name;
            Bytes = new byte[0x800000];
            Offset = offset;
            Encrypted = encrypted;
            updated = false;
            Load(archive, simm);
        }

        public void Load(ZipArchive archive, bool simm)
        {
            if (simm)
            {
                var num = Name[1] == '0' ? 0 : 4;
                for (int i = 0; i < 4; i++)
                {
                    var ext = num == 0 ? i : i + 4;
                    ZipArchiveEntry file = archive.GetEntry($"jojoba-simm{Name[0]}.{ext}");
                    using (var stream = new BinaryReader(file.Open()))
                    {
                        if (Encrypted)
                        {
                            for (int j = 0; j < 0x200000; j++)
                            {
                                Bytes[(j * 4) + i] = stream.ReadByte();
                            }
                        }
                        else
                        {
                            if (i < 2)
                            {
                                for (int j = 0; j < 0x200000; j++)
                                {
                                    Bytes[(j * 2) + i] = stream.ReadByte();
                                }
                            }
                            else
                            {
                                for (int j = 0; j < 0x200000; j++)
                                {
                                    Bytes[0x400000 + (j * 2) + (i - 2)] = stream.ReadByte();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ZipArchiveEntry file = archive.GetEntry(Name);

                using (var stream = new BinaryReader(file.Open()))
                {
                    Bytes = stream.ReadBytes(0x800000);
                }
            }
            if (Encrypted)
            {
                for (int i = 0; i < Bytes.Length; i += 4)
                {
                    uint dword = GetDoubleWord(i);
                    uint xorMask = Cps3Mask((uint)(Offset + i), key1, key2);
                    uint result = dword ^ xorMask;
                    SetDoubleWord(result, i);
                }
            }
        }

        public void Save(ZipArchive archive, bool simm, byte[] buffer = null)
        {
            if (!updated) return;
            byte[] writeBytes;

            if (Encrypted)
            {
                Array.Copy(Bytes, buffer, Bytes.Length);
                for (int i = 0; i < buffer.Length; i += 4)
                {
                    uint dword = buffer.GetDoubleWord(i);
                    uint xorMask = Cps3Mask((uint)(Offset + i), key1, key2);
                    uint result = dword ^ xorMask;
                    buffer.SetDoubleWord(result, i);
                }
                writeBytes = buffer;
            }
            else
            {
                writeBytes = Bytes;
            }
            if (simm)
            {
                var num = Name[1] == '0' ? 0 : 4;
                for (int i = 0; i < 4; i++)
                {
                    var ext = num == 0 ? i : i + 4;
                    ZipArchiveEntry file = archive.GetEntry($"jojoba-simm{Name[0]}.{ext}");
                    using (var stream = new BinaryWriter(file.Open()))
                    {
                        if (Encrypted)
                        {
                            for (int j = 0; j < 0x200000; j++)
                            {
                                stream.Write(writeBytes[(j * 4) + i]);
                            }
                        }
                        else
                        {
                            if (i < 2)
                            {
                                for (int j = 0; j < 0x200000; j++)
                                {
                                    stream.Write(writeBytes[(j * 2) + i]);
                                }
                            }
                            else
                            {
                                for (int j = 0; j < 0x200000; j++)
                                {
                                    stream.Write(writeBytes[0x400000 + (j * 2) + (i - 2)]);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ZipArchiveEntry file = archive.GetEntry(Name);
                using (var tenStream = new BinaryWriter(file.Open()))
                {
                    tenStream.Write(writeBytes);
                }
            }
            updated = false;
        }

        private ushort RotateLeft(ushort value, int n)
        {
            int aux = value >> (16 - n);
            return (ushort)(((value << n) | aux) % 0x10000);
        }

        private ushort RotateXor(ushort val, ushort xorval)
        {
            ushort res = (ushort)(val + RotateLeft(val, 2));
            res = (ushort)(RotateLeft(res, 4) ^ (res & (val ^ xorval)));
            return res;
        }

        private uint Cps3Mask(uint address, uint key1, uint key2)
        {
            address ^= key1;
            ushort val = (ushort)((address & 0xFFFF) ^ 0xFFFF);
            val = RotateXor(val, (ushort)(key2 & 0xFFFF));
            val ^= (ushort)((address >> 16) ^ 0xFFFF);
            val = RotateXor(val, (ushort)(key2 >> 16));
            val ^= (ushort)((address & 0xFFFF) ^ (key2 & 0xFFFF));
            return (uint)(val | (val << 16));
        }

        public byte GetByte(int index)
        {
            return Bytes[index];
        }

        public ushort GetWord(int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                int result = Bytes[index] << 8;
                result += Bytes[index + 1];
                return (ushort)result;
            }
            else
            {
                return BitConverter.ToUInt16(Bytes, index);
            }
        }

        public short GetWordSigned(int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                int result = Bytes[index] << 8;
                result += Bytes[index + 1];
                if (result > 0x7FFF)
                    result -= 0x10000;
                return (short)result;
            }
            else
            {
                return BitConverter.ToInt16(Bytes, index);
            }
        }

        public uint GetDoubleWord(int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                uint result = Bytes[index + 3];
                result += (uint)Bytes[index + 2] << 8;
                result += (uint)Bytes[index + 1] << 16;
                result += (uint)Bytes[index] << 24;
                return result;
            }
            else
            {
                return BitConverter.ToUInt32(Bytes, index);
            }
        }

        private void SetDoubleWord(uint value, int index)
        {
            for (int i = 0; i < 4; i++)
            {
                Bytes[index + i] = (byte)((value >> 8 * (3 - i)) & 0xFF);
            }
        }

        public void WriteWordSigned(int index, short value)
        {
            if (!updated)
            {
                if (value != GetWordSigned(index))
                {
                    updated = true;
                    EditorForm.Current.MarkUpdated();
                }
            }
            Bytes[index] = (byte)(value >> 8);
            Bytes[index + 1] = (byte)(value & 0xFF);
        }

        public Rom NextRom()
        {
            return Roms[Array.IndexOf(Roms, this) + 1];
        }
    }
}
