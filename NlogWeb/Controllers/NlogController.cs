using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nlog.Framework;
using Nlog.Framework.Log;
using Nlog.Framework.Unit;
using NLog;
using NLog.Targets;
using System;
using System.IO;
using System.Text;

namespace NlogWeb.Controllers
{
    [ApiController]
    public class NlogController : ControllerBase
    {
        private readonly ILogger<NlogController> _logger;
        private INLogHelper _INLogHelper;
        public NlogController(ILogger<NlogController> logger, INLogHelper NLogHelper)
        {
            _logger = logger;
            _INLogHelper = NLogHelper;
        }

        [HttpGet, Route("nlog/index")]
        public IActionResult Index(string name)
        {
            string data = "";
            using (MemoryStream ms = new MemoryStream())
            {
                Request.Body.CopyToAsync(ms);
                // 设置当前流的位置为0

                ms.Seek(0, SeekOrigin.Begin);
                // 这里ReadToEnd执行完毕后requestBodyStream流的位置会从0到最后位置(即request.ContentLength)

                data = new StreamReader(ms, Encoding.UTF8).ReadToEnd();
            }
            var configuration = LogManager.Configuration;
            var fileTarget = configuration.FindTargetByName<FileTarget>("allfile");
            fileTarget.FileName = "G:\\站点日志\\" + name + "\\" + name + "" + "_${shortdate}.log";
            LogMessage logMessage = new LogMessage();
            _INLogHelper.LogError(logMessage);
            return Ok();
        }

        [HttpPost, Route("nlog/addlog")]
        public IActionResult AddLog()
        {
            string data = "";
            using (MemoryStream ms = new MemoryStream())
            {
                Request.Body.CopyToAsync(ms);
                //设置当前流的位置为0

                ms.Seek(0, SeekOrigin.Begin);
                //这里ReadToEnd执行完毕后requestBodyStream流的位置会从0到最后位置(即request.ContentLength)

                data = new StreamReader(ms, Encoding.UTF8).ReadToEnd();
            }
            LogMessage log = JsonHelper.JsonStringToObj<LogMessage>(data);       
            var configuration = LogManager.Configuration;
            var fileTarget = configuration.FindTargetByName<FileTarget>("allfile");
            fileTarget.FileName = "G:\\站点日志\\" + log.SiteName + "\\" + log.SiteName + "_${shortdate}.log";
            _INLogHelper.LogError(log);
            _logger.LogInformation(data);
            return Ok();
        }
    }
}
