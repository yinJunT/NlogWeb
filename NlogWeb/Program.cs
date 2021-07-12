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
            // ���ö�ȡָ��λ�õ�nlog.config�ļ�

            var logger = NLogBuilder.ConfigureNLog("XmlConfig/nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Info("��ʼ��");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "�����쳣");
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
                })/*.ConfigureLogging(logger=> {                  // ����ʹ��Nlog
                    logger.ClearProviders();
                    logger.SetMinimumLevel(LogLevel.Trace);
                }).UseNLog();   */
            .UseNLog();
    }
}
