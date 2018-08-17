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
    public class SetfieldInstruction : BaseInstruction
    {
		public override RegisterUsage GetAUsage()
        { 
            return RegisterUsage.NotImplemented;
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
            return "HKS_OPCODE_SETFIELD";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }

        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index)
        {
            bool NoAppend = false;
            if (Index > 0)
            {
                BaseInstruction BI = OwnerStub.Instructions[Index - 1];
                if (BI.GetFullName().Equals(GetFullName()))
                    if (BI.A == this.A)
                        NoAppend = true;
            }
            if (!NoAppend)
                Buf.Append(String.Format("R1\t\t= var_{0}\n", A));
            Buf.Append(String.Format("var_{0}[{1}]\t= {2}", A, OwnerStub.DecompileInstruction_B(this), OwnerStub.DecompileInstruction_C(this)));
        }

        public override void AttainPseudoCode(StringBuilder Buf)
        {
            Buf.Append(
               "R1\t= R[A]\n" +
               "R1[K[B]]\t= RK[C]");
        }
    }
}