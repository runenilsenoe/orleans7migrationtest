using Orleans.Runtime;

namespace SingleHostOrleans7;

public class HelloGrain : Grain, IHelloGrain
{
    IGrainReminder? _reminder = null;
    public async Task<string> PrintHelloOnTimer()
    {
        _reminder = await this.RegisterOrUpdateReminder("reminder123", TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60));
        return "set";
    }

    public Task ReceiveReminder(string reminderName, TickStatus status)
    {
        Console.WriteLine($"Reminded my boii: {reminderName}");
        return Task.CompletedTask;
    }
}

public interface IHelloGrain: IGrainWithGuidKey,IRemindable
{
    Task<string> PrintHelloOnTimer();
}