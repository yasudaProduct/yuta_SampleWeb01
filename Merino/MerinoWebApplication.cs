using Merino.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Merino
{
    public class MerinoWebApplication
    {
        public static WebApplicationBuilder InitWebApplication(ref WebApplicationBuilder builder)
        {
            NLog.Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init MerinoWebApplication");

            try
            {
                //builder.Services.AddDbContext<MerinoDbContext>(options =>
                //options.UseSqlServer(builder.Configuration.GetConnectionString("yuta_SampleWeb01Context") ?? throw new InvalidOperationException("Connection string 'yuta_SampleWeb01Context' not found.")));

                //依存注入
                builder.Services.Scan(scan =>
                    scan.FromEntryAssembly()
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime());
                
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