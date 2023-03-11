using Microsoft.EntityFrameworkCore;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Entities.EnumEntities;

namespace Test66bit.DAL.EF;

public class PlayerContext : DbContext
{
    private readonly DalSetting _dalSetting;

    public DbSet<FootballPlayersEntity> Players { get; set; }
    public DbSet<TeamNameEntity> Team { get; set; }

    public PlayerContext(DalSetting dalSetting)
    {
        _dalSetting = dalSetting;
        // Check Database for existence 

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_dalSetting.ConnectionString);

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Country>()
            .HasPostgresEnum<Sex>();
    }
    
}