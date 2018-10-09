using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class DoubleInfo : LongDoubleInfo
    {
        public double DoubleValue { get; }

        public DoubleInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Double)
        {
            long longValue = LongValue;
            DoubleValue = Unsafe.As<long, double>(ref longValue);
        }
    }
}
