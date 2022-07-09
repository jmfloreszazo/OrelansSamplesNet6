using GrainInterface;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

namespace Client;

public class Program
{
    private static int Main()
    {
        return RunMainAsync().Result;
    }

    private static async Task<int> RunMainAsync()
    {
        try
        {
            using (var client = await ConnectClient())
            {
                await DoClientWork(client);
                Console.ReadKey();
            }

            return 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n Exception when run client: {e.Message}");
            Console.WriteLine("\n Press any key to exit.");
            Console.ReadKey();
            return 1;
        }
    }

    private static async Task<IClusterClient> ConnectClient()
    {
        IClusterClient client;
        client = new ClientBuilder()
            .UseLocalhostClustering().Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "Test";
            })
            .ConfigureLogging(logging => logging.AddConsole()).Build();
        await client.Connect();
        Console.WriteLine("Client successfully connected to silo host \n");
        return client;
    }

    private static async Task DoClientWork(IClusterClient client)
    {
        var repeat = true;
        do
        {
            Console.WriteLine("Set Grain Id:");
            var grainId = Console.ReadLine();
            var newGuid = new Guid();
            var example = client.GetGrain<ICallingGrain>(newGuid);
            var response = await example.Increment(1);
            Console.WriteLine($"\n\n {response} \n\n");
            Console.WriteLine("Continue? Y/N");
            var continueResponse = Console.ReadLine();
            if (continueResponse?.ToUpper() == "N") repeat = false;
        } while (repeat);
    }
}