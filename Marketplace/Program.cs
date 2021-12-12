using static System.Environment;
using static System.Reflection.Assembly;
using Serilog;

namespace Marketplace
{
    public static class Program
    {
        static Program() => CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            var configuration = BuildConfiguration(args);

            ConfigureWebHost(configuration).Build().Run();
        }

        private static IConfiguration BuildConfiguration(string[] args)
            => new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .Build();

        private static IWebHostBuilder ConfigureWebHost(
            IConfiguration configuration)
            => new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                // .ConfigureServices(services => services.AddSingleton<IConfiguration>(configuration))
                .UseContentRoot(CurrentDirectory)
                .UseKestrel();
    }
}