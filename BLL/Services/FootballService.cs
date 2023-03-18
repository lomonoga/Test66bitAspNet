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
        var player = _mapper.Map<Player>(playerDTO);
        // var teamName = db.TeamNames.GetFirstOfDefault(player.TeamName);
        // if (teamName == null)
        // {
        //     db.TeamNames.Create(
        //         new TeamName{Name = playerDTO.TeamName});
        // }
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
    public void UpdatePlayer(PlayerDTO playerDTO)
    {
        if (db.Players.GetById(playerDTO.Id) == null) return;
        var teamName = new TeamName {Name = playerDTO._TeamName};
        if (db.TeamNames.GetFirstOfDefault(teamName) == null)
            db.TeamNames.Create(teamName);
        
        teamName = db.TeamNames.GetFirstOfDefault(teamName);
        playerDTO.TeamNameId = teamName.Id;
        var player = _mapper.Map<Player>(playerDTO);
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

    // private bool IsNameTeamInstance(TeamName teamName)
    // {
    //     return db.TeamNames.GetFirstOfDefault(teamName) != null;
    // }

    public void Dispose()
    {
        db.Dispose();
    }
}