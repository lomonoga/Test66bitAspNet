using AutoMapper;
using Test66bit.BLL.DTO;
using Test66bit.DAL.Entities;
using Test66bit.WEB.Models;

namespace Test66bit.BLL.MappingProfiles;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<Player, PlayerDTO>();
        CreateMap<PlayerDTO, Player>();
        CreateMap<TeamName, TeamNameDTO>();
        CreateMap<TeamNameDTO, TeamName>();
        CreateMap<IEnumerable<TeamName>, List<TeamNameDTO>>();
        CreateMap<List<TeamNameDTO>, IEnumerable<TeamName>>();
        CreateMap<IEnumerable<Player>, List<PlayerDTO>>();
        CreateMap<List<TeamNameDTO>, IEnumerable<TeamName>>();
        CreateMap<IEnumerable<PlayerViewModel>, List<PlayerDTO>>();
        CreateMap<List<PlayerDTO>, IEnumerable<PlayerViewModel>>();
        CreateMap<IEnumerable<TeamNameViewModel>, List<TeamNameDTO>>();
        CreateMap<List<TeamNameDTO>, IEnumerable<TeamNameViewModel>>();
    }
}