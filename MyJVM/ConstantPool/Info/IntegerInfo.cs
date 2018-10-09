using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class IntegerInfo : IntegerFloatInfo
    {
        public IntegerInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Integer) { }
    }
}
