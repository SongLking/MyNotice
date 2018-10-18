using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using FileTool;
using Newtonsoft.Json.Linq;

namespace JsonViewerTool
{
    public partial class Form1 : Form
    {
        private OpenFileDialog m_OpenFileDialog;
        private SaveFileDialog m_SaveFileDialog;

        public Form1()
        {
            this.m_OpenFileDialog = new OpenFileDialog();
            this.m_SaveFileDialog = new SaveFileDialog();
            InitializeComponent(); 
            Init();
        }

        void Init()
        {
            this.m_OpenFileDialog.FileOk += new CancelEventHandler(this.ChooseSrcFileFinish);
            this.m_SaveFileDialog.FileOk += new CancelEventHandler(this.SaveTargetFilePath);
            
        }
        /// <summary>
        /// 打开窗口
        /// 添加需要配置的文件
        /// 及相关初始化        
        /// </summary>
        void OpenFile()
        {
            this.m_OpenFileDialog.Multiselect = true;
            this.m_OpenFileDialog.ShowDialog();
        }


        void UpdateConfigTree()
        {
            TreeNode tree = new TreeNode();
            
            //this.ConfigTree.Nodes.AddRange();
        }


        void Json2TreeNode(string srcFilePath)
        {
            string jsonData = null;
            bool isCorrectFormat = false;//CheckJsonFile(srcFilePath, out jsonData);
            jsonData = ReadFile(srcFilePath, out isCorrectFormat);
            if (isCorrectFormat)
            {
                string srcFileName = Path.GetFileName(srcFilePath).Split('.')[0];

                string jsonFinal = @jsonData;
                ConfigTree.Nodes.Clear();
                TreeNode root = new TreeNode();
                string errStr = null;
                JsonTree.BindTreeView(ref root, jsonFinal, out errStr);
                for (int i = 0; i < root.GetNodeCount(false); i++)
                {
                    this.ConfigTree.Nodes.Add(root.Nodes[i]);
                }
                
                if (!string.IsNullOrEmpty(errStr))
                {
                    LogError(errStr);
                }
                else
                {
                    Log("格式化成功");
                    CollapseCheckBox.Checked = true;
                }
            }
            else 
            {
                LogError("请检查Json格式，确保没有 “test”：{} 等空对象结构 "); 
            }
        }


        bool CheckJsonFile(string srcFilePath, out string jsonDatas)
        {
            bool readSuccess = false;
            if (!File.Exists(srcFilePath))
            {
                Log("路径文件不存在或路径不正确！！！\n 请检查文件");
                jsonDatas = null;
                return readSuccess;
            }
            jsonDatas = ReadFile(srcFilePath, out readSuccess);

            var Result = CheckJosn(jsonDatas) && readSuccess;

            return Result;
        }

        string ReadFile(string str, out bool success)
        {
            try
            {
                string file = File.ReadAllText(str);
                success = true;
                return file;
            }
            catch (IOException e)
            {
                Log("加载Json文件出错了");
                success = false;
                return null;
            }
        }

        bool CheckJosn(string fileData)
        {
            bool isCorrect = true;
            string resultStr = Check.CheckJson(fileData);
            if (!string.IsNullOrEmpty(resultStr))
            {
                isCorrect = false;
                Log(resultStr);
            }
            return isCorrect;
        }

        void TreeNode2Json()
        { 
            
        }

        private void TextTargetFilePath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                TextBox tb = sender as TextBox;
                if (tb.Name.Equals("TextJsonPath"))
                {                    
                    this.TextJsonPath.Text = files[0];                
                }
                this.TextSavePath.Text = files[0];
            }
        }
        
        private void TextTargetFilePath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void SaveTargetFilePath(object sender, CancelEventArgs e)
        {
            this.TextJsonPath.Text = this.m_SaveFileDialog.FileName;
            this.TextSavePath.Text = this.m_SaveFileDialog.FileName;
        }
        private void ChooseSrcFileFinish(object sender, CancelEventArgs e)
        {
            string fileStr = this.m_OpenFileDialog.FileName;
            this.TextJsonPath.Text = fileStr;
            this.TextSavePath.Text = fileStr;
        }

        private void BtnChooseJson_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

         void Log(string str)
        {
           Logger.AppendTextColorful(richTextChildStruct, str, Color.Green);
        }

         void Log(string format,params object[] args)
         {             
             Log(string.Format(format, args));
         }

         void LogError(string str)
         {
             Logger.AppendTextColorful(richTextChildStruct, str, Color.Red);
         }

         void LogError(string format, params object[] args)
         {
             LogError(string.Format(format, args));
         }

         private void BtnSaveFile_MouseEnter(object sender, EventArgs e)
         {
             toolTip2.SetToolTip(BtnSaveFile, "一旦保存，将直接覆盖源文件！");
         }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            if (!checkBoxSaveFile.Checked)
            {
                LogError("请勾选 确认保存 ！");
                return;
            }
            checkBoxSaveFile.Checked = false;
            string errTree2StringStr = null;
            string errSaveStr2FileStr = null;
            ConvertJsonTool jsonTool = new ConvertJsonTool();
            try
            {
                string formalJson = jsonTool.Tree2String(ConfigTree, out errTree2StringStr);

                if (!string.IsNullOrEmpty(errTree2StringStr))
                {
                    LogError(errTree2StringStr);
                    return;
                }
                jsonTool.SaveStr2File(TextSavePath.Text, formalJson, out errSaveStr2FileStr);
             
                if (!string.IsNullOrEmpty(errSaveStr2FileStr))
                {
                    LogError(errSaveStr2FileStr);
                }
                else
                {
                    Log("导出Json文件成功，路径在：{0}", TextSavePath.Text);
                }
            }
            catch (Exception ex)
            {

                LogError("保存文件存在异常：{0},Source:{1}",ex.Message,ex.Source);
            }

        }

        private void BtnFormat_Click(object sender, EventArgs e)
        {
            Json2TreeNode(this.TextJsonPath.Text);
        }

        private void BtnChooseJson_MouseEnter(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(BtnChooseJson, "文件中不能存在Value为空的情况，类似 \"test1\":{}或 \"test2\":{} 等内容！");
        }

        private void BtnFormat_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(BtnFormat, "格式化为路径中的内容，当前编辑的内容将全部丢失！");
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConfigTree.SelectedNode.Nodes.Add("NewNode");
            }
            catch (Exception)
            {
                Log("请检查是否选中树节点");
            }
        }
        private void BtnAddBro_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConfigTree.SelectedNode.Parent.Nodes.Add("NewNode");
            }
            catch (Exception ex)
            {
                this.ConfigTree.Nodes.Add("NewNode");
            }
        }

        private void BtnAddFileNode_Click(object sender, EventArgs e)
        {
            // 获取应用程序的当前工作目录。
            LogError(System.IO.Directory.GetCurrentDirectory());
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {            
            try
            {
                this.ConfigTree.LabelEdit = true;
                this.ConfigTree.SelectedNode.BeginEdit();
            }
            catch (Exception)
            {
                Log("请检查是否选中树节点");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConfigTree.Nodes.Remove(this.ConfigTree.SelectedNode);  
            }
            catch (Exception)
            {
                Log("请检查是否选中树节点");
            }
        }

        private void CheckBoxCollapse_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            
            if (checkBox.Checked)
            {
                this.ConfigTree.CollapseAll();
            }
            else
            {
                this.ConfigTree.ExpandAll();
            }
        }

        private void BtnClearConsole_Click(object sender, EventArgs e)
        {
            richTextChildStruct.Clear();
        }

       

        
    }
}
