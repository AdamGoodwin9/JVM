using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool
{
    abstract class IntegerFloatInfo : ConstantPoolInfo
    {
        public int IntegerValue { get; }

        public IntegerFloatInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolTag tag) : base(tag)
        {
            IntegerValue = (int)fileData.ReadFourBytes();
        }
    }
}
