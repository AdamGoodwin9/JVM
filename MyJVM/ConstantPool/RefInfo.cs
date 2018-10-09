using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool
{
    abstract class RefInfo : ConstantPoolInfo
    {
        private readonly ushort classIndex;
        private readonly ushort nameAndTypeIndex;

        public string ClassName { get; private set; }
        public string RefName { get; private set; }
        public string Descriptor { get; private set; }

        public RefInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolTag tag) : base(tag)
        {
            classIndex = fileData.ReadTwoBytes();
            nameAndTypeIndex = fileData.ReadTwoBytes();
        }

        public override void Init(ReadOnlySpan<ConstantPoolInfo> infos)
        {
            infos[classIndex].Init(infos);
            ClassName = ((Info.ClassInfo)infos[classIndex]).Value;

            infos[nameAndTypeIndex].Init(infos);
            RefName = ((Info.NameAndTypeInfo)infos[nameAndTypeIndex]).Name;
            Descriptor = ((Info.NameAndTypeInfo)infos[nameAndTypeIndex]).Descriptor;
        }
    }
}
