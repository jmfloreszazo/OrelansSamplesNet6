using GrainInterface;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains;

public class SampleGrain : Grain, ISample
{
    private readonly ILogger _logger;

    public SampleGrain(ILogger<SampleGrain> logger)
    {
        this._logger = logger;
    }

    public Task<string> Response(string message)
    {
        _logger.LogInformation($"\n message received: '{message}'"); 
        return Task.FromResult($"\n '{message}' was received at {DateTime.Now}");
    }
}