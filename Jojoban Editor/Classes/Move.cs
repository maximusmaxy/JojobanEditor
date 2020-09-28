using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jojoban_Editor
{
    public enum MoveOffset
    {
        Damage = 0x00,
        StandDamage = 0x01,
        MeterOnWhiff = 0x02,
        MeterOnHit = 0x03,
        BlockType = 0x04,
        HitType = 0x05,
        LaunchSpeed = 0x06,
        AirKnockup = 0x07,
        Blocking = 0x08,
        Blocking2 = 0x09,
        Hitstop = 0x0A,
        Knockback = 0x0B,
        Hitspark = 0x0C,
        Byte13 = 0x0D,
        HitEffect = 0x0E,
        ScreenShake = 0x0F,
        Byte10 = 0x10,
        KnockbackOnBlock = 0x11,
        Hitstun = 0x12,
        Blockstun = 0x13,
        Byte14 = 0x14,
        HitSound = 0x15,
        AirBlocking = 0x16,
        KillDenial = 0x17,
        BackgroundFlash = 0x18,
        Parry = 0x19,
        Byte1A = 0x1A,
        Teching = 0x1B,
        Byte1C = 0x1C,
        Byte1D = 0x1D,
        Byte1E = 0x1E,
        Scaling = 0x1F,
        Byte20 = 0x20,
        Byte21 = 0x21,
        Byte22 = 0x22,
        BlazingFists = 0x23,
        IPS = 0x24,
        Byte25 = 0x25,
        Byte26 = 0x26,
        Byte27 = 0x27
    }

    public enum BlockingType {
        Mid = 1,
        Low = 2,
        Overhead = 3
    }

    public enum HitType
    {
        Launch = 0x1D,
        Knockdown = 0x1B,
        Wallbounce = 0x20,
        OffscreenLaunch = 0x27,
        ChildTransform = 0x2A,
        Grab = 0x31,
        InstakillSoftlock = 0x60
    }

    public class Move
    {
        public int Address { get; set; }
        public byte[] Bytes { get; set; }

        public Move(Rom rom, int address)
        {
            Address = address;
            Bytes = new byte[40];
            Array.Copy(rom.Bytes, Address, Bytes, 0, 40);
        }

        public byte Get(MoveOffset offset)
        {
            return Bytes[(int)offset];
        }

        public void Set(MoveOffset offset, byte value)
        {
            Bytes[(int)offset] = value;
        }

        public void Write(Rom rom)
        {
            Array.Copy(Bytes, 0, rom.Bytes, Address, 40);
        }
    }
}
