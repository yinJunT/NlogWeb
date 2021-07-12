using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nlog.Framework.Log
{
    public class NLogHelper : INLogHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILogger<NLogHelper> _logger;

        public NLogHelper(IHttpContextAccessor httpContextAccessor, ILogger<NLogHelper> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        /// <summary>
        ///  <![CDATA[日志输出]]>
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(LogMessage logMessage)
        {
            logMessage.IpAddress = _httpContextAccessor.HttpContext.Request.Host.Host;      // 站点IP
            logMessage.SiteUrl = "www.***.com";                                             // 站点Url
            logMessage.SiteEvm = "测试环境";                                                // 站点环境

            logMessage.ReqParas = "***";                                                    // 请求参数
            logMessage.ReqRetVal = "***";                                                   // 请求返回值
            logMessage.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");           // 产生时间

            _logger.LogError(LogFormat.ErrorFormat(logMessage));
        }
    }
}
