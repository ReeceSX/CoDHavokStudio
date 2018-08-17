using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavokHelper.Lua
{
    public class Constant
    {
        private float I = 420;
        private bool Bool;
        private String Str;
        public ConstantType Type { get;  protected set; }

        public Constant(float I)
        {
            this.Type = ConstantType.NUMBER;
            this.I = I;
        }

        public Constant(String Str)
        {
            this.Type = ConstantType.STRING;
            this.Str = Str;
        }

        public Constant(bool Val)
        {
            this.Type = ConstantType.BOOL;
            this.Bool = Val;
        }

        public Constant()
        {
            this.Type = ConstantType.NIL;
        }

        public float FloatVal()
        {
            return this.I;
        }

        public int IntVal()
        {
            return (int)this.I;
        }

        public String GetString()
        {
            switch (this.Type)
            {
                case ConstantType.NUMBER:
                    return I.ToString();
                case ConstantType.NIL:
                    return "NIL";
                case ConstantType.STRING:
                    return Str; // "\"" + Str + "\"";
                case ConstantType.BOOL:
                    return Bool.ToString();
                default:
                    return "ERROR";
            }
        }
    }

    public class ConstantList
    {
        public Dictionary<int, Constant> Constants { get; protected set; } = new Dictionary<int, Constant>();

        public Constant ByIdx(int index)
        {
            return Constants[index];
        }
    }

    public enum ConstantType
    {
        NUMBER, NIL, STRING, BOOL
    }
}
