namespace SzwHighSpeedRackT4
{
    public class ToolsEx
    {
        /// <summary>
        /// 获取配置文件参数
        /// </summary>
        /// <param name="varName">参数名称</param>
        /// <returns></returns>
        public static string ConfigValue(string varName)
        {
            string outVar = "";
            try
            {
                outVar = System.Configuration.ConfigurationManager.AppSettings[varName];
                if (string.IsNullOrEmpty(outVar))
                {
                    outVar = "";
                }
                return outVar;
            }
            catch
            {
                return outVar;
            }
        }
    }
}