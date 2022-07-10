using GrainInterface;
using Orleans;

namespace Grains;

public class TimerGrain : Grain, ITimerGrain
{
    private IDisposable _timer;

    public void StartTimer()
    {
        Console.WriteLine($"Timer Started {DateTime.Now}");
    }

    public void StopTimer()
    {
        _timer.Dispose();
        Console.WriteLine($"Timer Stopped {DateTime.Now}");
    }

    public override Task OnActivateAsync()
    {
        var count = 1;
        _timer = RegisterTimer(state =>
        {
            Console.WriteLine($"Timer number: {count}");
            count++;
            return base.OnActivateAsync();
        }, null, TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(2));
        return base.OnActivateAsync();
    }
}