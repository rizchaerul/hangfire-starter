using Hangfire;

namespace WorkerService.Services;

public class TestService
{
    [AutomaticRetry(Attempts = 0)]
    public async Task DoWork()
    {
        await Task.CompletedTask;
        throw new Exception("AAAAAAAAAA");
        Console.WriteLine("Hello, World");
    }
}
