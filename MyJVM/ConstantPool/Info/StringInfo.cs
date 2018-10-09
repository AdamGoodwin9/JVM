using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class StringInfo : ClassStringInfo
    {
        public StringInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.String) { }
    }
}
