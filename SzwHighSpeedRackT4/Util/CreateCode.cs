using Microsoft.VisualStudio.TextTemplating;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SzwHighSpeedRackT4
{
    internal class CreateCode
    {
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="templateModel">模板参数</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="templatePath">Template文件夹路径</param>
        /// <param name="fileInfos"></param>
        /// <returns></returns>
        public static (bool, string) CreatT4Class(TemplateModel templateModel, string savePath, string templatePath, List<ListBoxModel> fileInfos)
        {
            if (fileInfos != null && fileInfos.Count() > 0)
            {
                foreach (var item in fileInfos)
                {
                    // Template文件夹下.tt文件的路径名
                    string templateFileName = Path.Combine(templatePath, item.TableName);
                    TextTemplatingEngineHost host = new TextTemplatingEngineHost();
                    host.TemplateFileValue = templateFileName;
                    string input = File.ReadAllText(templateFileName);
                    host.Session = new TextTemplatingSession();
                    host.Session.Add("TemplateModel", templateModel);
                    string output = new Engine().ProcessTemplate(input, host);
                    StringBuilder errorWarn = new StringBuilder();
                    if (!string.IsNullOrWhiteSpace(savePath))
                    {
                        // 模板保存路径名
                        string saveTemplateName = item.TableName.Replace(".tt", string.Empty).Replace("Template", string.Empty);
                        // 实体文件名
                        string className = $"{item.TableName.Replace(".tt", string.Empty).Replace("Template", templateModel.ClassName.Replace("_", string.Empty))}.cs";
                        WriteAllText(savePath, saveTemplateName, className, output);
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
        /// <param name="saveTemplateName">模板保存路径名</param>
        /// <param name="className">实体文件名</param>
        /// <param name="outPut">写入的文件</param>
        public static void WriteAllText(string savePath, string saveTemplateName, string className, string outPut)
        {
            string pathdir = Path.Combine(savePath, saveTemplateName);
            if (!Directory.Exists(pathdir))
            {
                Directory.CreateDirectory(pathdir);
            }
            File.WriteAllText(Path.Combine(pathdir, className), outPut);
        }
    }
}