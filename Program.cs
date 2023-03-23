using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test66bit.BLL.Interfaces;
using Test66bit.BLL.MappingProfiles;
using Test66bit.BLL.Services;
using Test66bit.DAL;
using Test66bit.DAL.EF;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Entities.EnumEntities;
using Test66bit.DAL.Interfaces;
using Test66bit.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Mapping

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

builder.Services.AddSingleton(_ => mapperConfig.CreateMapper());

//Services

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

var setting = new DalSetting(builder.Configuration);

//DAL
builder.Services.AddSingleton(_ => setting);
builder.Services.AddDbContext<FootballContext>(options => options.UseNpgsql(setting.ConnectionString));

builder.Services.AddScoped<IRepository<Player>, PlayerRepository>();
builder.Services.AddScoped<IRepository<TeamName>, TeamNameRepository>();

//BLL
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

//WEB
builder.Services.AddScoped<IFootballService, FootballService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// using (var db = new PlayerContext(setting))
// {
//     var player = new FootballPlayersEntity
//     {
//         Forename = "Bob",
//         Surname = "Popov",
//         Sex = Sex.Male,
//         Birthday = new DateTime(),
//         Country = Country.USA,
//         TeamName = new TeamNameEntity
//         {
//             Name = "Bool"
//         }
//     };
//     db.Players.AddRange(player);
//     db.SaveChanges();
// }

app.Run();