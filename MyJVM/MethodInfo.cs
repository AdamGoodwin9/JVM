using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyJVM.ConstantPool;

namespace MyJVM
{
    class MethodInfo : FieldMethodInfo
    {
        public MethodFrame Frame { get; }

        

        public MethodInfo(ref ReadOnlySpan<byte> fileData, ConstantPoolInfo[] poolInfos, ClassFile classFile) : base(ref fileData, poolInfos)
        {
            AttributeInfo codeAttribute = null;

            for (int i = 0; i < AttributeInfos.Length; i++)
            {
                AttributeInfos[i] = new AttributeInfo(ref fileData, poolInfos);

                if (AttributeInfos[i].Name == "Code")
                {
                    if(codeAttribute != null)
                    {
                        throw new InvalidDataException();
                    }

                    codeAttribute = AttributeInfos[i];
                }
            }

            if (codeAttribute != null)
            {
                Frame = new MethodFrame(codeAttribute, this, classFile);
            }
        }
    }
}
