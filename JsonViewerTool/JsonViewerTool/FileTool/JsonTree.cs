using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTool
{
    internal class JsonTree
    {

        /// <summary>
        /// 绑定树形控件
        /// </summary>
        /// <param name="rootTreeNode"></param>
        /// <param name="strJson"></param>
        public static void BindTreeView(ref TreeNode rootTreeNode, string strJson, out string errStr)
        {
            //strJson = "[{\"DeviceCode\":\"430BE-B3C6A-4E953-9F972-FC741\",\"RoomNum\":\"777\"},{\"DeviceCode\":\"BF79F -09807-EEA31-2499E-31A98\",\"RoomNum\":\"888\"}]";
            try
            {
                errStr = null;
                string errObjectStr = null;
                string errArrayStr = null;
                bool isJobject = IsJOjbect(strJson, out errObjectStr);
                bool isArray = IsJArray(strJson, out errArrayStr);
                if ((!isJobject) && (!isArray))
                {
                    errStr = "errObjectStr:" + errObjectStr + ", errArrayStr" + errArrayStr;
                    return;
                }
                if (isJobject)
                {
                    try
                    {
                        JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);
                        foreach (var item in jo)
                        {
                            TreeNode tree;
                            if (item.Value.GetType() == typeof(JObject))
                            {
                                tree = new TreeNode(item.Key);
                                AddTreeChildNode(ref tree, item.Value.ToString(), out errStr);
                                rootTreeNode.Nodes.Add(tree);
                            }
                            else if (item.Value.GetType() == typeof(JArray))
                            {
                                tree = new TreeNode(item.Key);
                                AddTreeChildNode(ref tree, item.Value.ToString(), out errStr);
                                rootTreeNode.Nodes.Add(tree);
                            }
                            else
                            {
                                tree = new TreeNode(item.Key);
                                TreeNode valueNode = new TreeNode(item.Value.ToString());
                                tree.Nodes.Add(valueNode);
                                rootTreeNode.Nodes.Add(tree);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //ShowMsg("请检查Json格式:" + ex.Message);
                        errStr = string.Format("导出失败 请检查json格式 BindTreeView:{0}, Source:{1}, StackTrace:{2}", ex.Message, ex.Source, ex.StackTrace);
                    }
                    
                }
                else if (isArray)
                {

                    JArray ja = (JArray)JsonConvert.DeserializeObject(strJson);
                    //dynamic ja = JsonConvert.DeserializeObject(strJson.ToString());
                    int i = 0;
                    try
                    {
                        foreach (JObject item in ja)
                        {
                            TreeNode tree = new TreeNode("Array_[" + (i++) + "]");
                            foreach (var itemOb in item)
                            {
                                TreeNode treeOb;
                                if (itemOb.Value.GetType() == typeof(JObject))
                                {
                                    treeOb = new TreeNode(itemOb.Key);
                                    AddTreeChildNode(ref treeOb, itemOb.Value.ToString(), out errStr);
                                    tree.Nodes.Add(treeOb);
                                }
                                else if (itemOb.Value.GetType() == typeof(JArray))
                                {
                                    treeOb = new TreeNode(itemOb.Key);
                                    AddTreeChildNode(ref treeOb, itemOb.Value.ToString(), out errStr);
                                    tree.Nodes.Add(treeOb);
                                }
                                else
                                {
                                    treeOb = new TreeNode(itemOb.Key);
                                    TreeNode childNode = new TreeNode(itemOb.Value.ToString());
                                    treeOb.Nodes.Add(childNode);
                                    tree.Nodes.Add(treeOb);
                                }
                            }
                            rootTreeNode.Nodes.Add(tree);
                        }
                    }
                    catch (Exception ex)
                    {
                        errStr = string.Format("导出失败 请检查json格式 BindTreeView:{0}, Source:{1}, StackTrace:{2}", ex.Message, ex.Source, ex.StackTrace);                        
                    }
                    
                }
                //treeView.ExpandAll();
            }
            catch (JsonException e)
            {
                //treeView.Nodes.Clear();
                errStr = string.Format("导出失败 请检查json格式 BindTreeView:{0}, Source:{1}, StackTrace:{2}", e.Message, e.Source, e.StackTrace);               
            }
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="parantNode"></param>
        /// <param name="value"></param>
        public static void AddTreeChildNode(ref TreeNode parantNode, string value, out string errStr)
        {
            errStr = null;
            string errObjectStr = null;
            string errArrayStr = null;
            bool isJobject = IsJOjbect(value, out errObjectStr);
            bool isArray = IsJArray(value, out errArrayStr);
            if ((!isJobject) && (!isArray))
            {
               errStr = "请检查Json格式:" + errObjectStr + errArrayStr;
                return;
            }
            if (isJobject)
            {
                try
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(value);
                    foreach (var item in jo)
                    {
                        TreeNode tree;
                        if (item.Value.GetType() == typeof(JObject))
                        {
                            tree = new TreeNode(item.Key);
                            AddTreeChildNode(ref tree, item.Value.ToString(), out errStr);
                            parantNode.Nodes.Add(tree);
                        }
                        else if (item.Value.GetType() == typeof(JArray))
                        {
                            tree = new TreeNode(item.Key);
                            AddTreeChildNode(ref tree, item.Value.ToString(), out errStr);
                            parantNode.Nodes.Add(tree);
                        }
                        else
                        {
                            tree = new TreeNode(item.Key);
                            TreeNode childNode = new TreeNode(item.Value.ToString());
                            tree.Nodes.Add(childNode);
                            parantNode.Nodes.Add(tree);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMsg("请检查Json格式:" + ex.Message);
                }
            }

            if (isArray)
            {
                try
                {
                    JArray ja = (JArray)JsonConvert.DeserializeObject(value);
                    int i = 0;
                    foreach (JObject item in ja)
                    {
                        TreeNode tree = new TreeNode("Array_[" + (i++) + "]");
                        parantNode.Nodes.Add(tree);
                        foreach (var itemOb in item)
                        {
                            TreeNode treeOb;
                            if (itemOb.Value.GetType() == typeof(JObject))
                            {
                                treeOb = new TreeNode(itemOb.Key);
                                AddTreeChildNode(ref treeOb, itemOb.Value.ToString(), out errStr);
                                tree.Nodes.Add(treeOb);

                            }
                            else if (itemOb.Value.GetType() == typeof(JArray))
                            {
                                treeOb = new TreeNode(itemOb.Key);
                                AddTreeChildNode(ref treeOb, itemOb.Value.ToString(), out errStr);
                                tree.Nodes.Add(treeOb);
                            }
                            else
                            {
                                treeOb = new TreeNode(itemOb.Key);
                                TreeNode childNode = new TreeNode(itemOb.Value.ToString());
                                treeOb.Nodes.Add(childNode);
                                tree.Nodes.Add(treeOb);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    ShowMsg("请检查Json格式:" + ex.Message);
                }
               
            }
        }

        private static void ShowMsg(string str)
        {
            MessageBox.Show(str);
        }

        /// <summary>
        /// 判断是否JOjbect类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsJOjbect(string value, out string ErrorMsg)
        {
            try
            {
                JObject ja = JObject.Parse(value);
                ErrorMsg = null;
                return true;
            }
            catch (Exception ex)
            {
                //ShowMsg("判断是否JOjbect类型" + ex.Message);
                ErrorMsg = string.Format("IsJOjbect 判断JOjbect类型:{0}, Source:{1}, StackTrace:{2}", ex.Message, ex.Source, ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 判断是否JArray类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsJArray(string value, out string ErrorMsg)
        {
            try
            {
                JArray ja = JArray.Parse(value);
                ErrorMsg = null;
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = string.Format("IsJArray 判断JArray类型:{0}, Source:{1}, StackTrace:{2}", ex.Message, ex.Source, ex.StackTrace);
                return false;
            }
        }
    }
}
