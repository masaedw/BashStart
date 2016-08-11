using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace BashStartApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            Run(tokenSource.Token);
        }

        public static void Run(CancellationToken token)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run(token);
        }
    }
}
