using Microsoft.EntityFrameworkCore;
using Test66bit.DAL;
using Test66bit.DAL.EF;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Entities.EnumEntities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var setting = new DalSetting(builder.Configuration);

builder.Services.AddSingleton(_ => setting);
builder.Services.AddDbContext<PlayerContext>(options => options.UseNpgsql(setting.ConnectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


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