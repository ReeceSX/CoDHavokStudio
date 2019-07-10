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
    public class SelfInstruction : BaseInstruction
    {
		public override RegisterUsage GetAUsage()
        { 
            return RegisterUsage.Register;
        }
		
        public override RegisterUsage GetBUsage()
        { 
            return RegisterUsage.Register;
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
            return "HKS_OPCODE_SELF";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }
        
        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index) 
        {
            Buf.Append( String.Format("var_{0}\t= {1}\n", A + 1, OwnerStub.DecompileInstruction_B(this)) +
                        String.Format("{0}\t= {1}[{2}]\n", OwnerStub.DecompileInstruction_A(this), OwnerStub.DecompileInstruction_B(this), OwnerStub.DecompileInstruction_C(this)) +
                        String.Format("R1\t\t= {0}", OwnerStub.DecompileInstruction_A(this)));
        }
        
        public override void AttainPseudoCode(StringBuilder Buf) 
        {
            Buf.Append(
		"R1\t\t= dest_r1    \n"                       +
		"A\t= R[A]\t= dest_a     \n"                  +
		"A_one\t= R[A + 1]= dest_a_one \n"          +
		"B\t= R[b]\t= table      \n"                  +
		"C\t= RK[c]\t= key        \n"                 +
		"                                     \n"     +
		"dest_a_one\t= table                 \n"     +
		"dest_a\t\t= table[key]                 \n"  +
        "dest_r1\t\t= dest_a");
        }
    }
}