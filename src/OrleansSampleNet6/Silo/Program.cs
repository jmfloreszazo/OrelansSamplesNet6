using System;
using System.Threading.Tasks;
using Grains;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace Silo;

public class Program
{
    public static int Main()
    {
        return RunMainAsync().Result;
    }

    private static async Task<int> RunMainAsync()
    {
        try
        {
            var host = await StartSilo();
            Console.WriteLine("\n\n Press Enter to terminate...\n\n");
            Console.ReadLine();
            await host.StopAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return 1;
        }
    }

    private static async Task<ISiloHost> StartSilo()
    {
        var builder = new SiloHostBuilder()
            .UseLocalhostClustering().Configure<Orleans.Configuration.ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "Test";
            })
            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(SampleGrain).Assembly).WithReferences())
            .ConfigureLogging(logging => logging.AddConsole());
        var host = builder.Build();
        await host.StartAsync();
        return host;
    }
}