using Microsoft.Extensions.Configuration;
using HostBuilderContext = Microsoft.Extensions.Hosting.HostBuilderContext;

namespace SingleHostOrleans7;

public static class HostExtensions
{
    
    private static string PsqlGrainStorageConnectionString(HostBuilderContext context) => context.Configuration.GetConnectionString("OrleansState");
    private static string PsqlReminderConnectionString(HostBuilderContext context) => context.Configuration.GetConnectionString("OrleansReminder");
    const string Invariant = "Npgsql";
    public static void AddDevelopmentWithPsql(this ISiloBuilder builder, HostBuilderContext context)
    {
        builder.UseAdoNetReminderService(options =>
        {
            options.Invariant = Invariant;
            options.ConnectionString = PsqlReminderConnectionString(context);
        });
        
        builder.AddAdoNetGrainStorage("Grains", options =>
        {
            options.Invariant = Invariant;
            options.ConnectionString = PsqlGrainStorageConnectionString(context);
        });
    }
}