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
    public class LoadkInstruction : BaseInstruction
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
            return RegisterUsage.NotImplemented;
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
            return false;
        }

        public override String GetFullName()
        {
            return "HKS_OPCODE_LOADK";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }
        
        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index) 
        {
            Buf.Append(String.Format("{0}\t= {1}", OwnerStub.DecompileInstruction_A(this), OwnerStub.DecompileInstruction_B(this)));
        }
        
        public override void AttainPseudoCode(StringBuilder Buf) 
        {
            Buf.Append("A\t= R[A]\t= dest\n" +
                       "B\t= K(B)\t= constant\n" +
                       "\n" +
                       "dest = constant");
        }
    }
}