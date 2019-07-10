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
    public class ClosureInstruction : BaseInstruction
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
            return "HKS_OPCODE_CLOSURE";
        }
        
        public override bool Implemented() 
        { 
            return true;
        }
        
        public override void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index) 
        {
            Buf.Append(String.Format("var_{0}\t= {1}", A, OwnerStub.Closures[B].AsFnString()));
        }
        
        public override void AttainPseudoCode(StringBuilder Buf) 
        {
            String ahh = @"
	a 	= R[a]				= dest  
		b 	= PROTO(R[b])		= closure
		
		dest = closure
		
		if (closure->m_method->num_upvals == 0)
			return
		
		for (i = 0; i < closure ->m_method->num_upvals; i ++)
			a->m_method->m_upvals[i] = 0
		
		for (var i = 0; i < closure ->m_method->num_upvals; i ++) {
			target = null
			
			if (nextInstruction a == 1) {
				target = luaState->pending;
				if (!target) goto notFound;
				while (luaPending->loc != &R[nextInstruction b])
				{
					luaPending = luaPending->m_next;
					if (!luaPending) goto notFound;
				}
					
			} else {
				notFound:
					target = new UpVal()
					target.loc.type = 0;
					target.loc.value = 0;
					target.loc = &R[nextInstruction b];
					target.m_next = luaState->pending;
					luaState->pending = target;
			}
		
			a->m_method->m_upvals[i] = target; // R[nextInstruction b] I think
			ip ++;
		}
";
            Buf.Append(ahh);
        }
    }
}