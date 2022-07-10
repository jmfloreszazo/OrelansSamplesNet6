using GrainInterface;
using Orleans;
using Orleans.Runtime;

namespace Grains;

public class ReminderGrain : Grain, IReminderGrain
{
    const string ReminderName = "reminderMessage";

    public Task ReceiveReminder(string reminderName, TickStatus status)
    {
        {
            Console.WriteLine($"Reminder message created at: {DateTime.Now}");
        }
        return Task.CompletedTask;
    }

    public Task SendMessage()
    {
        //return RegisterOrUpdateReminder(ReminderName, TimeSpan.FromMinutes(30), TimeSpan.FromHours(1));
        //This is for demo test... the other init It's for example for produccion
        return RegisterOrUpdateReminder(ReminderName, TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(1));
    }

    public async Task StopMessage()
    {
        foreach (var reminder in await GetReminders())
        {
            if (reminder.ReminderName == ReminderName)
            {
                await UnregisterReminder(reminder);
            }
        }
    }
}