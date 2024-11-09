namespace ButecoBot.Web;

public class WebWorker: IHostedService
{
    private WebApplication _application;
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        _application = app;
        app.Run();
        
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _application.StopAsync();
        await _application.DisposeAsync();
    }
}