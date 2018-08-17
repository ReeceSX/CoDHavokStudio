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
    public class DivBkInstruction : BaseInstruction
    {
        public override RegisterUsage GetAUsage()
        {
            return RegisterUsage.Register;
        }

        public override RegisterUsage GetBUsage()
        {
            return RegisterUsage.Constant;
        }

        public override RegisterUsage GetCUsage()
        {
            return RegisterUsage.ConstantRegister;
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
            return "HKS_OPCODE_DIV_BK";
        }

        public override bool Implemented()
        {
            return true;
        }

        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index)
        {
            Buf.Append(String.Format("{0}\t= {1} / {2}", OwnerStub.DecompileInstruction_A(this), OwnerStub.DecompileInstruction_B(this), OwnerStub.DecompileInstruction_C(this)));
        }

        public override void AttainPseudoCode(StringBuilder Buf)
        {
            Buf.Append("TODO:");
        }
    }
}