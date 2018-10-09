using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class FieldrefInfo : RefInfo
    {
        public FieldrefInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Methodref) { }
    }
}
