namespace WorkerServiceDemo
{
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        Log.Info($"��̨�����ʼ����");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Log.Info($"��̨��������: {DateTime.Now}");
                    await Task.Delay(1000, stoppingToken);
                }
            }, stoppingToken);
        await Task.CompletedTask;
    }
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        base.StopAsync(cancellationToken);
        Log.Info("ϵͳ����ֹͣ��");
        return Task.CompletedTask;
    }
}
}