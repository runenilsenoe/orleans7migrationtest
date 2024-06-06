using Microsoft.Extensions.Hosting;
using Orleans.Hosting;
using SingleHost;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.UseLocalhostClustering()
            .UseInMemoryReminderService()
            //.ConfigureApplicationParts(x => x.AddApplicationPart(typeof(HelloGrain).Assembly).wi
            .AddMemoryGrainStorage("Grains")
            .AddStartupTask<StartupTask>();
    })
    .RunConsoleAsync();
    