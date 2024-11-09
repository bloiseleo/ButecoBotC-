using ButecoBot.Discord.Adapters;
using ButecoBot.Discord.DTOs;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ButecoBot.Discord;

public class DiscordWorker: IHostedService
{
    private readonly DiscordSocketClient _client;
    private readonly DiscordTokenDTO _token;
    private readonly ILogger<DiscordWorker> _logger;

    public DiscordWorker(IOptions<DiscordTokenDTO> discordTokenDto, ILogger<DiscordWorker> logger)
    {
        ArgumentNullException.ThrowIfNull(discordTokenDto);
        _client = new DiscordSocketClient();
        _client.Log += Log;
        _token = discordTokenDto.Value;
        _logger = logger;
    }

    private Task Log(LogMessage logMessage)
    {
        _logger.LogInformation(logMessage.Message);
        return Task.CompletedTask;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var adapter = new DiscordTokenTypeTokenTypeAdapter();
        await _client.LoginAsync(adapter.Adapt(_token.TokenType), _token.Token);
        await _client.StartAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _client.LogoutAsync();
        await _client.StopAsync();
    }
}