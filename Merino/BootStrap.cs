using Merino.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System.Reflection;
using static Merino.Const.AppConst;

namespace Merino
{
    public class BootStrap
    {
        #region 定数
        /// <summary>
        /// 設定ファイル配置フォルダ名
        /// </summary>
        private const string CONF_FOLDER_NAME = "config";

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string CONF_FILE_NAME = "merino.json";

        /// <summary>
        /// Nlog conf filename
        /// </summary>
        private const string NLOG_CONF_FILE_NAME = "nlog.config";

        #endregion

        public static NLog.Logger _logger;

        public static MerinoSettings _setting;

        /// <summary>
        /// BuildWebApplication
        /// </summary>
        /// <param name="args"></param>
        /// <returns>WebApplicationBuilder</returns>
        public static WebApplicationBuilder BuildWebApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //_logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            _logger = NLogBuilder.ConfigureNLog(Path.Combine(CONF_FOLDER_NAME, NLOG_CONF_FILE_NAME)).GetCurrentClassLogger();
            _logger.Trace("▽MerinoWebApplication InitWebApplication▽");

            //設定ファイル読み込み
            InitAppSettings(ref builder);

            //独自の環境を設定
            //foreach(EnvSetting env in _setting.EnvSetting)
            //{
            //    if (_setting.Env == env.EnvCls)
            //    {
            //        builder.Environment.EnvironmentName = env.EnvName;
            //        break;
            //    }
            //}

            //Nlog登録
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            //Database設定
            DatabaseSetting dbSetting = builder.Configuration.GetSection(nameof(DatabaseSetting)).Get<DatabaseSetting>();

            //EntityFrameworkが有効なDataSource設定を取得
            var dataSourceList = dbSetting.DataSources.DataSource.Where(m => m.EntityFramework != null).ToList();
            if (dataSourceList != null && dataSourceList.Count >= 0)
            {
                //EntityFramework設定
                InitDbContext(dataSourceList, ref builder);
            }

            //依存注入 https://github.com/khellang/Scrutor/tree/master
            MerinoSettings setting = builder.Configuration.GetSection(nameof(MerinoSettings)).Get<MerinoSettings>();
            Assembly assembly = Assembly.Load(setting.InjectionAssemblyName);
            builder.Services.Scan(scan =>
                //scan.FromEntryAssembly()
                scan.FromAssemblyDependencies(assembly)
                //.AddClasses(classes => classes.InNamespaces("Services"))
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service") || type.Name.EndsWith("Repository") || type.Name.EndsWith("Dao")))
                //.UsingRegistrationStrategy(Scrutor.RegistrationStrategy.Skip)
                .AsMatchingInterface()
                //.WithSingletonLifetime());
                .WithScopedLifetime());

            //セッション
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "MerinoSession";
            });

            builder.Services.AddControllersWithViews();

            return builder;
        }

        /// <summary>
        /// CreateWebApplication
        /// </summary>
        /// <param name="builder"></param>
        /// <returns>WebApplication</returns>
        public static WebApplication CreateWebApplication(WebApplicationBuilder builder)
        {
            _logger.Trace("▽MerinoWebApplication CreateWebApplication▽");

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(_setting.Web.CustomErrorPage);
            }

            var test = app.Environment.EnvironmentName;
            //var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: _setting.Web.RootUrlPattern
                );

            _logger.Trace("△MerinoWebApplication CreateWebApplication△");
            return app;
        }

        /// <summary>
        /// RunWebApplication
        /// </summary>
        /// <param name="app"></param>
        public static void RunWebApplication(WebApplication app)
        {
            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "例外のためにプログラムを停止しました。");
                throw ex;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        /// <summary>
        /// InitWebApplication
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder InitWebApplication(ref WebApplicationBuilder builder)
        {

            try
            {
                _logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
                //_logger = NLogBuilder.ConfigureNLog(Path.Combine(CONF_FOLDER_NAME, NLOG_CONF_FILE_NAME)).GetCurrentClassLogger();
                _logger.Trace("▽MerinoWebApplication InitWebApplication▽");

                //設定ファイル読み込み
                InitAppSettings(ref builder);

                //Nlog登録
                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();

                //依存注入 https://github.com/khellang/Scrutor/tree/master
                builder.Services.Scan(scan =>
                    scan.FromEntryAssembly()
                    //.AddClasses(classes => classes.InNamespaces("Services"))
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service") || type.Name.EndsWith("Repository") || type.Name.EndsWith("Dao")))
                    //.UsingRegistrationStrategy(Scrutor.RegistrationStrategy.Skip)
                    .AsSelfWithInterfaces()
                    //.WithSingletonLifetime());
                    .WithScopedLifetime());

                //セッション
                builder.Services.AddSession(options =>
                {
                    options.Cookie.Name = "MerinoSession";
                });

            }
            catch (FileNotFoundException ex)
            {
                _logger.Error(ex, "設定ファイルが見つかりませんでした。");
                throw ex;
            }

            catch (Exception ex)
            {
                _logger.Error(ex, "例外のためにプログラムを停止しました。");
                throw ex;
            }
            finally
            {
                //NLog.LogManager.Shutdown();
            }

            _logger.Trace("△MerinoWebApplication InitWebApplication△");
            return builder;
        }

        #region 設定ファイル初期化
        /// <summary>
        /// 設定ファイル初期化
        /// </summary>
        private static void InitAppSettings(ref WebApplicationBuilder builder)
        {
            _logger.Trace("▽MerinoWebApplication InitAppSettings▽");

            //merino.json
            builder.Configuration.AddJsonFile(Path.Combine(CONF_FOLDER_NAME, CONF_FILE_NAME), optional: false, reloadOnChange: true);
            builder.Services.Configure<MerinoSettings>(builder.Configuration.GetSection(nameof(MerinoSettings)));

            _setting = builder.Configuration.GetSection(nameof(MerinoSettings)).Get<MerinoSettings>();
            var settingFile = _setting.SettingFile;

            //環境取得
            var env = _setting.Env;
            var envSetting = _setting.EnvSetting;
            var envName = envSetting.Find(v => v.EnvCls == env).EnvName;

            //database.json
            string fileName = Path.Combine(CONF_FOLDER_NAME, settingFile.Database);

            //未実装 フレームワークでは管理しない
            //if (!String.IsNullOrEmpty(envName))
            //{
            //    //環境に合わせて読込ファイル名を作成する
            //    settingFile.Database.Split('.').Last();
            //    fileName = Path.Combine(CONF_FOLDER_NAME, string.Join(".", settingFile.Database.Split('.').First(),envName ,settingFile.Database.Split('.').Last()));
            //}
            //else
            //{
            //    fileName = Path.Combine(CONF_FOLDER_NAME, settingFile.Database);
            //}
            builder.Configuration.AddJsonFile(fileName, optional: false, reloadOnChange: true);
            builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection(nameof(DatabaseSetting)));


            //独自設定ファイル読込
            List<CustomSettingFile> customSettingFiles = builder.Configuration.GetSection(nameof(MerinoSettings) + ":" + nameof(CustomSettingFile)).Get<List<CustomSettingFile>>();
            if (customSettingFiles != null)
            {
                foreach (CustomSettingFile item in customSettingFiles)
                {
                    //アセンブリ取得
                    Assembly assembly = Assembly.Load(item.AssemblyName);

                    //対象のクラスを取得
                    Type classType = assembly.GetType(item.ClassName);

                    if (classType == null)
                    {
                        // クラスが見つからない場合のエラー処理
                        throw new InvalidOperationException();
                    }

                    var instance = Activator.CreateInstance(classType);
                    builder.Configuration.AddJsonFile(Path.Combine(CONF_FOLDER_NAME, item.FileName), optional: true, reloadOnChange: true);
                    builder.Configuration.GetSection(classType.Name).Bind(instance);
                    builder.Services.AddSingleton(classType, instance);

                }
            }

            _logger.Trace("△MerinoWebApplication InitAppSettings△");
        }
        #endregion

        #region EntityFrameWork設定
        /// <summary>
        /// EntityFrameWork設定
        /// </summary>
        private static void InitDbContext(List<DataSource> settingList, ref WebApplicationBuilder builder)
        {
            _logger.Info("▽MerinoWebApplication InitDbContext▽");

            const string ADD_DB_CONTEXT = "AddDbContext";

            foreach (DataSource setting in settingList)
            {

                if (setting.EntityFramework == null || !setting.EntityFramework.Valid) throw new ArgumentNullException();

                //dbContextアセンブリ取得
                Assembly assembly = Assembly.Load(setting.EntityFramework.ContextAssemblyName);
                var dbContextType = assembly.GetType(setting.EntityFramework.ContextClassName);
                if (dbContextType == null)
                {
                    throw new InvalidOperationException();
                }

                //DbContextOptionsBuilder<>インスタンスを取得
                var optionsBuilderType = typeof(DbContextOptionsBuilder<>).MakeGenericType(dbContextType);
                var optionsBuilder = Activator.CreateInstance(optionsBuilderType);

                //DBプロパイダに合わせてアクションを作成
                Action<DbContextOptionsBuilder>? action = null;
                switch (setting.EntityFramework.UseDbProvider)
                {
                    case DbProvider.SqlServer:
                        //UseSqlServer実行Action作成 AddDbContextの引数用
                        action = delegate (DbContextOptionsBuilder op) { op.UseSqlServer(setting.ConnectionString); };
                        break;
                    case DbProvider.PostgreSQL:
                        //PostgreSQL実行Action作成 AddDbContextの引数用
                        action = delegate (DbContextOptionsBuilder op) { op.UseNpgsql(setting.ConnectionString); };
                        break;
                    default: throw new InvalidOperationException();
                }

                //AddDbContextメソッドを取得
                var addDbContextMethod = typeof(EntityFrameworkServiceCollectionExtensions)
                     .GetMethods().FirstOrDefault(m => m.Name == ADD_DB_CONTEXT && m.IsGenericMethod)
                     .MakeGenericMethod(dbContextType);
                //AddDbContextを実行
                addDbContextMethod.Invoke(builder.Services, new object[] { builder.Services, action, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
            }

            _logger.Info("△MerinoWebApplication InitDbContext△");
        }
        #endregion

    }
}
