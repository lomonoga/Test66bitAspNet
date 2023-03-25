using AutoMapper;
using Test66bit.BLL.DTO;
using Test66bit.BLL.Interfaces;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Interfaces;

namespace Test66bit.BLL.Services;

public class FootballService : IFootballService
{
    private IUnitOfWork db;
    private readonly IMapper _mapper;

    public FootballService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.db = unitOfWork;
        this._mapper = mapper;

    }
    
    /// <summary>
    /// Allows you to add one player to the DB PlayerContext
    /// </summary>
    /// <param name="playerDTO">Light Player Model</param>
    public void AddPlayer(PlayerDTO playerDTO)
    {
        playerDTO.TeamNameId = GetOrCreateTeamAndGetIDTeamName(playerDTO);
        var player = _mapper.Map<Player>(playerDTO);

        db.Players.Create(player);
        db.Save();
    }

    /// <returns>All players from DB PlayerContext</returns>
    public IEnumerable<PlayerDTO> GetAllPlayers()
    {
        return _mapper.Map<IEnumerable<PlayerDTO>>(db.Players.GetAll());
    }

    /// <summary>
    /// Allows update one player data
    /// </summary>
    /// <param name="playerDTO">Player model to change in DB</param>
    public void UpdatePlayerWithTeamName(PlayerDTO playerDTO)
    {
        var player = db.Players.GetById(playerDTO.Id);
        if (player == null) return;
        
        playerDTO.TeamNameId = GetOrCreateTeamAndGetIDTeamName(playerDTO);
        player.Birthday = playerDTO.Birthday;
        player.Country = playerDTO.Country;
        player.Forename = playerDTO.Forename;
        player.Sex = playerDTO.Sex;
        player.Surname = playerDTO.Surname;

        db.Players.Update(player);
        db.Save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public IEnumerable<TeamNameDTO> GetAllNameTeams()
    {
        return _mapper.Map<IEnumerable<TeamNameDTO>>(db.TeamNames.GetAll());
    }

    public void AddTeam(string name)
    {
        var teamName = new TeamName {Name = name};
        
        db.TeamNames.Create(teamName);
        db.Save();
    }

    private int GetOrCreateTeamAndGetIDTeamName(PlayerDTO playerDTO)
    {
        var teamName = new TeamName {Name = playerDTO.NewTeamName};
        if (db.TeamNames.GetFirstOfDefault(teamName) == null)
            db.TeamNames.Create(teamName);
        teamName = db.TeamNames.GetFirstOfDefault(teamName);
        return teamName.Id;
    }


    public void Dispose()
    {
        db.Dispose();
    }
}