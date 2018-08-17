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
    public class MoveInstruction : BaseInstruction
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
            return true;
        }

        public override String GetFullName()
        {
            return "HKS_OPCODE_MOVE";
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
            Buf.Append("" +
                    "R1\t\t= dest_r1\n" +
                    "A\t= R[A]\t= dest_a\n" +
                    "B\t= R[B]\t= src\n" +
                    "\n" +
                    "dest_r1\t= src\n" +
                    "dest_a\t= src");
        }
    }
}