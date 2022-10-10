using MyTank.Models;

namespace MyTank.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TankContext context)
        {

            if (context.Tanks.Any())
            {
                return;   // DB has been seeded
            }

            var tank = new Tank[]
            {
                new Tank
                {
                    Id = 1,
                    Name = "Резервуар №1",
                    MinVolume = 0,
                    MaxVolume = 100, 
                    CurrentVolume = 44, 
                    Description = "Резервуар для сырой нефти" 
                }
            };
            context.Tanks.AddRange(tank);
            context.SaveChanges();
        }
    }
}