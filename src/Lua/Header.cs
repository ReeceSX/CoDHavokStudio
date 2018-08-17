using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavokHelper.Lua
{
    public class Header
    {
        public int Flags { get; set; }
        public int Version { get; set; }
        public int Types { get; set; }
        public bool Share { get; set; }
        public bool IsLE { get; set; }
        public String Endianness { get { return IsLE ? "little" : "big"; } set { } }

        public int NumSize;
        public int IntSize;
        public int AltSize;
        public int SizeSize;
    }
}
