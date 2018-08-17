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
    public class LoadboolInstruction : BaseInstruction
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
            return "HKS_OPCODE_LOADBOOL";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }
        
        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index) 
        {
            Buf.Append(String.Format("{0}\t= {1}", OwnerStub.DecompileInstruction_A(this), B == 0 ? "False" : "True"));
            if (this.C != 0)
                Buf.Append(String.Format("\ngoto {0}", Index + 2));
        }
        
        public override void AttainPseudoCode(StringBuilder Buf) 
        {
            Buf.Append("A\t= R[A]\t\t= dest\n" +
          "B\t= bool(int(R[B]))\t= src\n" +
          "C\t= int(C)\t\t= skip\n" +
          "\n" +
          "dest\t= src\n" +
          "ip\t+= skip");
        }
    }
}