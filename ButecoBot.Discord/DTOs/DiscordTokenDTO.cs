using ButecoBot.Discord.Domain;

namespace ButecoBot.Discord.DTOs;

public record DiscordTokenDTO()
{
    public string Token { get; init; }
    public DiscordTokenType TokenType { get; init; } = DiscordTokenType.BOT;
};