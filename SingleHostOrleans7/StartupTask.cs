using Orleans;
using Orleans.Runtime;
using SingleHostOrleans7;

namespace SingleHost;

public class StartupTask : IStartupTask
{
    private readonly IGrainFactory grainFactory;

    public StartupTask(IGrainFactory grainFactory)
    {
        this.grainFactory = grainFactory;
    }

    public async Task Execute(CancellationToken cancellationToken)
    {
        var grain = grainFactory.GetGrain<IHelloGrain>(Guid.Empty);
        await grain.PrintHelloOnTimer();
    }
}