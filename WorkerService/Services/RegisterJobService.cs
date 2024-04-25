using Hangfire;

namespace WorkerService.Services;

public class RegisterJobService : BackgroundService
{
    private readonly ILogger<RegisterJobService> _logger;

    public RegisterJobService(IServiceProvider services, ILogger<RegisterJobService> logger)
    {
        Services = services;
        _logger = logger;
    }

    public IServiceProvider Services { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Consume Scoped Service Hosted Service running.");

        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Consume Scoped Service Hosted Service is working.");

        using (var scope = Services.CreateScope())
        {
            var jobService = scope.ServiceProvider.GetRequiredService<TestService>();
            RecurringJob.AddOrUpdate("DoWork", () => jobService.DoWork(), "* * * * *");
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
