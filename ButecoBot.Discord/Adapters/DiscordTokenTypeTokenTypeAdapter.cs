using ButecoBot.Discord.Domain;
using Discord;

namespace ButecoBot.Discord.Adapters;

public class DiscordTokenTypeTokenTypeAdapter
{
    public TokenType Adapt(DiscordTokenType tokenType)
    {
        switch (tokenType)
        {
            case DiscordTokenType.BOT:
                return TokenType.Bot;
            default:
                throw new ArgumentException("Invalid token type");
        }
    }
}