using MyJVM.ConstantPool;
using MyJVM.ConstantPool.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyJVM
{
    class ClassFile
    {
        public ushort MinorVersion { get; }
        public ushort MajorVersion { get; }

        public ConstantPoolInfo[] PoolInfos { get; }
        
        public ushort AccessFlags { get; }

        public ushort ThisClass { get; }
        public ushort SuperClass { get; }

        public string[] Interfaces { get; }
        public FieldInfo[] Fields { get; }
        public MethodInfo[] Methods { get; }
        public AttributeInfo[] Attributes { get; }


        public ClassFile(string filePath)
        {
            ReadOnlySpan<byte> fileData = File.ReadAllBytes(filePath);

            var magic = fileData.ReadFourBytes();

            if (magic != 0xCAFEBABE)
            {
                throw new InvalidDataException();
            }

            MinorVersion = fileData.ReadTwoBytes();
            MajorVersion = fileData.ReadTwoBytes();

            PoolInfos = ParseConstantPool(ref fileData);

            AccessFlags = fileData.ReadTwoBytes();

            ThisClass = fileData.ReadTwoBytes();
            SuperClass = fileData.ReadTwoBytes();


            ushort interfacesCount = fileData.ReadTwoBytes();
            Interfaces = new string[interfacesCount];

            for (int i = 0; i < interfacesCount; i++)
            {
                Interfaces[i] = ((ClassInfo)(PoolInfos[fileData.ReadTwoBytes()])).Value;
            }


            ushort fieldsCount = fileData.ReadTwoBytes();
            Fields = new FieldInfo[fieldsCount];

            for (int i = 0; i < fieldsCount; i++)
            {
                Fields[i] = new FieldInfo(ref fileData, PoolInfos);
            }


            ushort methodsCount = fileData.ReadTwoBytes();
            Methods = new MethodInfo[methodsCount];

            for (int i = 0; i < methodsCount; i++)
            {
                Methods[i] = new MethodInfo(ref fileData, PoolInfos, this);
            }


            ushort attributesCount = fileData.ReadTwoBytes();
            Attributes = new AttributeInfo[attributesCount];

            for (int i = 0; i < attributesCount; i++)
            {
                Attributes[i] = new AttributeInfo(ref fileData, PoolInfos);
            }
        }

        private ConstantPoolInfo[] ParseConstantPool(ref ReadOnlySpan<byte> fileData)
        {
            ushort poolCount = fileData.ReadTwoBytes();

            var infos = new ConstantPoolInfo[poolCount];

            for (int i = 1; i < poolCount; i++)
            {
                var tag = (ConstantPoolTag)fileData.ReadOneByte();
                switch (tag)
                {
                    case ConstantPoolTag.Class:
                        infos[i] = new ClassInfo(ref fileData);
                        break;
                    case ConstantPoolTag.Fieldref:
                        infos[i] = new FieldrefInfo(ref fileData);
                        break;
                    case ConstantPoolTag.Methodref:
                        infos[i] = new MethodrefInfo(ref fileData);
                        break;
                    case ConstantPoolTag.InterfaceMethodref:
                        infos[i] = new InterfaceMethodrefInfo(ref fileData);
                        break;
                    case ConstantPoolTag.String:
                        infos[i] = new StringInfo(ref fileData);
                        break;
                    case ConstantPoolTag.Integer:
                        infos[i] = new IntegerInfo(ref fileData);
                        break;
                    case ConstantPoolTag.Float:
                        infos[i] = new FloatInfo(ref fileData);
                        break;
                    case ConstantPoolTag.Long:
                        infos[i] = new LongInfo(ref fileData);
                        i++;
                        break;
                    case ConstantPoolTag.Double:
                        infos[i] = new DoubleInfo(ref fileData);
                        i++;
                        break;
                    case ConstantPoolTag.NameAndType:
                        infos[i] = new NameAndTypeInfo(ref fileData);
                        break;
                    case ConstantPoolTag.Utf8:
                        infos[i] = new Utf8Info(ref fileData);
                        break;
                    case ConstantPoolTag.MethodHandle:
                        fileData.ReadOneByte();
                        fileData.ReadTwoBytes();
                        break;
                    case ConstantPoolTag.MethodType:
                        fileData.ReadTwoBytes();
                        break;
                    case ConstantPoolTag.InvokeDynamic:
                        fileData.ReadFourBytes();
                        break;
                    default:
                        throw new InvalidDataException();
                }
            }

            foreach (ConstantPoolInfo info in infos)
            {
                info?.Init(infos);
            }

            return infos;
        }
    }
}
