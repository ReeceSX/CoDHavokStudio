using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavokHelper.Lua
{
    public class HavokScript
    {
        public static Stub MainMethod;
        public static Header Header = new Header();

        public static void Print(StringBuilder Buf)
        {
            MainMethod.Print(Buf);
        }

        public static Stub GetStub(String AsString)
        {
            return GetStub(MainMethod, AsString);
        }

        private static Stub GetStub(Stub Stub, String AsString)
        {
            if (Stub.AsString().Equals(AsString))
                return Stub;
            foreach (Stub S in Stub.Closures)
            {
                Stub maybe;
                if ((maybe = GetStub(Stub, AsString)) != null)
                    return maybe;
            }
            return null;
        }
    }
}
