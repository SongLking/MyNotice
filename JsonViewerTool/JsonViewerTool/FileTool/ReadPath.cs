using System;
using System.IO;

namespace FileTool
{
    internal class ReadPath
    {
        private static string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        private static string savePath = ReadPath.path + "savePath.txt";

        private static string[] defaultPath = new string[]
		{
			"D:\\导出工具json文件夹",
			"D:\\导出工具lua文件夹"
		};

        public static string[] FindFile()
        {
            if (!File.Exists(ReadPath.savePath))
            {
                File.Create(ReadPath.savePath);
                StreamWriter writer = new StreamWriter(ReadPath.savePath);
                writer.WriteLine(ReadPath.defaultPath[0]);
                writer.Write(ReadPath.defaultPath[1]);
                writer.Close();
                return ReadPath.defaultPath;
            }
            string[] lines = File.ReadAllLines(ReadPath.savePath);
            if (lines != null)
            {
                if (lines.Length != 2 || string.IsNullOrEmpty(lines[0]) || string.IsNullOrEmpty(lines[1]))
                {
                    lines = new string[]
					{
						ReadPath.defaultPath[0],
						ReadPath.defaultPath[1]
					};
                }
                return lines;
            }
            return ReadPath.defaultPath;
        }

        public static void writePath(string[] pathStr)
        {
            Console.WriteLine("--------------------------" + ReadPath.savePath);
            if (!File.Exists(ReadPath.savePath))
            {
                File.Create(ReadPath.savePath);
            }
            if (pathStr == null || pathStr.Length != 2)
            {
                StreamWriter writer = new StreamWriter(ReadPath.savePath);
                writer.WriteLine(ReadPath.defaultPath[0]);
                writer.Write(ReadPath.defaultPath[1]);
                writer.Close();
                return;
            }
            StreamWriter writer2 = new StreamWriter(ReadPath.savePath);
            writer2.WriteLine(pathStr[0]);
            writer2.Write(pathStr[1]);
            writer2.Close();
        }

        public static void isExists()
        {
            if (!File.Exists(ReadPath.savePath))
            {
                FileStream file = File.Create(ReadPath.savePath);
                file.Close();
            }
        }
    }
}
