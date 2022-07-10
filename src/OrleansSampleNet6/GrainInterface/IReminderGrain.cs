using Orleans;

namespace GrainInterface;

public interface IReminderGrain : IGrainWithStringKey, IRemindable
{
    Task SendMessage(); 
    Task StopMessage();
}