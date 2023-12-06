using Merino.config;
using Merino.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Runtime;

namespace Merino
{
    public class MerinoWebApplication
    {
        public static WebApplicationBuilder InitWebApplication(ref WebApplicationBuilder builder)
        {
            NLog.Logger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("MerinoWebApplication init");

            try
            {
                //Nlog登録
                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();

                //設定ファイル読み込み
                //TODO optionalをtrueにする(ファイルが存在しない場合エラー)
                var confFolder = "config";

                builder.Configuration.AddJsonFile(Path.Combine(confFolder, "MerinoWebAppSettings.json"), optional: false, reloadOnChange: true);
                builder.Services.Configure<AppSetteings>(builder.Configuration.GetSection("App"));

                //TODO SettingFileの中身に記載されているファイルを読み込みたい
                var settingFile = builder.Configuration.GetSection("App:"+ nameof(SettingFile)).Get<SettingFile>();
                builder.Configuration.AddJsonFile(Path.Combine(confFolder, settingFile.Database), optional: false, reloadOnChange: true);
                builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseSetting"));


                //依存注入 https://github.com/khellang/Scrutor/tree/master
                builder.Services.Scan(scan =>
                    scan.FromEntryAssembly()
                    //.AddClasses(classes => classes.InNamespaces("Services"))
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service") || type.Name.EndsWith("Business")|| type.Name.EndsWith("Dao")))
                    //.UsingRegistrationStrategy(Scrutor.RegistrationStrategy.Skip)
                    .AsSelfWithInterfaces()
                    //.WithSingletonLifetime());
                    .WithScopedLifetime());


            }
            catch (FileNotFoundException ex)
            {
                logger.Error(ex, "設定ファイルが見つかりませんでした。");
                throw ex;
            }

            catch (Exception ex)
            {
                logger.Error(ex, "例外のためにプログラムを停止しました。");
                throw ex;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
            

            return builder;
        }
    }
}