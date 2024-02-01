using Merino.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System.Reflection;
using static Merino.Const.FWConst;

//TODO staticとインスタンスパフォーマンスどちらが良いか
//TODO 環境ごとの設定ファイルの切替えを起動時とビルド時どちらが良いか検討
//     →ビルド変数に合わせた方がよさそう。
//TODO FW側でDBプロパイダに対応しようとすると不要なdllが配置される
//     →プロジェクトを分ける？

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

        private static NLog.Logger _logger;

        private static MerinoSettings _setting;

        /// <summary>
        /// BuildWebApplication
        /// </summary>
        /// <param name="args"></param>
        /// <returns>WebApplicationBuilder</returns>
        public static WebApplicationBuilder BuildWebApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //NLog取得 当クラスのみで使用するインスタンス
            if (!File.Exists(Path.Combine(CONF_FOLDER_NAME, NLOG_CONF_FILE_NAME))) throw new DirectoryNotFoundException("設定ファイルが見つかりません。:" + Path.Combine(CONF_FOLDER_NAME, NLOG_CONF_FILE_NAME));
            _logger = NLogBuilder.ConfigureNLog(Path.Combine(CONF_FOLDER_NAME, NLOG_CONF_FILE_NAME)).GetCurrentClassLogger();
            _logger.Trace("▽MerinoWebApplication InitWebApplication▽");

            //Nlog登録
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

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

            //Database設定
            DatabaseSetting dbSetting = builder.Configuration.GetSection(nameof(DatabaseSetting)).Get<DatabaseSetting>() ?? throw new ArgumentNullException(nameof(DatabaseSetting));

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

        #region private methods

        #region 設定ファイル初期化
        /// <summary>
        /// 設定ファイル初期化
        /// </summary>
        private static void InitAppSettings(ref WebApplicationBuilder builder)
        {
            _logger.Trace("▽MerinoWebApplication InitAppSettings▽");

            //merino.json
            if(!File.Exists(Path.Combine(CONF_FOLDER_NAME, CONF_FILE_NAME))) throw new DirectoryNotFoundException("設定ファイルが見つかりません。:" + Path.Combine(CONF_FOLDER_NAME, CONF_FILE_NAME));
            builder.Configuration.AddJsonFile(Path.Combine(CONF_FOLDER_NAME, CONF_FILE_NAME), optional: false, reloadOnChange: true);
            builder.Services.Configure<MerinoSettings>(builder.Configuration.GetSection(nameof(MerinoSettings)));
            _setting = builder.Configuration.GetSection(nameof(MerinoSettings)).Get<MerinoSettings>() ?? throw new ArgumentNullException(nameof(MerinoSettings));
            SettingFile settingFile = _setting.SettingFile;

            //環境取得
            string? env = _setting.Env;
            List<EnvSetting>? envSetting = _setting.EnvSetting;
            string? envName = null;
            if (env != null && envSetting != null) envName = envSetting.Find(v => v.EnvCls == env).EnvName;

            //database.json
            string databaseFileName = "";
            if (!string.IsNullOrEmpty(settingFile.Database))
            {
                databaseFileName = Path.Combine(CONF_FOLDER_NAME, EnvSettingFileName(envName, settingFile.Database));
                builder.Configuration.AddJsonFile(databaseFileName, optional: false, reloadOnChange: true);
                builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection(nameof(DatabaseSetting)));
            }

            //アプリケーション固有設定ファイル読込
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

                    string fileName = Path.Combine(CONF_FOLDER_NAME, EnvSettingFileName(envName, item.FileName));

                    var instance = Activator.CreateInstance(classType);
                    builder.Configuration.AddJsonFile(fileName, optional: true, reloadOnChange: true);
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

            const string ADD_DB_CONTEXT_METHOD_NAME = "AddDbContext";

            foreach (DataSource setting in settingList)
            {

                if (setting.EntityFramework == null || !setting.EntityFramework.Valid) throw new ArgumentNullException(nameof(setting.EntityFramework));

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
                    case DbProvider.UseInMemoryDatabase:
                        //PostgreSQL実行Action作成 AddDbContextの引数用
                        action = delegate (DbContextOptionsBuilder op) { op.UseInMemoryDatabase("InMemory"); };
                        break;
                    default: throw new InvalidOperationException();
                }

                //AddDbContextメソッドを取得
                var addDbContextMethod = typeof(EntityFrameworkServiceCollectionExtensions)
                     .GetMethods().FirstOrDefault(m => m.Name == ADD_DB_CONTEXT_METHOD_NAME && m.IsGenericMethod)
                     .MakeGenericMethod(dbContextType);
                //AddDbContextを実行
                addDbContextMethod.Invoke(builder.Services, new object[] { builder.Services, action, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
            }

            _logger.Info("△MerinoWebApplication InitDbContext△");
        }
        #endregion

        #region 設定ファイル名の組み立て
        /// <summary>
        /// 設定ファイル名の組み立て
        /// </summary>
        /// <remarks>
        /// 環境名に合わせて設定ファイル名を作成して返す
        /// </remarks>
        /// <param name="envName">環境名</param>
        /// <param name="baseFileName">設定ファイル名</param>
        /// <returns>設定ファイル名</returns>
        private static string EnvSettingFileName(string? envName,string baseFileName )
        {
            return string.IsNullOrEmpty(envName)
                ? baseFileName
                : string.Join(".", baseFileName.Split(".").First(), envName, baseFileName.Split(".").Last());
        }
        #endregion

        #endregion
    }
}
