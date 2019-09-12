using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AuthDemo.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var buider = CreateWebHostBuilder(args).Build();
            await buider.InitAsync();
            await buider.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}