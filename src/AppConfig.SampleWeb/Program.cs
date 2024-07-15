var builder = WebApplication.CreateBuilder(args);

var appConfigConnectionString = builder.Configuration.GetConnectionString("AppConfig");

builder.Configuration.AddAzureAppConfiguration(appConfigConnectionString);

var app = builder.Build();

app.MapGet("/", (IConfiguration configuration) =>
{
    var value = configuration.GetValue<string>("Foo");
    return value;
});

app.Run();