using HavokHelper.Lua;
using HavokHelper.Lua.Instructions;
using HavokHelper.src.Parser;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HavokHelper
{
    public partial class Main : Form
    {
        private Stub SelectedStub;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int ImplCount = 0;
            BaseInstruction.All.ToList().ForEach((ahh) =>
            {
                if (ahh.Implemented()) ImplCount++;
                SupportedOpsList.Items.Add(ahh.GetFullName(), ahh.Implemented());
            });
            ImplementOpsGroup.Text += " " + ImplCount + "/" + BaseInstruction.All.Length;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            JSParserPort.ParseStatic(File.ReadAllText(openFileDialog1.FileName));
            RefreshUI();
        }

        private void FromFileItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void SupportedOpsList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SupportedOpsList.SelectedItem != null)
                SupportedOpsList.SelectedItem = null;
        }

        private void SupportedOpsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SupportedOpsList.SelectedItem != null)
                SupportedOpsList.SelectedItem = null;
        }

        private void AddMethodToView(Stub Stub)
        {
            MethodsView.Items.Add(new ListViewItem(new String[] { Stub.AsString(), Stub.Parameters.ToString(), Stub.Registers.ToString(), Stub.UpVals.ToString(), "0x" + Stub.Flags.ToString("X") }));
            Stub.Closures.ForEach(AddMethodToView);
        }

        private void RefreshUI()
        {
            VersionLbl.Text = HavokScript.Header.Version.ToString();
            TypesLbl.Text   = HavokScript.Header.Types.ToString();
            ShareLbl.Text   = HavokScript.Header.Share.ToString();
            EndianLbl.Text  = HavokScript.Header.Endianness + "-endian";
            FlagsLbl.Text   = "0x" + HavokScript.Header.Flags.ToString("X");

            NumLbl.Text  = HavokScript.Header.NumSize.ToString();
            IntLbl.Text  = HavokScript.Header.IntSize.ToString();
            SizeLbl.Text = HavokScript.Header.SizeSize.ToString();
            InstructionLbl.Text = HavokScript.Header.AltSize.ToString();

            MethodsView.Items.Clear();
            AddMethodToView(HavokScript.MainMethod);
            MethodsView.Columns[0].Width = MethodsView.Width - (MethodsView.Columns[1].Width + MethodsView.Columns[2].Width + MethodsView.Columns[3].Width + MethodsView.Columns[4].Width + SystemInformation.VerticalScrollBarWidth + 4);
        }

        private void RenderMethod()
        {
            ConstantsView.Items.Clear();
            SelectedStub.Constants.Constants.ToList().ForEach((ah) =>
            {
                ConstantsView.Items.Add(new ListViewItem(new String[] { ah.Key.ToString(), ah.Value.Type.ToString(), ah.Value.GetString()}));
            });

            StringBuilder PCode = new StringBuilder();
            SelectedStub.Print(PCode);
            PseudocodeBox.Text = PCode.ToString();

            InstructionView.Items.Clear();
            int Idx = 0;
            SelectedStub.Instructions.ForEach((Instruction) =>
            {
                InstructionView.Items.Add(new ListViewItem(new String[] { (Idx++).ToString(), Instruction.GetFullName(), Instruction.A.ToString(), Instruction.B.ToString(), Instruction.C.ToString() }));
            });
            InstructionView.Columns[1].Width = InstructionView.Width - (InstructionView.Columns[0].Width + InstructionView.Columns[4].Width + InstructionView.Columns[2].Width + InstructionView.Columns[3].Width + SystemInformation.VerticalScrollBarWidth + 4);
        }

        private void RenderMethodSearch(Stub Stub)
        {
            if (!Stub.AsString().Equals(MethodsView.SelectedItems[0].SubItems[0].Text))
            {
                Stub.Closures.ForEach(RenderMethodSearch);
                return;
            }
            SelectedStub = Stub;
            RenderMethod();
        }

        private void MethodsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MethodsView.SelectedIndices.Count <= 0)
                return;
            RenderMethodSearch(HavokScript.MainMethod);
        }

        private void InstructionView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstructionView.SelectedIndices.Count <= 0)
                return;
            if (InstructionView.SelectedIndices.Count <= 0)
                return;
            int idx = InstructionView.SelectedIndices[0];
            BaseInstruction Instruction = SelectedStub.Instructions[idx];
            if (!Instruction.Implemented())
            {
                AbsAVal.Text = "Not Impl";
                AbsBVal.Text = "Not Impl";
                AbsCVal.Text = "Not Impl";
                CurOpPseudo.Text = "Not Yet Implemented";
                return;
            }
            StringBuilder PCode = new StringBuilder();
            Instruction.AttainPseudoCode(PCode);
            CurOpPseudo.Text = PCode.ToString();
            SetABCField(Instruction.GetAUsage(), AbsAVal, Instruction.AStringify, Instruction.A);
            SetABCField(Instruction.GetBUsage(), AbsBVal, Instruction.BStringify, Instruction.B);
            if (Instruction.HasC())
                SetABCField(Instruction.GetCUsage(), AbsCVal, Instruction.CStringify, Instruction.C);
            else
                AbsCVal.Text = "";
        }

        private void SetABCField(RegisterUsage Usage, TextBox Box, Stub.Stringify AsString, int Val)
        {
            Box.Text = "No Impl";
            String Str = SelectedStub.StringifyInstruction(Usage, AsString, Val);
            if (Str != null)
                Box.Text = " = " + Str;
        }

        private void FromClipboardItem_Click(object sender, EventArgs e)
        {

        }

        private void FromRichTxtItem_Click(object sender, EventArgs e)
        {

        }

        private void SavePseudocodeItem_Click(object sender, EventArgs e)
        {

        }
    }
}
