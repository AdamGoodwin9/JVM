using System;
using System.Collections.Generic;
using System.Text;
using MyJVM.ConstantPool;

namespace MyJVM
{
    class FieldInfo : FieldMethodInfo
    {
        public FieldInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolInfo[] infos) : base(ref fileData, infos) { }
    }
}
