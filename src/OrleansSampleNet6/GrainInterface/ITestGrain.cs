using Orleans;

namespace GrainInterface;

public interface ITestGrain : IGrainWithIntegerKey
{
    Task<string> ResponseTest(string message);
}