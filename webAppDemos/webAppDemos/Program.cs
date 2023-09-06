using Microsoft.EntityFrameworkCore;
using webAppDemos.Business.Abstracts;
using webAppDemos.Business.Concretes;
using webAppDemos.Repositories.Abstracts;
using webAppDemos.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<ApplicationContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("webapitest")));

// Add services to the container.

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<DbContext, ApplicationContext>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
