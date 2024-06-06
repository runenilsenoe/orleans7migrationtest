using Microsoft.Extensions.Hosting;
using Orleans.Hosting;
using SingleHost;
using SingleHostOrleans7;

await Host.CreateDefaultBuilder(args)
    .UseOrleans((context, siloBuilder) =>
    {
        var psql = true;
        siloBuilder.UseLocalhostClustering();
            //.AddStartupTask<StartupTask>();
        if (psql)
            siloBuilder.AddDevelopmentWithPsql(context);
        else
            siloBuilder
                .UseInMemoryReminderService()
                .AddMemoryGrainStorage("Grains");
    })
    .RunConsoleAsync();
    