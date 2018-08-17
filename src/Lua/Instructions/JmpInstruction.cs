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
    public class JmpInstruction : BaseInstruction
    {
		public override RegisterUsage GetAUsage()
        { 
            return RegisterUsage.NotImplemented;
        }
		
        public override RegisterUsage GetBUsage()
        { 
            return RegisterUsage.Numeric;
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
            return "HKS_OPCODE_JMP";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }
        
        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index) 
        {
            Buf.Append(String.Format("goto {0}", Index + B + 1));
        }
        
        public override void AttainPseudoCode(StringBuilder Buf) 
        {
            Buf.Append( "B\t= signed int(B)\t= offset\n" +
                        "\n" +
                        "IP += offset");
        }
    }
}