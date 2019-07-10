using HavokHelper.Lua;
using HavokHelper.Lua.Instructions;
using HavokHelper.src.Parser;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HavokHelper
{
    public partial class NodeHelper : Form
    {
        private Stub SelectedStub;

        public NodeHelper()
        {
            InitializeComponent();
        }

        private void NodeHelper_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
            textBox2.Text = openFileDialog1.FileName;

            if (textBox1.Text.EndsWith(".lua"))
                textBox2.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 3) + "asm";
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            textBox2.Text = openFileDialog2.FileName;
        }

        private void destCompiled_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 4)
                return;
            textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 3) +  (destCompiled.Checked ? "lua" : "asm");
        }

        private void appendText(string text)
        {
            if (richTextBox1.InvokeRequired)
                richTextBox1.Invoke(new System.Action(() => appendText(text)));
            else
                richTextBox1.AppendText(text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"fuck.js", string.Empty);
            String buffer = "";

            buffer += "var hks = require(\"" + textBox3.Text.Replace(@"\", @"\\") + "index.js\")\n";
            buffer += "var test = new hks.Context();\n";

            if (srcCompiled.Checked)
            {
                buffer += "test.fromFile(\"" + textBox1.Text.Replace(@"\", @"\\") + "\")\n";
            }
            else
            {
                buffer += "test.assembleFile(\"" + textBox1.Text.Replace(@"\", @"\\") + "\")\n";
            }


            if (destCompiled.Checked)
            {
                buffer += "test.save(\"" + textBox2.Text.Replace(@"\", @"\\") + "\")\n";
            }
            else
            {
                buffer += "test.disassembleFile(\"" + textBox2.Text.Replace(@"\", @"\\") + "\")\n";
            }

            System.IO.File.WriteAllText(@"fuck.js", buffer);
            using (Process nodejs = new Process())
            {
                nodejs.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                nodejs.StartInfo.Arguments = "fuck.js";
                nodejs.StartInfo.CreateNoWindow = true;
                nodejs.StartInfo.UseShellExecute = false;
                nodejs.StartInfo.RedirectStandardOutput = true;
                nodejs.StartInfo.RedirectStandardError = true;

                nodejs.OutputDataReceived += (object sender2, DataReceivedEventArgs e2) =>
                {
                    appendText(e2.Data);
                    appendText(Environment.NewLine);
                };

                nodejs.ErrorDataReceived += (object sender2, DataReceivedEventArgs e2) =>
                {
                    appendText(e2.Data);
                    appendText(Environment.NewLine);
                };

                nodejs.Start();
                nodejs.BeginOutputReadLine();
                nodejs.BeginErrorReadLine();
                //  nodejs.WaitForExit();
            }
        }
    }
}
