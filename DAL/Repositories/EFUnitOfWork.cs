using Test66bit.DAL.EF;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Interfaces;

namespace Test66bit.DAL.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private FootballContext db;

    public EFUnitOfWork(
        FootballContext footballContext,
        IRepository<Player> playerRepository,
        IRepository<TeamName> teamNameRepository
            )
    {
        this.db = footballContext;
        this.Players = playerRepository;
        this.TeamNames = teamNameRepository;
    }

    public IRepository<Player> Players { get; }

    public IRepository<TeamName> TeamNames { get; }

    public void Save()
    {
        db.SaveChanges();
    }
    
    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) 
            db.Dispose();

        _disposed = true;
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}