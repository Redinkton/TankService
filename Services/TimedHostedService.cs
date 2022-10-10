using MyTank.Data;

namespace MyTank.Services
{
    public class TimedHostedService : IHostedService
    {
        private readonly TankContext _context;

        public TimedHostedService(TankContext context)
        {
            _context = context;
        }

        private Timer? _timer = null;

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var allList = _context.Tanks.ToList();
            Random rnd = new();
            foreach (var item in allList)
            {
                item.CurrentVolume = rnd.Next(item.MinVolume, item.MaxVolume);
                _context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}

