using Microsoft.AspNetCore.Mvc.Filters;
using Nlog.Framework.Log;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nlog.Framework.Filter
{
    /// <summary>
    /// <![CDATA[异步版本自定义全局异常过滤器]]>
    /// </summary>
    public class CustomerGlobalExceptionFilterAsync : IAsyncExceptionFilter
    {
        private readonly INLogHelper _logHelper;

        public CustomerGlobalExceptionFilterAsync(INLogHelper logHelper)
        {
            _logHelper = logHelper;
        }    

        /// <summary>
        /// <![CDATA[重新OnExceptionAsync方法]]>
        /// </summary>
        /// <param name="context"><![CDATA[异常信息]]></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            LogMessage logMessage = new LogMessage();
            // 如果异常没有被处理，则进行处理
            if (context.ExceptionHandled == false)
            {
                logMessage.StackTrace = context.Exception.StackTrace;
                logMessage.LogInfo = context.Exception.Message;

                // 记录错误信息
                _logHelper.LogError(logMessage);

                // 设置为true，表示异常已经被处理了，其它捕获异常的地方就不会再处理了
                context.ExceptionHandled = true;
            }
            return Task.CompletedTask;
        }
    }
}
