using MyTank.Models;
using MyTank.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyTank.Services;

public class TankService
{
    private readonly TankContext _context;

    public TankService(TankContext context)
    {
        _context = context;
    }

    public Task<List<Tank>> GetAll()
    {
        return _context.Tanks
            .AsNoTracking()
            .ToListAsync();
    }

    public Tank? GetById(int id)
    {
        return _context.Tanks
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Tank Create(Tank newTank)
    {
        _context.Tanks.Add(newTank);
        _context.SaveChanges();

        return newTank;
    }

    public void Update(int TankId, int currentVolume)
    {
        var tankToUpdate = _context.Tanks.Find(TankId);

        if (tankToUpdate is null)
        {
            throw new InvalidOperationException("Not exist");
        }
        tankToUpdate.CurrentVolume = currentVolume;
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var tankToDelete = _context.Tanks.Find(id);
        if (tankToDelete is not null)
        {
            _context.Tanks.Remove(tankToDelete);
            _context.SaveChanges();
        }
    }
}