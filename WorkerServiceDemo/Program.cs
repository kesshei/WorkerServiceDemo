namespace WorkerServiceDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            IHost host = Host.CreateDefaultBuilder(args)
            .UseSystemd()//新增的 .UseSystemd()服务
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
            })
            .Build();

            host.Run();
        }
    }
}