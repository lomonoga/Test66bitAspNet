using Test66bit.DAL.Entities;

namespace Test66bit.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Player> Players { get; }
    IRepository<TeamName> TeamNames { get; }
    void Save();
}