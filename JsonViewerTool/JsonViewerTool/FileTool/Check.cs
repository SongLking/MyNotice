
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace FileTool
{
    internal class Check
    {
        public static string CheckJsonFile(string jsonFilePath)
        {
            return Check.CheckJson(File.ReadAllText(jsonFilePath));
        }

        public static string CheckJson(string json)
        {
            string result;
            try
            {
                JObject jo = JsonConvert.DeserializeObject<JObject>(json);
                result = "";
            }
            catch (JsonReaderException e)
            {
                //string[] err = e.Path.Split(new char[]
                //{
                //    '.'
                //});
                //string str = string.Format("在Excel中的路径: id行 为 {0}, 属性列 为 {1}", err[0], err[1]);
                result = e.Message;
                
            }
            return result;
        }

    }
}
