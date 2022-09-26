namespace Rez.Task;

/// <summary>
/// </summary>
public class DonRac : IHostedService
{
    private Timer _timer = null!;

    /// <summary>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public System.Threading.Tasks.Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(_ =>
        {
            Console.WriteLine("QUET RAC....");
            GC.Collect();
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        return System.Threading.Tasks.Task.CompletedTask;
    }

    /// <summary>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public System.Threading.Tasks.Task StopAsync(CancellationToken cancellationToken)
    {
        return System.Threading.Tasks.Task.CompletedTask;
    }
}