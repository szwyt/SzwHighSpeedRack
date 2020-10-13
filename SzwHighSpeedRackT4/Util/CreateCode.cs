using System;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Linq;

namespace SzwHighSpeedRackT4
{
    internal class CreateCode
    {
        public static (bool, string) CreatT4Class(TemplateModel templateModel, string savePath, string templatePath)
        {
            DirectoryInfo folder = new DirectoryInfo(templatePath);
            var flieList = folder.GetFiles("*.tt");
            if (flieList != null && flieList.Count() > 0)
            {
                foreach (var item in flieList)
                {
                    string templateFileName = Path.Combine(templatePath, item.Name);
                    TextTemplatingEngineHost host = new TextTemplatingEngineHost();
                    host.TemplateFileValue = templateFileName;
                    string input = File.ReadAllText(templateFileName);
                    host.Session = new TextTemplatingSession();
                    host.Session.Add("TemplateModel", templateModel);
                    string output = new Engine().ProcessTemplate(input, host);
                    StringBuilder errorWarn = new StringBuilder();
                    if (!string.IsNullOrWhiteSpace(savePath))
                    {
                        string templateName = item.Name.Replace(".tt", string.Empty);
                        string className = $"{templateName.Replace("Template", templateModel.ClassName.Replace("_", string.Empty))}.cs";
                        WriteAllText(savePath, templateName, className, output);
                    }
                }
                return (true, "生成成功");
            }
            else
            {
                return (false, "生成失败");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="path">生成代码的路径</param>
        /// <param name="templateName"></param>
        /// <param name="className"></param>
        /// <param name="outPut"></param>
        public static void WriteAllText(string savePath, string templateName, string className, string outPut)
        {
            string pathdir = Path.Combine(savePath, templateName);
            if (!Directory.Exists(pathdir))
            {
                Directory.CreateDirectory(pathdir);
            }
            File.WriteAllText(Path.Combine(pathdir, className), outPut);
        }
    }
}