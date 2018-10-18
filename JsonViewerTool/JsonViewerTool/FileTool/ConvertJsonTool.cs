using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTool
{
    internal class ConvertJsonTool
    {
        StringBuilder strJson;
        public string Tree2String(TreeView tree, out string errStr)
        {
            try
            {
                errStr = null;
                strJson = new StringBuilder();
                strJson.Append("{");
                int broCount = tree.GetNodeCount(false);
                for (int i = 0; i < broCount; i++)
                {
                    TreeNode2Json(tree.Nodes[i], i, broCount);
                }
                strJson.Append("}");
                string fristJsonStr = strJson.ToString();

                string formatJsonStr = FormatString2Json(fristJsonStr, out errStr);

                return formatJsonStr;
            }
            catch (Exception ex)
            {                
                errStr = "Tree2String" + ex.Message + ex.Source + ex.TargetSite;
                return null;
            }


        }

        private bool isDefaultKey(string str)
        {
            return str.Contains("Array_");
        }

        /// <summary>
        /// 将无换行等格式的json转为规则的json
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatString2Json(string str, out string errStr)
        {
            try
            {
                errStr = null;
                //格式化json字符串
                JsonSerializer serializer = new JsonSerializer();
                TextReader tr = new StringReader(str);
                JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    serializer.Serialize(jsonWriter, obj);
                    return textWriter.ToString();
                }
                else
                {
                    return str;
                }
            }
            catch (Exception ex)
            {
                errStr = "FormatJson:" + ex.Message + ex.Source + ex.StackTrace;
                return "";
            }

        }

        /// <summary>
        /// 将TreeNode结构转为Json格式的String
        /// </summary>
        /// <param name="tree">TreeNode 节点</param>
        /// <param name="treeIndexInParent">当前节点在父节点中的Index</param>
        /// <param name="broCount"></param>
        public void TreeNode2Json(TreeNode tree, int treeIndexInParent, int broCount)
        {
            try
            {
                int childCount = tree.GetNodeCount(false);
                if (tree.Text.Contains("Array_[0]"))
                {
                    strJson.Append("[");
                }

                //if (isDefaultKey(tree.Text))
                //{
                //    strJson.Append("{");
                //}


                for (int childIndex = 0; childIndex < childCount; childIndex++)
                {




                    int grandsonCount = tree.Nodes[childIndex].GetNodeCount(false);
                    if (grandsonCount > 0)
                    {


                        if (childIndex == 0 && !isDefaultKey(tree.Text))
                        {
                            strJson.AppendFormat("\"{0}\": ", tree.Text);
                        }

                        if (childIndex == 0 && childCount > 1 && !isDefaultKey(tree.Nodes[0].Text))
                        {
                            strJson.Append("{");
                        }

                        TreeNode2Json(tree.Nodes[childIndex], childIndex, childCount);
                    }
                    else
                    {
                        string nodeValue = tree.Nodes[childIndex].Text;
                        int intValue = 0;
                        bool boolValue = false;
                        if (int.TryParse(nodeValue, out intValue))
                        {
                            nodeValue = string.Format("{0}", intValue.ToString());
                        }
                        else if (bool.TryParse(nodeValue, out boolValue))
                        {

                            nodeValue = string.Format("{0}", boolValue ? "true" : "false");
                        }
                        else
                        {
                            nodeValue = string.Format("\"{0}\"", nodeValue);
                        }
                        strJson.AppendFormat("\"{0}\": {1}", tree.Text, nodeValue);

                        //最深层 { } 括号内结束时的逗号判断完成

                        if (treeIndexInParent < broCount - 1)
                        {
                            strJson.Append(",");
                        }
                        else
                        {
                            strJson.Append("}");

                            if (tree.Parent != null && tree.Parent.NextNode != null)
                            {
                                strJson.Append(",");
                            }
                        }


                    }
                }

                if (tree.Text.Contains(string.Format("Array_[{0}]", broCount - 1)))
                {
                    int strJsonLength = strJson.Length;
                    char strSbLastChar = strJson[strJson.Length - 1];
                    if (strSbLastChar.Equals(']'))
                    {
                        strJson.Append("}");
                    }
                    strJson.Append("]");
                    if (tree.Parent.NextNode != null)
                    {
                        strJson.Append(",");
                    }
                }
            }
            catch (Exception ex)
            {

                ShowMsg("TreeNode2Json:" + ex.Message + ex.Source + ex.StackTrace);
            }

        }

        /// <summary>
        /// 保存文本到文件夹
        /// </summary>
        /// <param name="targetFilePath">保存的路径</param>
        /// <param name="Content">直接保存  不做另外处理的内容</param>
        /// <param name="errStr">如果没有异常，该值为 null</param>
        public void SaveStr2File(string targetFilePath, string Content, out string errStr)
        {
            try
            {
                errStr = null;
                StreamWriter writer = new StreamWriter(targetFilePath);
                writer.NewLine = "\n";
                writer.WriteLine(Content);
                writer.Close();
            }
            catch (Exception ex)
            {
                errStr = "SaveStr2File 保存文件出现异常：" + ex.Source + ex.Message;
            }

        }

        public void ShowMsg(string str)
        {
            MessageBox.Show(str);
        }
    }
}
