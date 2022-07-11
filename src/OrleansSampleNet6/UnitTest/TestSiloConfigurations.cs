using Grains;
using Orleans;
using Orleans.Hosting;
using Orleans.TestingHost;

namespace UnitTest;

public class TestSiloConfigurations : ISiloConfigurator
{
    public void Configure(ISiloBuilder siloBuilder)
    {
        siloBuilder.ConfigureApplicationParts(parts =>
            parts.AddApplicationPart(typeof(SampleGrain).Assembly).WithReferences());
        siloBuilder.ConfigureServices(services => {
            //services.AddSingleton<IService, Service>();
        });
    }
}