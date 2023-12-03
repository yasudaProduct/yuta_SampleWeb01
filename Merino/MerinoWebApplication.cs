using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Merino
{
    public class MerinoWebApplication
    {
        public static WebApplicationBuilder CreateWebApplication(ref WebApplicationBuilder builder)
        {
            NLog.Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init MerinoWebApplication");

            try
            {

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();
                
            }
            catch (Exception exception)
            {
                logger.Error(exception, "例外のためにプログラムを停止しました。");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
            

            return builder;
        }
    }
}