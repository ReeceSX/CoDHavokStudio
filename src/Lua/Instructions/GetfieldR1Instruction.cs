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
    public class GetfieldR1Instruction : BaseInstruction
    {
		public override RegisterUsage GetAUsage()
        { 
            return RegisterUsage.Register;
        }
		
        public override RegisterUsage GetBUsage()
        { 
            return RegisterUsage.NotImplemented;
        }
		
        public override RegisterUsage GetCUsage()
        { 
            return RegisterUsage.Constant;
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
            return "HKS_OPCODE_GETFIELD_R1";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }


        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index)
        {
            Buf.Append(
               String.Format("var_{0}\t= R1[{1}]\n", A, OwnerStub.DecompileInstruction_C(this)) +
               String.Format("R1\t\t= var_{0}", A)
              );
            Index += 2;
        }

        public override void AttainPseudoCode(StringBuilder Buf)
        {
            Buf.Append(
                "A\t= R[A]\t\t= dest   \n" +
                "C\t= int(C)\t\t= key \n" +
                "\n" +
               "dest\t= R1[key]\n" +
               "R1\t= dest");
        }
    }
}