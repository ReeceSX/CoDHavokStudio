using HavokHelper.Lua;
using HavokHelper.Lua.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavokHelper.Lua.Instructions.Helpers
{
    class CallHelper
    {
        public static void DecompileCall(bool R1, BaseInstruction Cur, StringBuilder Buf, Stub OwnerStub, int Index)
        {
            String FuncName;
            StringBuilder ReturnVals = new StringBuilder();
            StringBuilder Parameters = new StringBuilder();

            FuncName = R1 ? "R1" : String.Format("var_{0}", Cur.A);

            if (Cur.C > 1)
            {
                int ReturnParameters;
                ReturnParameters = Cur.C - 1;
                if (ReturnParameters != 0)
                {
                    for (int I = 0; I < ReturnParameters; I++)
                        ReturnVals.Append("val_" + I + ", ");
                    ReturnVals.Remove(ReturnVals.Length - 2, 2);
                    ReturnVals.Append("\t= ");
                }
            }
            else if (Cur.C == 0)
            {
                ReturnVals.Append("--[[top = last_result+1]]");
            }

            for (int Reg = Cur.A + 1; Reg < Cur.A + Cur.B; Reg++)
                Parameters.Append(String.Format("val_{0}, ", Reg));

            if (Parameters.Length != 0)
                Parameters.Remove(Parameters.Length - 2, 2);

            Buf.Append(String.Format("{0}{1}({2})", ReturnVals.ToString(), FuncName, Parameters.ToString()));
        }
    }
}
