namespace Rez.Task
{
    public class DonRac : IHostedService
    {
        private Timer timer = null!;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public System.Threading.Tasks.Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new(o =>
            {
                Console.WriteLine("QUET RAC....");
                GC.Collect();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return System.Threading.Tasks.Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public System.Threading.Tasks.Task StopAsync(CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
