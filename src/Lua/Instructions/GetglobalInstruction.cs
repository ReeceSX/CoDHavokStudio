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
    public class GetglobalInstruction : BaseInstruction
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
            return "HKS_OPCODE_GETGLOBAL";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }
        
        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index)
        {
            Buf.Append(String.Format("var_{0}\t= _G[{1}]\n", A, OwnerStub.DecompileInstruction_B(this)));
            Buf.Append(String.Format("R1\t\t= var_{0}", A));
        }
        
        public override void AttainPseudoCode(StringBuilder Buf) 
        {
            Buf.Append(
          "A\t= R[A]\t\t= object   \n" + 
		  "Bx\t= constant(Bx)\t= constant \n" + 
		  "                                \n" +
          "R1 = object = Global[constant]");
        }
    }
}