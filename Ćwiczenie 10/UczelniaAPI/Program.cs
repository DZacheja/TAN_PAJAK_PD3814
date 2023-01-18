using Microsoft.EntityFrameworkCore;
using UczelniaAPI.Models;
using UczelniaAPI.Services;
using UczelniaAPI.Services.Interafces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDatabaseService, SqlServerService>();

builder.Services.AddDbContext<UczelniaContext>(opt =>
{
    opt.LogTo(Console.WriteLine)
    .UseSqlServer(builder.Configuration.GetConnectionString("UczelniaDB"));
});


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

app.Run();
