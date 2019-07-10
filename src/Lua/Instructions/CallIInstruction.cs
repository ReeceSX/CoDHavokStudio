using HavokHelper.Lua.Instructions.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HavokHelper.Lua.Instructions
{
    public class CallIInstruction : BaseInstruction
    {
        public override RegisterUsage GetAUsage()
        {
            return RegisterUsage.Register;
        }

        public override RegisterUsage GetBUsage()
        {
            return RegisterUsage.Numeric;
        }

        public override RegisterUsage GetCUsage()
        {
            return RegisterUsage.Numeric;
        }

        public override String AStringify(Stub Stub)
        {
            return null;
        }

        public override String BStringify(Stub Stub)
        {
            return null;
        }

        public override String CStringify(Stub Stub)
        {
            return null;
        }

        public override bool HasC()
        {
            return true;
        }

        public override String GetFullName()
        {
            return "HKS_OPCODE_CALL_I";
        }

        public override bool Implemented()
        {
            return true;
        }

        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index)
        {
            CallHelper.DecompileCall(false, this, Buf, OwnerStub, Index);
        }

        public override void AttainPseudoCode(StringBuilder Buf)
        {
            Buf.Append("TODO:");
        }
    }
}