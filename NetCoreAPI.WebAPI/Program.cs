using Microsoft.EntityFrameworkCore;
using NetCoreAPI.DataAccess;
using NetCoreAPI.WebAPI.Extensions;
using NetCoreAPI.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EcommerceDbContext>(
    options => 
    options.UseSqlServer(
        builder.Configuration
        .GetSection("EcommerceConnection:AppDbConnection").Value));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

///check if the request header has x-api-key


app.UseMyMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
