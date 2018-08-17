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
    public enum RegisterUsage
    {
        Stringify,
        Register, 
        Constant,
        ConstantRegister,
        Numeric,
        NotImplemented
    }

    public abstract class BaseInstruction
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public abstract bool HasC();

        public abstract String GetFullName();

        public abstract bool Implemented();
        public abstract RegisterUsage GetAUsage();
        public abstract RegisterUsage GetBUsage();
        public abstract RegisterUsage GetCUsage();
        public abstract String AStringify(Stub Stub);
        public abstract String BStringify(Stub Stub);
        public abstract String CStringify(Stub Stub);
        public abstract void Decompile(StringBuilder Buf, Stub OwnerStub, ref int Index);
        public abstract void AttainPseudoCode(StringBuilder Buf);

        public static BaseInstruction FromName(string name)
        {
            return All.ToList().Where((a) => { return a.GetFullName().Equals(name); }).ElementAtOrDefault(0);
        }

        public static BaseInstruction[] All = {
new TestInstruction(),
new TestR1Instruction(),
new EqInstruction(),
new EqBkInstruction(),
new MoveInstruction(),
new SelfInstruction(),
new ReturnInstruction(),
new GettableInstruction(),
new GettableSInstruction(),
new GettableNInstruction(),
new TforloopInstruction(),
new ForloopInstruction(),
new ForprepInstruction(),
new SettableSInstruction(),
new SettableSBkInstruction(),
new SettableNInstruction(),
new SettableNBkInstruction(),
new SettableInstruction(),
new SettableBkInstruction(),
new TailcallIR1Instruction(),
new TailcallIInstruction(),
new TailcallCInstruction(),
new TailcallMInstruction(),
new TailcallInstruction(),
new LoadkInstruction(),
new LoadnilInstruction(),
new LoadboolInstruction(),
new JmpInstruction(),
new CallInstruction(),
new CallMInstruction(),
new CallCInstruction(),
new CallIR1Instruction(),
new CallIInstruction(),
new IntrinsicIndexInstruction(),
new IntrinsicNewindexInstruction(),
new IntrinsicSelfInstruction(),
new IntrinsicIndexLiteralInstruction(),
new IntrinsicNewindexLiteralInstruction(),
new IntrinsicSelfLiteralInstruction(),
new GetupvalInstruction(),
new SetupvalInstruction(),
new SetupvalR1Instruction(),
new AddInstruction(),
new AddBkInstruction(),
new SubInstruction(),
new SubBkInstruction(),
new MulInstruction(),
new MulBkInstruction(),
new DivInstruction(),
new DivBkInstruction(),
new ModInstruction(),
new ModBkInstruction(),
new PowInstruction(),
new PowBkInstruction(),
new NewtableInstruction(),
new UnmInstruction(),
new NotInstruction(),
new NotR1Instruction(),
new LeInstruction(),
new LtInstruction(),
new LtBkInstruction(),
new LeInstruction(),
new LeBkInstruction(),
new ConcatInstruction(),
new TestsetInstruction(),
new SetlistInstruction(),
new CloseInstruction(),
new ClosureInstruction(),
new VarargInstruction(),
new NewstructInstruction(),
new DataInstruction(),
new SetslotnInstruction(),
new SetslotiInstruction(),
new SetslotInstruction(),
new SetslotmtInstruction(),
new SetslotsInstruction(),
new ChecktypeInstruction(),
new ChecktypeDInstruction(),
new ChecktypesInstruction(),
new GetslotInstruction(),
new GetslotDInstruction(),
new GetslotmtInstruction(),
new SelfslotInstruction(),
new SelfslotmtInstruction(),
new SetfieldInstruction(),
new SetfieldR1Instruction(),
new GetfieldInstruction(),
new GetfieldR1Instruction(),
new GetfieldMmInstruction(),
new SetglobalInstruction(),
new GetglobalInstruction(),
new GetglobalMemInstruction()
};
    }
}