using AutoMapper;
using Test66bit.BLL.DTO;
using Test66bit.DAL.Entities;

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
    }
}