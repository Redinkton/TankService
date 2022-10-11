using MyTank.Data;

namespace MyTank.Services
{
    public class DefaultScopedProcessingService : IScopedProcessingService
    {
        private readonly TankContext _context;

        public DefaultScopedProcessingService(TankContext context)
        {
            _context = context;
        }
        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var allList = _context.Tanks.ToList();
                Random rnd = new();
                foreach (var item in allList)
                {
                    item.CurrentVolume = rnd.Next(item.MinVolume, item.MaxVolume);
                    _context.SaveChanges();
                }
                await Task.Delay(10_000, stoppingToken);
            }
        }
    }
}
