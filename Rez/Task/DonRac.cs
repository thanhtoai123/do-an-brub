using Microsoft.AspNetCore.Mvc;

namespace Rez.Task;

/// <summary>
/// </summary>
public class DonRac : IHostedService
{
    private Timer _timer = null!;
    private ILogger _logger;
    public DonRac(ILogger<DonRac> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public System.Threading.Tasks.Task StartAsync(CancellationToken cancellationToken = default)
    {
        _timer = new Timer(_ =>
        {
            _logger.LogInformation("QUÉT RÁC....");
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