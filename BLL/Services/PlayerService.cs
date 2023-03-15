using AutoMapper;
using Test66bit.BLL.DTO;
using Test66bit.BLL.Interfaces;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Interfaces;

namespace Test66bit.BLL.Services;

public class PlayerService : IPlayerService
{
    private IUnitOfWork db;

    public PlayerService(IUnitOfWork unitOfWork)
    {
        this.db = unitOfWork;
    }
    
    /// <summary>
    /// Allows you to add one player to the DB PlayerContext
    /// </summary>
    /// <param name="playerDTO">Light Player Model</param>
    public void AddPlayer(PlayerDTO playerDTO)
    {
        // var teamName = db.TeamNames.GetById(playerDTO.TeamId);
        // var newTeam = ...
        Player player = new ()
        {
            Forename = playerDTO.Forename,
            Surname = playerDTO.Surname,
            Sex = playerDTO.Sex,
            Birthday = playerDTO.Birthday,
            TeamName = playerDTO.TeamName,
            Country = playerDTO.Country,
        };
        db.Players.Create(player);
        db.Save();
    }

    /// <returns>All players from DB PlayerContext</returns>
    public IEnumerable<PlayerDTO> GetAllPlayers()
    {
        var mapper = new MapperConfiguration(cfg 
            => cfg.CreateMap<Player, PlayerDTO>()).CreateMapper();   
        return mapper.Map<IEnumerable<Player>, List<PlayerDTO>>(db.Players.GetAll());
    }

    /// <summary>
    /// Allows update one player data
    /// </summary>
    /// <param name="id">Id of the player</param>
    public void UpdatePlayer(int playerID)
    {
        var player = db.Players
            .GetById(playerID);
        // player = new MapperConfiguration(cfg 
        //     => cfg.CreateMap<PlayerDTO, Player>()).CreateMapper()
        //     .Map<PlayerDTO, Player>(playerDTO);
        db.Players.Update(player);
        db.Save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public IEnumerable<TeamDTO> GetAllTeams()
    {
        throw new Exception();
    }

    public void Dispose()
    {
        db.Dispose();
    }
}