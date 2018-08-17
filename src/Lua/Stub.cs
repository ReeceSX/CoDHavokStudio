using HavokHelper.Lua.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HavokHelper.Lua
{
    public class Stub
    {
        //public int Index;
        public int Parameters { get;  set; }
        public int Registers { get;  set; }
        public int Locals { get { return Registers + 1; } set { } }
        public int UpVals { get;  set; }
        public int Flags { get;  set; }
        public List<Stub> Closures { get; protected set; } = new List<Stub>();
        public ConstantList Constants { get; protected set; } = new ConstantList();
        public List<BaseInstruction> Instructions { get; protected set; } = new List<BaseInstruction>();
        public Stub Parent;
        public int ClosureID;
        public int Index { protected set; get; }

        public Stub(int Parameters, int Registers, int UpVals, int Flags)
        {
            this.Parameters = Parameters;
            this.Registers = Registers;
            this.UpVals = UpVals;
            this.Flags = Flags;
        }

        public Stub(Stub Parent, int ClosureID)
        {
            this.Parent = Parent;
            this.ClosureID = ClosureID;
        }

        public Stub()
        {
            //this.Parameters = Parameters;
            //this.Registers = Registers;
            //this.UpVals = UpVals;
            //this.Flags = Flags;
        }

        public void Print(StringBuilder Buf, int Idt = 0)
        {
            String Ident;
            int VarIndexStart = 0;

            Ident = "";
            for (int I = 0; I < Idt; I++)
                Ident += "    ";

            if (Parent != null)
            {
                String args = "";
                for (int I = 0; I < Parameters; I++)
                    args += String.Format("argument_{0}, ", I);
                if (args.Length != 0)
                    args = args.Substring(0, args.Length - 2);

                Buf.Append(String.Format("{0}function {1}({2})\n", Ident, AsFnString(), args));

                for (int I = 0; I < Parameters; I++)
                {
                    Buf.Append(String.Format("00:{0}    local var_{1} = argument_{1}\n", Ident, I));
                }

                VarIndexStart = Parameters;
            }

            for (int I = VarIndexStart; I < this.Registers; I++)
                Buf.Append(String.Format("00:{0}    local var_{1} = nil\n", Ident, I));

            Closures.ForEach((closure) =>
            {
                for (int I = 0; I < closure.UpVals; I++)
                    Buf.Append(String.Format("00:{0}    upval_{1}_for_{2} = nil\n", Ident, I, closure.ClosureID));
            });

            Buf.Append(String.Format("00:{0}    local R1 = nil\n", Ident));

            for (int I = 0; I < Instructions.Count; I ++)
            {
                int RealIndex = I;
                StringBuilder SB;
                BaseInstruction Instruction;

                Instruction = Instructions[I];
                SB = new StringBuilder();

                if (Instruction.Implemented())
                    Instruction.Decompile(SB, this, ref I);
                else
                    SB.Append("instruction missing: " + Instruction.GetFullName());

                SB.ToString().Replace("\r", "").Split('\n').ToList().ForEach((line) =>
                {
                     Buf.Append(String.Format("{1}:{0}    {2}\n", Ident, RealIndex.ToString("00"), line));
                });
            }


            Closures.ForEach((closure) =>
            {
                closure.Print(Buf, Idt + 1);
            });

            if (Parent != null)
                Buf.Append(String.Format("{0}end\n", Ident));
        }

        public String AsFnString()
        {
            if (Parent != null)
                return String.Format("closure{0}Of{1}", this.ClosureID, this.Parent.ClosureID);
            return null;
        }

        public String AsString()
        {
            if (Parent != null)
                return String.Format("Closure: {0}/{1}", this.ClosureID, this.Parent.ClosureID);
            return "Main Method";
        }


        public delegate void CallbackStr(String Str);
        public delegate String Stringify(Stub Stub);

        public String StringifyInstruction_A(BaseInstruction BI)
        {
            return StringifyInstruction(BI.GetAUsage(), BI.AStringify, BI.A);
        }

        public String StringifyInstruction_B(BaseInstruction BI)
        {
            return StringifyInstruction(BI.GetBUsage(), BI.BStringify, BI.B);
        }

        public String StringifyInstruction_C(BaseInstruction BI)
        {
            return StringifyInstruction(BI.GetCUsage(), BI.CStringify, BI.C);
        }
        public String DecompileInstruction_A(BaseInstruction BI)
        {
            return DecompileInstruction(BI.GetAUsage(), BI.AStringify, BI.A);
        }

        public String DecompileInstruction_B(BaseInstruction BI)
        {
            return DecompileInstruction(BI.GetBUsage(), BI.BStringify, BI.B);
        }

        public String DecompileInstruction_C(BaseInstruction BI)
        {
            return DecompileInstruction(BI.GetCUsage(), BI.CStringify, BI.C);
        }

        

        public String StringifyInstruction(RegisterUsage Usage, Stringify AsString, int Val)
        {
            switch (Usage)
            {
                case RegisterUsage.Stringify:
                    return AsString(this);
                case RegisterUsage.Register:
                    RegisterCase:
                    return "R[" + Val + "]";
                case RegisterUsage.Constant:
                    ConstantCase:
                    return this.Constants.ByIdx(Val).GetString();
                case RegisterUsage.ConstantRegister:
                    if (Val < 0x100)
                    {
                        goto RegisterCase;
                    }
                    else
                    {
                        Val -= 0x100;
                        goto ConstantCase;
                    }
                case RegisterUsage.Numeric:
                    return Val.ToString();
                default:
                    break;
            }
            return null;
        }


        public String DecompileInstruction(RegisterUsage Usage, Stringify AsString, int Val)
        {
            switch (Usage)
            {
                case RegisterUsage.Stringify:
                    return AsString(this);
                case RegisterUsage.Register:
                    RegisterCase:
                    return "var_" + Val;
                case RegisterUsage.Constant:
                    ConstantCase:
                    Constant Const = this.Constants.ByIdx(Val);
                    if (Const.Type == ConstantType.STRING)
                        return "\"" + Const.GetString() + "\"";
                    return Const.GetString();
                case RegisterUsage.ConstantRegister:
                    if (Val < 0x100)
                    {
                        goto RegisterCase;
                    }
                    else
                    {
                        Val -= 0x100;
                        goto ConstantCase;
                    }
                case RegisterUsage.Numeric:
                    return Val.ToString();
                default:
                    break;
            }
            return null;
        }
    }
}
