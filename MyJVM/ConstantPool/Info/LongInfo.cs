using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class LongInfo : LongDoubleInfo
    {
        public LongInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Long) { }
    }
}