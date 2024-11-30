using WebApi;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Настройка сервисов
ConfigureServices(builder.Services);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version(8,0,40))));
var app = builder.Build();

// Конфигурация среды
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Использование HTTPS и маршрутизация контроллеров
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

/// <summary>
/// Метод для настройки всех сервисов
/// </summary>
/// <param name="services"></param>
void ConfigureServices(IServiceCollection services)
{
    // Добавление поддержки контроллеров
    services.AddControllers();

    // Настройка Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    // Регистрация репозиториев
    services.AddSingleton<IRepositoryAlbum, RepositoryAlbum>();
    services.AddSingleton<IRepositoryArtist, RepositoryArtist>();
    services.AddSingleton<IRepositoryGenre, RepositoryGenre>();
    services.AddSingleton<IRepositoryTrack, RepositoryTrack>();
    services.AddSingleton<IRepositoryParticipationArtistGenre, RepositoryParticipationArtistGenre>();

    // Регистрация сервисов
    services.AddSingleton<IServiceAlbum, ServiceAlbum>();
    services.AddSingleton<IServiceArtist, ServiceArtist>();
    services.AddSingleton<IServiceGenre, ServiceGenre>();
    services.AddSingleton<IServiceTrack, ServiceTrack>();
    services.AddSingleton<IServiceParticipationArtistGenre, ServiceParticipationArtistGenre>();

    // Настройка AutoMapper
    services.AddAutoMapper(typeof(Mapping));
}