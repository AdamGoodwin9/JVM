using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class MethodrefInfo : RefInfo
    {
        public MethodrefInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Methodref) { }
    }
}
