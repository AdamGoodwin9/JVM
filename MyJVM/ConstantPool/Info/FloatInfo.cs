using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class FloatInfo : IntegerFloatInfo
    {
        public float FloatValue { get; }

        public FloatInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Float)
        {
            int intValue = IntegerValue;
            FloatValue = Unsafe.As<int, float>(ref intValue);
        }
    }
}