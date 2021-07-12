using System;
using System.Collections.Generic;
using System.Text;

namespace Nlog.Framework.Log
{
    /// <summary>
    /// <![CDATA[格式化输出样式]]>
    /// </summary>
    public class LogFormat
    {
        public static string ErrorFormat(LogMessage logMessage) 
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\n1. 站点名称: " + logMessage.SiteName + " \r\n");
            strInfo.Append("2. 站点Url : " + logMessage.SiteUrl + "\r\n");
            strInfo.Append("3. 站点环境: " + logMessage.SiteEvm + "\r\n");
            strInfo.Append("4. 站点IP  : " + logMessage.IpAddress + "\r\n");
            strInfo.Append("5. 日志级别: " + logMessage.LogRank + "\r\n");
            strInfo.Append("6. 请求类名: " + logMessage.ReqController + "\r\n");
            strInfo.Append("7. 请求方法: " + logMessage.ReqMethod + "\r\n");
            strInfo.Append("8. 请求参数: " + logMessage.ReqParas + "\r\n");
            strInfo.Append("9. 返回值  : " + logMessage.ReqRetVal + "\r\n");
            strInfo.Append("10. 产生时间: " + logMessage.CreateTime + "\r\n");
            strInfo.Append("11. 错误信息: " + logMessage.LogInfo + "\r\n");
            strInfo.Append("12. 错误跟踪: " + logMessage.StackTrace + "\r\n");
            strInfo.Append("------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }
    }
}
