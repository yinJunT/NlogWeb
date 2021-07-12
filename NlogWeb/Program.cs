using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using System;

namespace NlogWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 设置读取指定位置的nlog.config文件

            var logger = NLogBuilder.ConfigureNLog("XmlConfig/nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Info("初始化");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "启动异常");
            }
            finally 
            {
                LogManager.Shutdown();
            }          
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })/*.ConfigureLogging(logger=> {                  // 配置使用Nlog
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Trace);
                }).UseNLog();   */
            .UseNLog();
    }
}
