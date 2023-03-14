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
    private IPlayerService _playerService;

    public HomePageController(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    [HttpGet(Name = "Het")]
    public IEnumerable<PlayerDTO> Get()
    {
        return _playerService.GetAllPlayers();
    }
}