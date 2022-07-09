using Orleans;

namespace GrainInterface;

public interface ICallingGrain : IGrainWithGuidKey
{
    Task<int> Increment(int number);
    Task<string> ReturnStringMessage(int number);
}