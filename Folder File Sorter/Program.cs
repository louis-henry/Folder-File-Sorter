// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

using Folder_File_Sorter.Controllers;
using Folder_File_Sorter.Interfaces;
using Folder_File_Sorter.Services;
using Folder_File_Sorter.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net;

// Startup
var host = AppStartup();

// Controller
var controller = ActivatorUtilities.CreateInstance<AppController>(host.Services, host);
if (await controller.RunApp())
{
    Log.Logger.Information("Application ran successfully");
    Environment.ExitCode = 0;
}
else
{
    Environment.ExitCode = -1;
}
Log.Logger.Information("Exiting Application...");

/// <summary>
/// Startup
/// </summary>
/// <returns></returns>
static IHost AppStartup()
{
    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
    var builder = new ConfigurationBuilder();
    BuildConfig(builder);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Build())
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(builder.Build().GetValue<string>("LogPathToWrite"), rollingInterval: RollingInterval.Day)
        .CreateLogger();

    Log.Logger.Information("Application Starting");
    var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        // Bind the appsettings to various classes
        services.Configure<AppSettings>(options => builder.Build().GetSection(AppSettings.AppSettingsOptions).Bind(options));
        services.Configure<ExtensionsVM>(options => builder.Build().GetSection(ExtensionsVM.ExtensionOptions).Bind(options));

        // Define the following as singletons
        services.AddSingleton<IDocumentService, DocumentService>();
    })
    .UseSerilog()
    .Build();

    return host;
}

/// <summary>
/// Configuration
/// </summary>
/// <param name="builder"></param>
static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
}