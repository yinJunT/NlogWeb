using System;
using System.Collections.Generic;
using System.Text;

namespace Nlog.Framework
{
    /// <summary>
    /// <![CDATA[日志记录消息]]>
    /// </summary>
    public class LogMessage
    {
        // 站点名称
        public string SiteName { get; set; }

        // 站点Url
        public string SiteUrl { get; set; }

        // 站点环境
        public string SiteEvm { get; set; }

        // IP地址
        public string IpAddress { get; set; }

        // 日志级别
        public string LogRank { get; set; }

        // 请求类
        public string ReqController { get; set; }

        // 请求方法
        public string ReqMethod { get; set; }

        // 请求参数
        public string ReqParas { get; set; }

        // 请求返回值
        public string ReqRetVal { get; set; }

        // 产生时间
        public string CreateTime { get; set; }

        // 错误内容
        public string LogInfo { get; set; }

        // 错误跟踪
        public string StackTrace { get; set; }
    }
}
