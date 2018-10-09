using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class Utf8Info : ConstantPoolInfo
    {
        private ushort length;
        public string StringValue { get; }

        public Utf8Info(ref ReadOnlySpan<byte> fileData) : base(ConstantPoolTag.Utf8)
        {
            length = fileData.ReadTwoBytes();
            ReadOnlySpan<byte> span = fileData.Slice(0, length);

            fileData = fileData.Slice(length);

            StringValue = Encoding.UTF8.GetString(span);
        }
    }
}
