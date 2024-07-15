using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var appConfigConnectionString = builder.Configuration.GetConnectionString("AppConfig");

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options
        .Connect(appConfigConnectionString)
        .ConfigureKeyVault(kv =>
        {
            kv.SetCredential(new DefaultAzureCredential());
        })
    ;
});

var app = builder.Build();

app.MapGet("/", (IConfiguration configuration) =>
{
    var value = configuration.GetValue<string>("Foo");
    return value;
});

app.Run();