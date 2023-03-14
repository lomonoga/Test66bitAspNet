using Microsoft.EntityFrameworkCore;
using Test66bit.DAL.EF;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Interfaces;

namespace Test66bit.DAL.Repositories;

public class TeamNameRepository : IRepository<TeamName>
{
    private FootballContext db;

    public TeamNameRepository(FootballContext footballContext)
    {
        this.db = footballContext;
    }
    
    public IEnumerable<TeamName> GetAll()
    {
        return db.TeamNames;
    }

    public TeamName GetById(int id)
    {
        return db.TeamNames.Find(id)!;
    }

    public void Create(TeamName teamName)
    {
        db.TeamNames.Add(teamName);
    }

    public void Update(TeamName teamName)
    {
        db.Entry(teamName).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var teamName = db.TeamNames.Find(id);
        if (teamName != null)
            db.TeamNames.Remove(teamName);
    }
}