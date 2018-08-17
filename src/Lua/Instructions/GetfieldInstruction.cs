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
    public class GetfieldInstruction : BaseInstruction
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
            return "HKS_OPCODE_GETFIELD";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }

        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index)
        {
            Buf.Append(
               String.Format("var_{0}\t= var_{1}[{2}]\n", A, B, OwnerStub.DecompileInstruction_C(this)) +
               String.Format("R1\t\t= var_{0}", A)
              );

            if (OwnerStub.Instructions[Index + 1].GetFullName().Contains("_DATA"))
                Index += 2;
        }

        public override void AttainPseudoCode(StringBuilder Buf)
        {
            Buf.Append(
                "A\t= R[A]\t\t= dest   \n" +
                "B\t= Table(B)\t\t= source \n" +
                "C\t= int(C)\t\t= key \n" +
                "\n" +
               "dest\t= source[key]\n" +
               "R1\t= dest");
        }
    }
}