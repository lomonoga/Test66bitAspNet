using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test66bit.BLL.DTO;
using Test66bit.BLL.Interfaces;
using Test66bit.DAL.EF;
using Test66bit.DAL.Entities;

namespace Test66bit.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class HomePageController : Controller
{
    private IFootballService _footballService;
    private IMapper _mapper;

    public HomePageController(IFootballService footballService, IMapper mapper)
    {
        _footballService = footballService;
        _mapper = mapper;
    }

    public ActionResult AddPlayer()
    {
        return View();
    }

    public ActionResult AllPlayers()
    {
        var playersDTO = _footballService.GetAllPlayers();
        var players = _mapper.Map<List<PlayerDTO>>(playersDTO);
        return View(players);
    }
    
    [HttpGet(Name = "Het")]
    public int Get()
    {
        _footballService.AddPlayer(
            new PlayerDTO
            {
                Forename = "ALL",
                Surname = "All",
                NewTeamName = "Alllllll"
            }
        );
        return 1;
    }
}