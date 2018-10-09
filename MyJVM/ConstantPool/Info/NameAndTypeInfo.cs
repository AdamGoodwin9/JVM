using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class NameAndTypeInfo : ConstantPoolInfo
    {
        private bool isUpdated;

        private readonly ushort nameIndex;
        private readonly ushort descriptorIndex;

        public string Name { get; private set; }
        public string Descriptor { get; private set; }

        public NameAndTypeInfo(ref ReadOnlySpan<byte> fileData) : base(ConstantPoolTag.NameAndType)
        {
            isUpdated = false;

            nameIndex = fileData.ReadTwoBytes();
            descriptorIndex = fileData.ReadTwoBytes();
        }

        public override void Init(ReadOnlySpan<ConstantPoolInfo> infos)
        {
            if (!isUpdated)
            {
                Name = ((Utf8Info)infos[nameIndex]).StringValue;
                Descriptor = ((Utf8Info)infos[descriptorIndex]).StringValue;

                isUpdated = true;
            }
        }
    }
}
