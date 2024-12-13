using AutoMapper;
using WebApi;
using System.Reflection;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using MediaLibrary.Classes.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// ����������� ������� ��� DbContext
builder.Services.AddSingleton<IMediaLibraryDbContextFactory, MediaLibraryDbContextFactory>();

// ��������� ��������� ���� ������ � �������������� �������
builder.Services.AddScoped<MediaLibraryDbContext>(provider =>
{
    var factory = provider.GetRequiredService<IMediaLibraryDbContextFactory>();
    return factory.CreateDbContext();
});

// ��������� ��������
ConfigureServices(builder.Services);

var app = builder.Build();

// ������������ �����
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ������������� HTTPS � ������������� ������������
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

/// <summary>
/// ����� ��� ��������� ���� ��������
/// </summary>
/// <param name="services"></param>
void ConfigureServices(IServiceCollection services)
{
    // ���������� ��������� ������������
    services.AddControllers();

    // ��������� Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    // ����������� ������������
    services.AddSingleton<IRepositoryAlbum, RepositoryAlbum>();
    services.AddSingleton<IRepositoryArtist, RepositoryArtist>();
    services.AddSingleton<IRepositoryGenre, RepositoryGenre>();
    services.AddSingleton<IRepositoryTrack, RepositoryTrack>();
    services.AddSingleton<IRepositoryParticipationArtistGenre, RepositoryParticipationArtistGenre>();

    // ����������� ��������
    services.AddSingleton<IServiceAlbum, AlbumService>();
    services.AddSingleton<IServiceArtist, ArtistService>();
    services.AddSingleton<IServiceGenre, GenreService>();
    services.AddSingleton<IServiceTrack, TrackService>();
    services.AddSingleton<IServiceParticipationArtistGenre, ParticipationArtistGenreService>();

    // ��������� AutoMapper
    var mapperConfig = new MapperConfiguration(config => config.AddProfile(new Mapping()));
    IMapper? mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);
}