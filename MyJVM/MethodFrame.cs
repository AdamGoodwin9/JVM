using MyJVM.ConstantPool.Info;
using System;
using System.Collections.Generic;
using System.Text;

using static MyJVM.Utilities;

namespace MyJVM
{
    class MethodFrame
    {
        public ushort MaxStack { get; }
        public ushort MaxLocals { get; }

        public byte[] ByteCode { get; }

        public MethodReturnType ReturnType { get; }

        private readonly MethodInfo methodInfo;
        private readonly ClassFile classFile;


        public MethodFrame(AttributeInfo codeAttribute, MethodInfo methodInfo, ClassFile classFile)
        {
            ReadOnlySpan<byte> data = codeAttribute.Data;

            MaxStack = data.ReadTwoBytes();
            MaxLocals = data.ReadTwoBytes();

            uint codeLength = data.ReadFourBytes();

            ByteCode = new byte[codeLength];

            data.Slice(0, (int)codeLength).CopyTo(ByteCode);

            this.methodInfo = methodInfo;
            this.classFile = classFile;
        }

        public void ParseDescriptor(string descriptor)
        {
            int parametersSize = 0;

            string returnType = descriptor.Substring(descriptor.IndexOf(')') + 1);

            int returnSize;

            char c = returnType[0];
            
            if(c == '[')
            {
                returnSize = 1;
            }
            else if (c == 'D' || c == 'J')
            {
                returnSize = 2;
            }
            else if (c == 'V')
            {
                returnSize = 0;
            }
            else
            {
                returnSize = 1;
            }


            string temp = descriptor.Substring(1, descriptor.IndexOf(')'));

            while (temp.Length >= 1)
            {
                c = temp[0];
                if(c == '[')
                {
                    parametersSize++;
                    temp = temp.Substring(1);
                }
                else if (c == 'L')
                {
                    parametersSize++;
                    temp = temp.Substring(temp.IndexOf(';') + 1);
                }
                else if (c == 'D' || c == 'J')
                {
                    parametersSize += 2;
                    temp = temp.Substring(1);
                }
                else if (c != 'V')
                {
                    parametersSize++;
                    temp = temp.Substring(1);
                }
                else
                {
                    temp = temp.Substring(1);
                }
            }
        }

        public (int high, int low) Run()
        {
            int ip = 0;
            int sp = 0;

            int[] stack = new int[MaxStack];
            int[] locals = new int[MaxLocals];

            void Push(int value) => stack[sp++] = value;
            void PushLongFromInts(int high, int low) { Push(high); Push(low); }
            void PushLongFromLong(long value)
            {
                (var high, var low) = value;
                Push(high);
                Push(low);
            }

            int Pop() => stack[--sp];
            (int high, int low) PopLong() => (Pop(), Pop());

            while (true)
            {
                byte opCode = ByteCode[ip];
                switch (opCode)
                {
                    case 0x00:
                        break;
                    case 0x02:
                    case 0x03:
                    case 0x04:
                    case 0x05:
                    case 0x06:
                    case 0x07:
                    case 0x08:
                        Push(opCode - 0x03);
                        break;
                    case 0x1A:
                    case 0x1B:
                    case 0x1C:
                    case 0x1D:
                        Push(locals[opCode - 0x1A]);
                        break;
                    case 0x3B:
                    case 0x3C:
                    case 0x3D:
                    case 0x3E:
                        locals[opCode - 0x3B] = Pop();
                        break;
                    case 0x60:

                        break;
                    case 0xAC:
                        return (0, Pop());
                    case 0xB8:


                        int methodrefIndex = (ByteCode[++ip] << 8) + ByteCode[++ip];

                        MethodrefInfo methodref = classFile.PoolInfos[methodrefIndex] as MethodrefInfo;
                        MethodInfo method = null;

                        for (int i = 0; i < classFile.Methods.Length; i++)
                        {
                            if (classFile.Methods[i].Name == methodref.RefName)
                            {
                                method = classFile.Methods[i];
                                break;
                            }
                        }

                        //method

                        //method?.Frame.Run();

                        break;
                    default:
                        throw new NotImplementedException("Unimplemented Op Code: 0x" + ByteCode[ip].ToString("X2"));
                }
                ip++;
            }
        }
    }
}
