using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class InterfaceMethodrefInfo : RefInfo
    {
        public InterfaceMethodrefInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Methodref) { }
    }
}