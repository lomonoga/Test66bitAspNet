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

    public HomePageController(IFootballService footballService)
    {
        _footballService = footballService;
    }
    
    [HttpGet(Name = "Het")]
    public int Get()
    {
        _footballService.UpdatePlayer(
            new PlayerDTO
            {
                Forename = "tetUp1111111111111111111111",
                Surname = "tet1",
                _TeamName = "frfc31111111cwq"
            }
        );
        return 1;
    }
}