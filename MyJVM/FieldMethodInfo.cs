using MyJVM.ConstantPool;
using MyJVM.ConstantPool.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM
{
    abstract class FieldMethodInfo
    {
        public ushort AccessFlags { get; }

        public string Name { get; }
        public string Descriptor { get; }

        public AttributeInfo[] AttributeInfos { get; }

        public FieldMethodInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolInfo[] infos)
        {
            AccessFlags = fileData.ReadTwoBytes();

            ushort nameIndex = fileData.ReadTwoBytes();
            Name = ((Utf8Info)infos[nameIndex]).StringValue;

            ushort descriptorIndex = fileData.ReadTwoBytes();
            Descriptor = ((Utf8Info)infos[descriptorIndex]).StringValue;

            ushort attributesCount = fileData.ReadTwoBytes();

            AttributeInfos = new AttributeInfo[attributesCount];
        }
    }
}
