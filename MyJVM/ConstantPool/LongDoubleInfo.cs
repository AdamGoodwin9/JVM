using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool
{
    abstract class LongDoubleInfo : ConstantPoolInfo
    {
        public int HighBytes { get; }
        public int LowBytes { get; }

        public long LongValue { get; }

        public LongDoubleInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolTag tag) : base(tag)
        {
            HighBytes = (int)fileData.ReadFourBytes();
            LowBytes = (int)fileData.ReadFourBytes();

            LongValue = (long)((((ulong)HighBytes) << 32) & (ulong)LowBytes);
        }
    }
}
