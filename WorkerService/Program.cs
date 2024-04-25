using Hangfire;
using WorkerService.Services;

var builder = WebApplication.CreateBuilder(args);

// Libs
builder.Services.AddHangfire(x => x.UseInMemoryStorage());
builder.Services.AddHangfireServer();

// Hosted services
builder.Services.AddHostedService<RegisterJobService>();

// Services
builder.Services.AddTransient<TestService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHangfireDashboard("/jobs");
}

app.Run();
