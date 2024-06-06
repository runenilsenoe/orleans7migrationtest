
using Microsoft.Extensions.Configuration;
using Orleans.Hosting;
using HostBuilderContext = Microsoft.Extensions.Hosting.HostBuilderContext;

namespace SingleHost;

public static class HostExtensions
{
    
    private static string PsqlGrainStorageConnectionString(HostBuilderContext context) => context.Configuration.GetConnectionString("OrleansState");
    private static string PsqlReminderConnectionString(HostBuilderContext context) => context.Configuration.GetConnectionString("OrleansReminder");
    const string invariant = "Npgsql";
    public static void AddDevelopmentWithPsql(this ISiloBuilder builder, HostBuilderContext context)
    {
        builder.UseAdoNetReminderService(options =>
        {
            options.Invariant = invariant;
            options.ConnectionString = PsqlReminderConnectionString(context);
        });
        
        builder.AddAdoNetGrainStorage("Grains", options =>
        {
            options.Invariant = invariant;
            options.ConnectionString = PsqlGrainStorageConnectionString(context);
        });
    }
}