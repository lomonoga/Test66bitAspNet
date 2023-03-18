using Microsoft.EntityFrameworkCore;
using Test66bit.DAL.EF;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Interfaces;

namespace Test66bit.DAL.Repositories;

public class PlayerRepository : IRepository<Player>
{
    private FootballContext db;

    public PlayerRepository(FootballContext footballContext)
    {
        this.db = footballContext;
    }
    
    public IEnumerable<Player> GetAll()
    {
        return db.Players.Include(o => o.TeamName);
    }

    public Player GetById(int? id)
    {
        return db.Players.Find(id)!;
    }

    public void Create(Player player)
    {
        db.Players.Add(player);
    }

    public void CreateRange(params Player[] players)
    {
        db.Players.AddRange(players);
    }

    public void Update(Player player)
    {
        db.Players.Update(player);
    }

    public void Delete(int id)
    {
        var player = db.Players.Find(id);
        if (player != null)
            db.Players.Remove(player);
    }

    public Player GetFirstOfDefault(Player player)
    {
        return db.Players.FirstOrDefault(player);
    }
}