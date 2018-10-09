using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM.ConstantPool
{
    public abstract class ConstantPoolInfo
    {
        private ConstantPoolTag tag;

        public ConstantPoolInfo(ConstantPoolTag tag)
        {
            this.tag = tag;
        }

        public virtual void Init(ReadOnlySpan<ConstantPoolInfo> infos) { }
    }
}
