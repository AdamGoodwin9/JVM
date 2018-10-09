using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool
{
    abstract class ClassStringInfo : ConstantPoolInfo
    {
        private readonly ushort stringIndex;

        public string Value { get; private set; }

        public ClassStringInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolTag tag) : base(tag)
        {
            stringIndex = fileData.ReadTwoBytes();
        }

        public override void Init(ReadOnlySpan<ConstantPoolInfo> infos)
        {
            Value = ((Info.Utf8Info)(infos[stringIndex])).StringValue;
        }
    }
}
