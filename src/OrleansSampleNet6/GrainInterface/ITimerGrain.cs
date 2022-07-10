using Orleans;

namespace GrainInterface;

public interface ITimerGrain: IGrainWithGuidKey
{
    void StartTimer(); 
    void StopTimer();
}