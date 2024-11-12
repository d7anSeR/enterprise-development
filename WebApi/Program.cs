using MediaLibrary.Classes.IRepositories;
using MediaLibrary.Classes.Repositories;
using WebApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    services.AddSingleton<IRepositoryAlbum, RepositoryAlbum>();
    services.AddSingleton<IServiceAlbum, ServiceAlbum>();
    services.AddSingleton<IRepositoryArtist, RepositoryArtist>();
    services.AddSingleton<IServiceArtist, ServiceArtist>();
    services.AddSingleton<IRepositoryGenre, RepositoryGenre>();
    services.AddSingleton<IServiceGenre, ServiceGenre>();
    services.AddSingleton<IRepositoryTrack, RepositoryTrack>();
    services.AddSingleton<IServiceTrack, ServiceTrack>();
    services.AddSingleton<IRepositoryParticipationArtistGenre, RepositoryParticipationArtistGenre>();
    services.AddSingleton<IServiceParticipationArtistGenre, ServiceParticipationArtistGenre>();

    services.AddAutoMapper(typeof(Mapping));
}