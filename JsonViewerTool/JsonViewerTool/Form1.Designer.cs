namespace JsonViewerTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {            
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnClearConsole = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxSaveFile = new System.Windows.Forms.CheckBox();
            this.richTextChildStruct = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CollapseCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAddFileNode = new System.Windows.Forms.Button();
            this.BtnAddBro = new System.Windows.Forms.Button();
            this.BtnAddChild = new System.Windows.Forms.Button();
            this.BtnSaveFile = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.ConfigTree = new System.Windows.Forms.TreeView();
            this.BtnFormat = new System.Windows.Forms.Button();
            this.BtnChooseJson = new System.Windows.Forms.Button();
            this.TextSavePath = new System.Windows.Forms.TextBox();
            this.TextJsonPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnClearConsole);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.checkBoxSaveFile);
            this.panel1.Controls.Add(this.richTextChildStruct);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CollapseCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnEdit);
            this.panel1.Controls.Add(this.BtnAddFileNode);
            this.panel1.Controls.Add(this.BtnAddBro);
            this.panel1.Controls.Add(this.BtnAddChild);
            this.panel1.Controls.Add(this.BtnSaveFile);
            this.panel1.Controls.Add(this.BtnDelete);
            this.panel1.Controls.Add(this.ConfigTree);
            this.panel1.Controls.Add(this.BtnFormat);
            this.panel1.Controls.Add(this.BtnChooseJson);
            this.panel1.Controls.Add(this.TextSavePath);
            this.panel1.Controls.Add(this.TextJsonPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 806);
            this.panel1.TabIndex = 1;
            // 
            // BtnClearConsole
            // 
            this.BtnClearConsole.Location = new System.Drawing.Point(475, 92);
            this.BtnClearConsole.Name = "BtnClearConsole";
            this.BtnClearConsole.Size = new System.Drawing.Size(75, 23);
            this.BtnClearConsole.TabIndex = 16;
            this.BtnClearConsole.Text = "Clear";
            this.BtnClearConsole.UseVisualStyleBackColor = true;
            this.BtnClearConsole.Click += new System.EventHandler(this.BtnClearConsole_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "将要添加的子节点文件路径：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(581, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(598, 21);
            this.textBox1.TabIndex = 14;
            // 
            // checkBoxSaveFile
            // 
            this.checkBoxSaveFile.AutoSize = true;
            this.checkBoxSaveFile.Location = new System.Drawing.Point(1128, 729);
            this.checkBoxSaveFile.Name = "checkBoxSaveFile";
            this.checkBoxSaveFile.Size = new System.Drawing.Size(72, 16);
            this.checkBoxSaveFile.TabIndex = 13;
            this.checkBoxSaveFile.Text = "确认保存";
            this.checkBoxSaveFile.UseVisualStyleBackColor = true;
            // 
            // richTextChildStruct
            // 
            this.richTextChildStruct.Location = new System.Drawing.Point(9, 116);
            this.richTextChildStruct.Name = "richTextChildStruct";
            this.richTextChildStruct.Size = new System.Drawing.Size(541, 587);
            this.richTextChildStruct.TabIndex = 12;
            this.richTextChildStruct.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 729);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "文件导出路径：";
            // 
            // CollapseCheckBox
            // 
            this.CollapseCheckBox.AutoSize = true;
            this.CollapseCheckBox.Location = new System.Drawing.Point(1081, 96);
            this.CollapseCheckBox.Name = "CollapseCheckBox";
            this.CollapseCheckBox.Size = new System.Drawing.Size(108, 16);
            this.CollapseCheckBox.TabIndex = 10;
            this.CollapseCheckBox.Text = "折叠所有树节点";
            this.CollapseCheckBox.UseVisualStyleBackColor = true;
            this.CollapseCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCollapse_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "console";
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnEdit.Location = new System.Drawing.Point(1048, 48);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(121, 23);
            this.BtnEdit.TabIndex = 7;
            this.BtnEdit.Text = "编辑选中";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAddFileNode
            // 
            this.BtnAddFileNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnAddFileNode.Location = new System.Drawing.Point(581, 17);
            this.BtnAddFileNode.Name = "BtnAddFileNode";
            this.BtnAddFileNode.Size = new System.Drawing.Size(121, 23);
            this.BtnAddFileNode.TabIndex = 6;
            this.BtnAddFileNode.Text = "渠道添加";
            this.BtnAddFileNode.UseVisualStyleBackColor = false;
            this.BtnAddFileNode.Click += new System.EventHandler(this.BtnAddFileNode_Click);
            // 
            // BtnAddBro
            // 
            this.BtnAddBro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnAddBro.Location = new System.Drawing.Point(911, 11);
            this.BtnAddBro.Name = "BtnAddBro";
            this.BtnAddBro.Size = new System.Drawing.Size(121, 23);
            this.BtnAddBro.TabIndex = 6;
            this.BtnAddBro.Text = "添加兄弟节点";
            this.BtnAddBro.UseVisualStyleBackColor = false;
            this.BtnAddBro.Click += new System.EventHandler(this.BtnAddBro_Click);
            // 
            // BtnAddChild
            // 
            this.BtnAddChild.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAddChild.Location = new System.Drawing.Point(1048, 11);
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.Size = new System.Drawing.Size(121, 23);
            this.BtnAddChild.TabIndex = 6;
            this.BtnAddChild.Text = "添加子节点";
            this.BtnAddChild.UseVisualStyleBackColor = false;
            this.BtnAddChild.Click += new System.EventHandler(this.BtnAddChild_Click);
            // 
            // BtnSaveFile
            // 
            this.BtnSaveFile.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSaveFile.Location = new System.Drawing.Point(993, 709);
            this.BtnSaveFile.Name = "BtnSaveFile";
            this.BtnSaveFile.Size = new System.Drawing.Size(121, 39);
            this.BtnSaveFile.TabIndex = 5;
            this.BtnSaveFile.Text = "保存文件";
            this.BtnSaveFile.UseVisualStyleBackColor = false;
            this.BtnSaveFile.Click += new System.EventHandler(this.BtnSaveFile_Click);
            this.BtnSaveFile.MouseEnter += new System.EventHandler(this.BtnSaveFile_MouseEnter);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnDelete.Location = new System.Drawing.Point(911, 48);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(121, 23);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "删除选中";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // ConfigTree
            // 
            this.ConfigTree.Location = new System.Drawing.Point(570, 116);
            this.ConfigTree.Name = "ConfigTree";
            this.ConfigTree.Size = new System.Drawing.Size(619, 587);
            this.ConfigTree.TabIndex = 4;
            // 
            // BtnFormat
            // 
            this.BtnFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BtnFormat.Location = new System.Drawing.Point(403, 3);
            this.BtnFormat.Name = "BtnFormat";
            this.BtnFormat.Size = new System.Drawing.Size(127, 36);
            this.BtnFormat.TabIndex = 2;
            this.BtnFormat.Text = "格式化原配置文件";
            this.BtnFormat.UseVisualStyleBackColor = false;
            this.BtnFormat.Click += new System.EventHandler(this.BtnFormat_Click);
            this.BtnFormat.MouseEnter += new System.EventHandler(this.BtnFormat_MouseEnter);
            // 
            // BtnChooseJson
            // 
            this.BtnChooseJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnChooseJson.Location = new System.Drawing.Point(260, 4);
            this.BtnChooseJson.Name = "BtnChooseJson";
            this.BtnChooseJson.Size = new System.Drawing.Size(127, 36);
            this.BtnChooseJson.TabIndex = 2;
            this.BtnChooseJson.Text = "选择待配置文件";
            this.BtnChooseJson.UseVisualStyleBackColor = false;
            this.BtnChooseJson.Click += new System.EventHandler(this.BtnChooseJson_Click);
            this.BtnChooseJson.MouseEnter += new System.EventHandler(this.BtnChooseJson_MouseEnter);
            // 
            // TextSavePath
            // 
            this.TextSavePath.AllowDrop = true;
            this.TextSavePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextSavePath.Location = new System.Drawing.Point(102, 722);
            this.TextSavePath.Name = "TextSavePath";
            this.TextSavePath.Size = new System.Drawing.Size(885, 26);
            this.TextSavePath.TabIndex = 1;
            this.TextSavePath.Tag = "";
            this.TextSavePath.Text = "G:\\SIBGame\\trunk\\Program\\YY-CDN\\config\\serverversionconfig.json";
            this.TextSavePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextTargetFilePath_DragDrop);
            this.TextSavePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextTargetFilePath_DragEnter);
            // 
            // TextJsonPath
            // 
            this.TextJsonPath.AllowDrop = true;
            this.TextJsonPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextJsonPath.Location = new System.Drawing.Point(6, 45);
            this.TextJsonPath.Name = "TextJsonPath";
            this.TextJsonPath.Size = new System.Drawing.Size(554, 26);
            this.TextJsonPath.TabIndex = 1;
            this.TextJsonPath.Tag = "";
            this.TextJsonPath.Text = "G:\\SIBGame\\trunk\\Program\\YY-CDN\\config\\serverversionconfig.json";
            this.TextJsonPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextTargetFilePath_DragDrop);
            this.TextJsonPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextTargetFilePath_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "将要编辑的Json文件路径:";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "注意：";
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipTitle = "特别注意：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 763);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "ParseJson";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnChooseJson;
        private System.Windows.Forms.TextBox TextJsonPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAddChild;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnFormat;
        private System.Windows.Forms.Button BtnSaveFile;
        private System.Windows.Forms.TextBox TextSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CollapseCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnAddBro;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.RichTextBox richTextChildStruct;
        private System.Windows.Forms.TreeView ConfigTree;
        private System.Windows.Forms.CheckBox checkBoxSaveFile;
        private System.Windows.Forms.Button BtnAddFileNode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnClearConsole;
    }
}

