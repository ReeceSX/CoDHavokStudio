namespace HavokHelper
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SupportedOpsList = new System.Windows.Forms.CheckedListBox();
            this.MethodsView = new System.Windows.Forms.ListView();
            this.ClosureColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParameterColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpValColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FlagsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.InstructionLbl = new System.Windows.Forms.Label();
            this.IntLbl = new System.Windows.Forms.Label();
            this.NumLbl = new System.Windows.Forms.Label();
            this.ShareLbl = new System.Windows.Forms.Label();
            this.TypesLbl = new System.Windows.Forms.Label();
            this.FlagsLbl = new System.Windows.Forms.Label();
            this.EndianLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CurOpPseudo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AbsAVal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AbsBVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AbsCVal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PseudocodeBox = new System.Windows.Forms.RichTextBox();
            this.InstructionView = new System.Windows.Forms.ListView();
            this.InstIndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstructionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ConstantsView = new System.Windows.Forms.ListView();
            this.IndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImplementOpsGroup = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.FromFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FromClipboardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FromRichTxtItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.SavePseudocodeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.ImplementOpsGroup.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SupportedOpsList
            // 
            this.SupportedOpsList.FormattingEnabled = true;
            this.SupportedOpsList.Location = new System.Drawing.Point(0, 14);
            this.SupportedOpsList.Name = "SupportedOpsList";
            this.SupportedOpsList.Size = new System.Drawing.Size(259, 559);
            this.SupportedOpsList.TabIndex = 0;
            this.SupportedOpsList.SelectedIndexChanged += new System.EventHandler(this.SupportedOpsList_SelectedIndexChanged);
            // 
            // MethodsView
            // 
            this.MethodsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClosureColumn,
            this.ParameterColumn,
            this.RegColumn,
            this.UpValColumn,
            this.FlagsColumn});
            this.MethodsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MethodsView.GridLines = true;
            this.MethodsView.Location = new System.Drawing.Point(3, 16);
            this.MethodsView.Name = "MethodsView";
            this.MethodsView.Size = new System.Drawing.Size(289, 410);
            this.MethodsView.TabIndex = 5;
            this.MethodsView.UseCompatibleStateImageBehavior = false;
            this.MethodsView.View = System.Windows.Forms.View.Details;
            this.MethodsView.SelectedIndexChanged += new System.EventHandler(this.MethodsView_SelectedIndexChanged);
            // 
            // ClosureColumn
            // 
            this.ClosureColumn.Text = "Closure";
            this.ClosureColumn.Width = 86;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.Text = "Parameters";
            this.ParameterColumn.Width = 66;
            // 
            // RegColumn
            // 
            this.RegColumn.Text = "Regs";
            this.RegColumn.Width = 43;
            // 
            // UpValColumn
            // 
            this.UpValColumn.Text = "UpVals";
            this.UpValColumn.Width = 49;
            // 
            // FlagsColumn
            // 
            this.FlagsColumn.Text = "Flags";
            this.FlagsColumn.Width = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SizeLbl);
            this.groupBox1.Controls.Add(this.InstructionLbl);
            this.groupBox1.Controls.Add(this.IntLbl);
            this.groupBox1.Controls.Add(this.NumLbl);
            this.groupBox1.Controls.Add(this.ShareLbl);
            this.groupBox1.Controls.Add(this.TypesLbl);
            this.groupBox1.Controls.Add(this.FlagsLbl);
            this.groupBox1.Controls.Add(this.EndianLbl);
            this.groupBox1.Controls.Add(this.VersionLbl);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Location = new System.Drawing.Point(221, 97);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(10, 13);
            this.SizeLbl.TabIndex = 22;
            this.SizeLbl.Text = " ";
            // 
            // InstructionLbl
            // 
            this.InstructionLbl.AutoSize = true;
            this.InstructionLbl.Location = new System.Drawing.Point(221, 71);
            this.InstructionLbl.Name = "InstructionLbl";
            this.InstructionLbl.Size = new System.Drawing.Size(10, 13);
            this.InstructionLbl.TabIndex = 21;
            this.InstructionLbl.Text = " ";
            // 
            // IntLbl
            // 
            this.IntLbl.AutoSize = true;
            this.IntLbl.Location = new System.Drawing.Point(221, 45);
            this.IntLbl.Name = "IntLbl";
            this.IntLbl.Size = new System.Drawing.Size(10, 13);
            this.IntLbl.TabIndex = 20;
            this.IntLbl.Text = " ";
            // 
            // NumLbl
            // 
            this.NumLbl.AutoSize = true;
            this.NumLbl.Location = new System.Drawing.Point(221, 19);
            this.NumLbl.Name = "NumLbl";
            this.NumLbl.Size = new System.Drawing.Size(10, 13);
            this.NumLbl.TabIndex = 19;
            this.NumLbl.Text = " ";
            // 
            // ShareLbl
            // 
            this.ShareLbl.AutoSize = true;
            this.ShareLbl.Location = new System.Drawing.Point(57, 123);
            this.ShareLbl.Name = "ShareLbl";
            this.ShareLbl.Size = new System.Drawing.Size(10, 13);
            this.ShareLbl.TabIndex = 18;
            this.ShareLbl.Text = " ";
            // 
            // TypesLbl
            // 
            this.TypesLbl.AutoSize = true;
            this.TypesLbl.Location = new System.Drawing.Point(57, 97);
            this.TypesLbl.Name = "TypesLbl";
            this.TypesLbl.Size = new System.Drawing.Size(10, 13);
            this.TypesLbl.TabIndex = 17;
            this.TypesLbl.Text = " ";
            // 
            // FlagsLbl
            // 
            this.FlagsLbl.AutoSize = true;
            this.FlagsLbl.Location = new System.Drawing.Point(57, 71);
            this.FlagsLbl.Name = "FlagsLbl";
            this.FlagsLbl.Size = new System.Drawing.Size(10, 13);
            this.FlagsLbl.TabIndex = 16;
            this.FlagsLbl.Text = " ";
            // 
            // EndianLbl
            // 
            this.EndianLbl.AutoSize = true;
            this.EndianLbl.Location = new System.Drawing.Point(57, 45);
            this.EndianLbl.Name = "EndianLbl";
            this.EndianLbl.Size = new System.Drawing.Size(10, 13);
            this.EndianLbl.TabIndex = 15;
            this.EndianLbl.Text = " ";
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.Location = new System.Drawing.Point(57, 19);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(10, 13);
            this.VersionLbl.TabIndex = 14;
            this.VersionLbl.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "SizeT:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Instruction:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Integer:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Number:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Share:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Types:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Flags:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Endian:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Version:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MethodsView);
            this.groupBox2.Location = new System.Drawing.Point(0, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 429);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Code";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CurOpPseudo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.AbsAVal);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.AbsBVal);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.AbsCVal);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(445, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 202);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instruction Help";
            // 
            // CurOpPseudo
            // 
            this.CurOpPseudo.Location = new System.Drawing.Point(85, 112);
            this.CurOpPseudo.Name = "CurOpPseudo";
            this.CurOpPseudo.ReadOnly = true;
            this.CurOpPseudo.Size = new System.Drawing.Size(215, 84);
            this.CurOpPseudo.TabIndex = 12;
            this.CurOpPseudo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 26);
            this.label1.TabIndex = 26;
            this.label1.Text = "     Instruction\r\n Pseudocode:";
            // 
            // AbsAVal
            // 
            this.AbsAVal.Location = new System.Drawing.Point(33, 33);
            this.AbsAVal.Name = "AbsAVal";
            this.AbsAVal.ReadOnly = true;
            this.AbsAVal.Size = new System.Drawing.Size(267, 20);
            this.AbsAVal.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "A:";
            // 
            // AbsBVal
            // 
            this.AbsBVal.Location = new System.Drawing.Point(33, 59);
            this.AbsBVal.Name = "AbsBVal";
            this.AbsBVal.ReadOnly = true;
            this.AbsBVal.Size = new System.Drawing.Size(267, 20);
            this.AbsBVal.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "B:";
            // 
            // AbsCVal
            // 
            this.AbsCVal.Location = new System.Drawing.Point(33, 85);
            this.AbsCVal.Name = "AbsCVal";
            this.AbsCVal.ReadOnly = true;
            this.AbsCVal.Size = new System.Drawing.Size(267, 20);
            this.AbsCVal.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "C:";
            // 
            // PseudocodeBox
            // 
            this.PseudocodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PseudocodeBox.Location = new System.Drawing.Point(3, 16);
            this.PseudocodeBox.Name = "PseudocodeBox";
            this.PseudocodeBox.ReadOnly = true;
            this.PseudocodeBox.Size = new System.Drawing.Size(299, 327);
            this.PseudocodeBox.TabIndex = 11;
            this.PseudocodeBox.Text = "";
            // 
            // InstructionView
            // 
            this.InstructionView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InstIndexColumn,
            this.InstructionColumn,
            this.AColumn,
            this.BColumn,
            this.CColumn});
            this.InstructionView.GridLines = true;
            this.InstructionView.Location = new System.Drawing.Point(0, 19);
            this.InstructionView.Name = "InstructionView";
            this.InstructionView.Size = new System.Drawing.Size(439, 423);
            this.InstructionView.TabIndex = 8;
            this.InstructionView.UseCompatibleStateImageBehavior = false;
            this.InstructionView.View = System.Windows.Forms.View.Details;
            this.InstructionView.SelectedIndexChanged += new System.EventHandler(this.InstructionView_SelectedIndexChanged);
            // 
            // InstIndexColumn
            // 
            this.InstIndexColumn.Text = "Index";
            this.InstIndexColumn.Width = 48;
            // 
            // InstructionColumn
            // 
            this.InstructionColumn.Text = "Instruction";
            this.InstructionColumn.Width = 257;
            // 
            // AColumn
            // 
            this.AColumn.Text = "A";
            this.AColumn.Width = 42;
            // 
            // BColumn
            // 
            this.BColumn.Text = "B";
            this.BColumn.Width = 42;
            // 
            // CColumn
            // 
            this.CColumn.Text = "C";
            this.CColumn.Width = 42;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.ConstantsView);
            this.groupBox5.Controls.Add(this.InstructionView);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(301, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(755, 575);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Current Stub";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PseudocodeBox);
            this.groupBox4.Location = new System.Drawing.Point(445, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(305, 346);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stub Pseudocode";
            // 
            // ConstantsView
            // 
            this.ConstantsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IndexColumn,
            this.TypeColumn,
            this.ValueColumn});
            this.ConstantsView.Location = new System.Drawing.Point(0, 444);
            this.ConstantsView.Name = "ConstantsView";
            this.ConstantsView.Size = new System.Drawing.Size(439, 130);
            this.ConstantsView.TabIndex = 9;
            this.ConstantsView.UseCompatibleStateImageBehavior = false;
            this.ConstantsView.View = System.Windows.Forms.View.Details;
            // 
            // IndexColumn
            // 
            this.IndexColumn.Text = "Index";
            this.IndexColumn.Width = 45;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Text = "Type";
            this.TypeColumn.Width = 113;
            // 
            // ValueColumn
            // 
            this.ValueColumn.Text = "Value";
            this.ValueColumn.Width = 237;
            // 
            // ImplementOpsGroup
            // 
            this.ImplementOpsGroup.Controls.Add(this.SupportedOpsList);
            this.ImplementOpsGroup.Location = new System.Drawing.Point(1060, 28);
            this.ImplementOpsGroup.Name = "ImplementOpsGroup";
            this.ImplementOpsGroup.Size = new System.Drawing.Size(260, 575);
            this.ImplementOpsGroup.TabIndex = 10;
            this.ImplementOpsGroup.TabStop = false;
            this.ImplementOpsGroup.Text = "Implemented Operations";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1318, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FromFileItem,
            this.fromSourceToolStripMenuItem});
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton1.Text = "Load Source";
            // 
            // FromFileItem
            // 
            this.FromFileItem.Name = "FromFileItem";
            this.FromFileItem.Size = new System.Drawing.Size(141, 22);
            this.FromFileItem.Text = "From File";
            this.FromFileItem.Click += new System.EventHandler(this.FromFileItem_Click);
            // 
            // fromSourceToolStripMenuItem
            // 
            this.fromSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FromClipboardItem,
            this.FromRichTxtItem});
            this.fromSourceToolStripMenuItem.Name = "fromSourceToolStripMenuItem";
            this.fromSourceToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fromSourceToolStripMenuItem.Text = "From Source";
            // 
            // FromClipboardItem
            // 
            this.FromClipboardItem.Name = "FromClipboardItem";
            this.FromClipboardItem.Size = new System.Drawing.Size(135, 22);
            this.FromClipboardItem.Text = "Clipboard";
            this.FromClipboardItem.Click += new System.EventHandler(this.FromClipboardItem_Click);
            // 
            // FromRichTxtItem
            // 
            this.FromRichTxtItem.Name = "FromRichTxtItem";
            this.FromRichTxtItem.Size = new System.Drawing.Size(135, 22);
            this.FromRichTxtItem.Text = "Richtextbox";
            this.FromRichTxtItem.Click += new System.EventHandler(this.FromRichTxtItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SavePseudocodeItem});
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton2.Text = "Save Source";
            // 
            // SavePseudocodeItem
            // 
            this.SavePseudocodeItem.Name = "SavePseudocodeItem";
            this.SavePseudocodeItem.Size = new System.Drawing.Size(169, 22);
            this.SavePseudocodeItem.Text = "Save pseudocode ";
            this.SavePseudocodeItem.Click += new System.EventHandler(this.SavePseudocodeItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(116, 22);
            this.toolStripLabel1.Text = "Havok Kore Backend";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 604);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ImplementOpsGroup);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Havok Kore Script Helper";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ImplementOpsGroup.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox SupportedOpsList;
        private System.Windows.Forms.ListView MethodsView;
        private System.Windows.Forms.ColumnHeader ClosureColumn;
        private System.Windows.Forms.ColumnHeader ParameterColumn;
        private System.Windows.Forms.ColumnHeader UpValColumn;
        private System.Windows.Forms.ColumnHeader FlagsColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox PseudocodeBox;
        private System.Windows.Forms.ListView InstructionView;
        private System.Windows.Forms.ColumnHeader InstructionColumn;
        private System.Windows.Forms.ColumnHeader AColumn;
        private System.Windows.Forms.ColumnHeader BColumn;
        private System.Windows.Forms.ColumnHeader CColumn;
        private System.Windows.Forms.TextBox AbsAVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AbsBVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AbsCVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView ConstantsView;
        private System.Windows.Forms.ColumnHeader IndexColumn;
        private System.Windows.Forms.ColumnHeader TypeColumn;
        private System.Windows.Forms.ColumnHeader ValueColumn;
        private System.Windows.Forms.GroupBox ImplementOpsGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem FromFileItem;
        private System.Windows.Forms.ToolStripMenuItem fromSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FromClipboardItem;
        private System.Windows.Forms.ToolStripMenuItem FromRichTxtItem;
        private System.Windows.Forms.ToolStripMenuItem SavePseudocodeItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox CurOpPseudo;
        private System.Windows.Forms.Label SizeLbl;
        private System.Windows.Forms.Label InstructionLbl;
        private System.Windows.Forms.Label IntLbl;
        private System.Windows.Forms.Label NumLbl;
        private System.Windows.Forms.Label ShareLbl;
        private System.Windows.Forms.Label TypesLbl;
        private System.Windows.Forms.Label FlagsLbl;
        private System.Windows.Forms.Label EndianLbl;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.ColumnHeader RegColumn;
        private System.Windows.Forms.ColumnHeader InstIndexColumn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

