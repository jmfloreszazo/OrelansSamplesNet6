using GrainInterface;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains;

public class SampleTestGrain : Grain, ITestGrain

{
    private readonly ILogger _logger;

    public SampleTestGrain(ILogger<SampleTestGrain> logger)
    {
        _logger = logger;
    }

    public Task<string> ResponseTest(string message)
    {
        _logger.LogInformation($"\n message received from test grain: '{message}'"); 
        return Task.FromResult($"\n '{message}' was received message from test grain at {DateTime.Now}");
    }
}