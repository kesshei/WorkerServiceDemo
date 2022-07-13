namespace WorkerServiceDemo
{
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        Log.Info($"后台服务初始化！");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Log.Info($"后台服务运行: {DateTime.Now}");
                    await Task.Delay(1000, stoppingToken);
                }
            }, stoppingToken);
        await Task.CompletedTask;
    }
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        base.StopAsync(cancellationToken);
        Log.Info("系统服务停止！");
        return Task.CompletedTask;
    }
}
}