using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MyJVM
{
    public static class Utilities
    {
        public static long Construct(int high, int low)
        {
            ulong uhigh = ((ulong)high) << 32;
            return (long)(uhigh | (uint)low);
        }

        public static void Deconstruct(this long num, out int high, out int low)
        {
            high = (int)((ulong)num >> 32);
            low = (int)(num & -1);
        }


        public static uint SwapEndianness(this uint input)
        {
            uint ret = 0;

            uint byte1 = input & 0x_FF_00_00_00;
            uint byte2 = input & 0x_00_FF_00_00;
            uint byte3 = input & 0x_00_00_FF_00;
            uint byte4 = input & 0x_00_00_00_FF;

            ret = ret | (byte1 >> (8 * 3));
            ret = ret | (byte2 >> (8 * 1));
            ret = ret | (byte3 << (8 * 1));
            ret = ret | (byte4 << (8 * 3));

            return ret;
        }

        public static ushort SwapEndianness(this ushort input)
        {
            ushort ret = 0;

            ushort byte1 = (ushort)(input & 0x_FF_00);
            ushort byte2 = (ushort)(input & 0x_00_FF);

            ret = (ushort)((byte2 << 8) | (byte1 >> 8));

            return ret;
        }

        public static uint ReadFourBytes(this ref ReadOnlySpan<byte> data)
        {
            ReadOnlySpan<uint> intData = MemoryMarshal.Cast<byte, uint>(data);
            uint result = BitConverter.IsLittleEndian ? intData[0].SwapEndianness() : intData[0];
            data = data.Slice(4);
            return result;
        }

        public static ushort ReadTwoBytes(this ref ReadOnlySpan<byte> data)
        {
            ReadOnlySpan<ushort> shortData = MemoryMarshal.Cast<byte, ushort>(data);


            ushort result = BitConverter.IsLittleEndian ? shortData[0].SwapEndianness() : shortData[0];

            data = data.Slice(2);
            return result;
        }

        public static byte ReadOneByte(this ref ReadOnlySpan<byte> data)
        {
            byte result = data[0];
            data = data.Slice(1);
            return result;
        }
    }
}