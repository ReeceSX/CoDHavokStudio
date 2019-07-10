using HavokHelper.Lua;
using HavokHelper.Lua.Instructions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HavokHelper.src.Parser
{
    // port of          https://bitbucket.org/codt6/luadsm/src/master/asm/assembler.js
    // asm derived from https://bitbucket.org/codt6/luadsm/src/master/asm/disassembler.js
    // this really needs to be rewritten
    public class JSParserPort
    {

        protected class LineData
        {
            public String Raw;

            public float NumVal;
            public bool NumValPresent;

            public bool BoolVal;
            public bool BoolPresent;

            public String JSONVal;
            public bool JSONPresent;
        }

        protected static LineData[] ParseLine(String line)
        {
            //if (line.IndexOf(';') != -1)
            //    line = line.Substring(0, line.IndexOf(';'));

            String[] strs = line.Replace('\t', ' ')   // convert tabs into spaces
                                    .Replace(',', ' ')  // convert ,'s into spaces
                                    .Replace(":", "")   // get rid of optional :'s 
                                    .Replace("(", "")   // get rid of optional brackets
                                    .Replace(")", "")   // get rid of optional brackets
                                    .Split(' ');


            if (strs.Length == 0) return null;

            LineData[] ret = new LineData[strs.Length];

            bool Hack = false;
            int I = 0;
            StringBuilder sb  = new StringBuilder();
            foreach (var item in strs)
            {
                LineData data = new LineData();

                if (item.Length == 0)
                    continue;

                if (Hack)
                {
                    sb.Append(item);
                    continue;
                }

                ret[I++] = data;

                data.Raw = item;
                float ah;
                if (float.TryParse(item, out ah))
                {
                    data.NumVal = ah;
                    data.NumValPresent = true;
                }
                else if (item.Equals("true") || item.Equals("false"))
                {
                    data.BoolVal = item.Equals("true");
                    data.BoolPresent = true;
                }
                else if (item.StartsWith("\""))
                {
                    sb.Append(item.Substring(1));
                    Hack = true;
                }
            }

            if (Hack)
            {
                ret[I - 1].Raw = sb.ToString().Substring(0, sb.Length - 1);
            }


            if (0 == I) return null;
            return ret;
        }

        protected class LineBuffer
        {
            private int Idx = 0;
            protected String[] Lines;

            public LineBuffer(String[] Lines)
            {
                this.Lines = Lines;
            }

            public LineData[] Next(bool Peak = false)
            {
                LineData[] aggg;
                var offset = 0;
                while ((aggg = ParseLine(this.Lines[this.Idx + offset])) == null)
		            offset++;
                if (!Peak)
                    this.Idx += offset + 1;
                return aggg;
            }

            public String GetKey(bool Peak = false)
            {
                LineData Data = Next(Peak)[0];
                return Data.Raw;
            }

            public LineData GetValue()
            {
                return Next()[1];
            }

            public String GetValueStr()
            {
                return Next()[1].Raw;
            }
        }


        protected delegate void BlockCallback(LineBuffer Buffer, Object Data);

        protected static bool ReadBlock(LineBuffer buffer, String title, BlockCallback callback, Object data)
        {
            String temp;
            var start   = "START_"  + title;
            var end     = "END_"    + title;

            temp = buffer.GetKey();
            if (!temp.Equals(start))
                {
                MessageBox.Show(String.Format("expected: {0}, got {1}", start, temp));
                return false;
            }

            callback(buffer, data);

            temp = buffer.GetKey();
            if (!temp.Equals(end))
            {
                MessageBox.Show(String.Format("expected: {0}, got {1}", end, temp));
                return false;
            }
            return true;
        }

        protected static void HandleNumberSizes(LineBuffer Buffer, Object Data)
        {
            String str = Buffer.GetKey(true);
            if (str.Equals("NUMBER"))
            {
                //TODO assert
                HavokScript.Header.NumSize = (int)Buffer.GetValue().NumVal;
                HandleNumberSizes(Buffer, Data);
                return;
            }
            if (str.Equals("SIZE_T"))
            {
                //TODO assert
                HavokScript.Header.SizeSize = (int)Buffer.GetValue().NumVal;
                HandleNumberSizes(Buffer, Data);
                return;
            }
            if (str.Equals("INSTRUCTION"))
            {
                //TODO assert
                HavokScript.Header.AltSize = (int)Buffer.GetValue().NumVal;
                HandleNumberSizes(Buffer, Data);
                return;
            }
            if (str.Equals("INTEGER"))
            {
                //TODO assert
                HavokScript.Header.IntSize = (int)Buffer.GetValue().NumVal;
                HandleNumberSizes(Buffer, Data);
                return;
            }
        }

        protected static void HandleHeader(LineBuffer Buffer, Object Data)
        {
            if (Buffer.GetKey(true).Equals("START_NUMBER_SIZES"))
            {
                ReadBlock(Buffer, "NUMBER_SIZES", HandleNumberSizes, null);
                HandleHeader(Buffer, Data);
                return;
            }


            if (Buffer.GetKey(true).Equals("VERSION"))
            {
                //TODO assert
                HavokScript.Header.Version = (int)Buffer.GetValue().NumVal;
                HandleHeader(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("LENDIAN"))
            {
                //TODO assert
                HavokScript.Header.IsLE = Buffer.GetValue().BoolVal;
                HandleHeader(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("UNK"))
            {
                HandleHeader(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("FLAGS"))
            {
                //TODO assert
                HavokScript.Header.Flags = (int)Buffer.GetValue().NumVal;
                HandleHeader(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("TYPES"))
            {
                //TODO assert
                HavokScript.Header.Types = (int)Buffer.GetValue().NumVal;
                HandleHeader(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("SHARE"))
            {
                //TODO assert
                HavokScript.Header.Share = Buffer.GetValue().BoolVal;
                HandleHeader(Buffer, Data);
                return;
            }
        }

        protected static void HandleDebug(LineBuffer Buffer, Object Data)
        {
            Buffer.Next();
            Buffer.Next();
        }

        protected static int ConstantIndex = 0;
        protected static void HandleConstants(LineBuffer Buffer, Object Data)
        {
            Stub Current = (Stub)Data;
            
            if (Buffer.GetKey(true).Equals("END_CONSTANTS")) return;


            if (Buffer.GetKey(true).Equals("TSTRING"))
            {
                LineData[] data = Buffer.Next(false);
                Current.Constants.Constants.Add(ConstantIndex++, new Constant(data.Length == 1 ? "" : data[1].Raw));
                HandleConstants(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("TNUMBER"))
            {
                Current.Constants.Constants.Add(ConstantIndex++, new Constant(Buffer.GetValue().NumVal));
                HandleConstants(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("TBOOLEAN"))
            {
                Current.Constants.Constants.Add(ConstantIndex++, new Constant(Buffer.GetValue().BoolVal));
                HandleConstants(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("TNIL"))
            {
                Buffer.GetValue();
                Current.Constants.Constants.Add(ConstantIndex++, new Constant());
                HandleConstants(Buffer, Data);
                return;
            }
        }

        protected static void HandleCodes(LineBuffer Buffer, Object Data)
        {
            Stub Current = (Stub)Data;
            if (Buffer.GetKey(true).Equals("END_CODE")) return;

            LineData[] data = Buffer.Next();
            Type IType;
            BaseInstruction Ahh;


            if (BaseInstruction.FromName(data[0].Raw) == null)
                data = data.Skip(1).ToArray();

            if ((Ahh = BaseInstruction.FromName(data[0].Raw)) == null)
            {
                MessageBox.Show("Instruction not found error");
                return;
            }

            data = data.Skip(1).ToArray();
            IType = Ahh.GetType();
            Ahh = (BaseInstruction)Activator.CreateInstance(IType);

            Ahh.A = (int)data[0].NumVal;
            Ahh.B = (int)data[1].NumVal;

            if (Ahh.HasC())
                Ahh.C = (int)data[2].NumVal;

            Current.Instructions.Add(Ahh);

            HandleCodes(Buffer, Data);
        }

        protected static void HandleClosure(LineBuffer Buffer, Object Data)
        {
            Stub Current = (Stub)Data;
            Current.Parent.Closures.Add(Current);
            ReadBlock(Buffer, "METHOD", HandleMethod, Data);
        }

        protected static void HandleMethod(LineBuffer Buffer, Object Data)
        {
            Stub Current = (Stub)Data;

            if (Buffer.GetKey(true).Equals("START_DBG"))
            {
                if (!ReadBlock(Buffer, "DBG", HandleDebug, Data))
                    return;
                HandleMethod(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("START_CONSTANTS"))
            {
                ConstantIndex = 0;
                if (!ReadBlock(Buffer, "CONSTANTS", HandleConstants, Data))
                    return;
                HandleMethod(Buffer, Data);
                return;
            }


            if (Buffer.GetKey(true).Equals("START_CODE"))
            {
                if (!ReadBlock(Buffer, "CODE", HandleCodes, Data))
                    return;
                HandleMethod(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("START_CLOSURE"))
            {
                if (!ReadBlock(Buffer, "CLOSURE", HandleClosure, new Stub(Current, (int)Buffer.Next(true)[1].NumVal)))
                    return;

                HandleMethod(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("FLAGS"))
            {
                //TODO assert
                Current.Flags = (int)Buffer.GetValue().NumVal;
                HandleMethod(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("PARAMS"))
            {
                //TODO assert
                Current.Parameters = (int)Buffer.GetValue().NumVal;
                HandleMethod(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("UPVALS"))
            {
                //TODO assert
                Current.UpVals = (int)Buffer.GetValue().NumVal;
                HandleMethod(Buffer, Data);
                return;
            }

            if (Buffer.GetKey(true).Equals("REGCNT"))
            {
                //TODO assert
                Current.Registers = (int)Buffer.GetValue().NumVal;
                HandleMethod(Buffer, Data);
                return;
            }

        }

        protected static void HandleScript(LineBuffer Buffer, Object Data)
        {
            if (Buffer.GetKey(true).Equals("START_HEADER"))
            {
                ReadBlock(Buffer, "HEADER", HandleHeader, null);
                HandleScript(Buffer, Data);
            }

            if (Buffer.GetKey(true).Equals("START_METHOD"))
            {
                ReadBlock(Buffer, "METHOD", HandleMethod, HavokScript.MainMethod = new Stub());
                HandleScript(Buffer, Data);
            }
        }

        public static void ParseStatic(String Buffer)
        {
            ParseStatic(Buffer.Split('\n'));
        }

        public static  void ParseStatic(String[] Lines)
        {
            ReadBlock(new LineBuffer(Lines), "SCRIPT", HandleScript, null);
        }
    }
}
