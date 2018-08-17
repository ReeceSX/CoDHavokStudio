using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavokHelper.Lua.Instructions.Helpers
{
    class IfExpHelper
    {
          
        public static int DecompileExpressionStatement(String ExprLogic, BaseInstruction Cur, StringBuilder Buf, Stub OwnerStub, int Index) 
        {
            bool AVal = Cur.A != 0;
            String IfStatement = "";

            BaseInstruction BI = OwnerStub.Instructions[Index + 1];
            if (BI.GetFullName().Contains("_JMP"))
            {
                if (AVal)
                    IfStatement = String.Format("if ({0} {2} {1})", OwnerStub.DecompileInstruction_B(Cur), OwnerStub.DecompileInstruction_C(Cur), ExprLogic);
                else
                    IfStatement = String.Format("if (not({0} {2} {1}))", OwnerStub.DecompileInstruction_B(Cur), OwnerStub.DecompileInstruction_C(Cur), ExprLogic);
                IfStatement += String.Format(" goto {0}", Index + BI.B + 1 + 1);
                Index++;
            }
            else
            {
                if (AVal)
                    IfStatement = String.Format("if (not({0} {2} {1}))", OwnerStub.DecompileInstruction_B(Cur), OwnerStub.DecompileInstruction_C(Cur), ExprLogic);
                else
                    IfStatement = String.Format("if ({0} {2} {1})", OwnerStub.DecompileInstruction_B(Cur), OwnerStub.DecompileInstruction_C(Cur), ExprLogic);
                IfStatement += String.Format(" goto {0}", Index + 2);
            }

            Buf.Append(IfStatement);
            return Index;
        }

    }
}
