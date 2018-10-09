using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool.Info
{
    class ClassInfo : ClassStringInfo
    {
        bool isUpdated;

        public ClassInfo(ref ReadOnlySpan<byte> fileData) : base(ref fileData, ConstantPoolTag.Class)
        {
            isUpdated = false;
        }

        public override void Init(ReadOnlySpan<ConstantPoolInfo> infos)
        {
            if (!isUpdated)
            {
                base.Init(infos);
                isUpdated = true;
            }
        }
    }
}
