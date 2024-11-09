using ButecoBot.Discord;
using ButecoBot.Discord.Domain;
using ButecoBot.Discord.DTOs;
using ButecoBot.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ButecoBot;

class Program
{
    public static void Main(string[] args)
    {
        #if DEBUG
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Development");
        #endif

        var builder = Host.CreateApplicationBuilder(args);
        builder.Configuration
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
        builder.Services.Configure<DiscordTokenDTO>(builder.Configuration.GetSection("ButecoBot.Discord"));
        builder.Services.AddHostedService<DiscordWorker>();
        builder.Services.AddHostedService<WebWorker>();
        var app = builder.Build();
        app.Run();
    }
}