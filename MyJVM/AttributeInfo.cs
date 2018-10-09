using System;
using System.Collections.Generic;
using System.Text;
using MyJVM.ConstantPool;
using MyJVM.ConstantPool.Info;

namespace MyJVM
{
    class AttributeInfo
    {
        public string Name { get; }
        public byte[] Data { get; }

        public AttributeInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolInfo[] poolInfos)
        {
            ushort nameIndex = fileData.ReadTwoBytes();
            Name = ((Utf8Info)poolInfos[nameIndex]).StringValue;

            uint length = fileData.ReadFourBytes();
            Data = new byte[length];

            fileData.Slice(0, (int)length).CopyTo(Data);
            fileData = fileData.Slice((int)length);
        }
    }
}
