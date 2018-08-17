using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavokHelper.Lua.Instructions.Helpers
{
    class TestHelper
    {
        public static int DecompileTest(bool R1, BaseInstruction Cur, StringBuilder Buf, Stub OwnerStub, int Index)
        {
            String CmpTarget = R1 ? "R1" : OwnerStub.DecompileInstruction_A(Cur);
            bool TestVal = Cur.C != 0;
            BaseInstruction BI = OwnerStub.Instructions[Index + 1];
            Buf.Append(String.Format("R1\t\t= {0}\n", CmpTarget));

            if (BI.GetFullName().Contains("_JMP"))
            {
                if (TestVal)
                    Buf.Append(String.Format("if ({0}) goto {1}", CmpTarget, Index + BI.B + 1 + 1));
                else
                    Buf.Append(String.Format("if (not ({0})) goto {1}", CmpTarget, Index + BI.B + 1 + 1));
                Index++;
                return Index;
            }

            if (TestVal)
                Buf.Append(String.Format("if (not({0})) goto {1}", CmpTarget, Index + 2));
            else
                Buf.Append(String.Format("if ({0}) goto {1}", CmpTarget, Index + 2));
            return Index;
        }
    }
}
