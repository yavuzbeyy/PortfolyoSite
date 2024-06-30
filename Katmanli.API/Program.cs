using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Interfaces.ServiceInterfaces;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess;
using Katmanli.DataAccess.Entities;
using Katmanli.DataAccess.Repository;
using Katmanli.DataAccess.UnitOfWork;
using Katmanli.Service.Interfaces;
using Katmanli.Service.Mapping;
using Katmanli.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CORS Hatasi çözümü
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper konfigürasyonu
builder.Services.AddAutoMapper(typeof(MapProfile));



//Servis Kayýtlarý
//builder.Services.AddScoped<IGenericRepository<User>,GenericRepository<User>>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITokenCreator, TokenCreator>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAboutMeService, AboutMeService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//DbContext Ekleme
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use the CORS policy
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
