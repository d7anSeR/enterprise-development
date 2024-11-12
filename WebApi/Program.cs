using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using MediaLibrary.Classes.Repositories;
using WebApi;
using WebApi.IServices;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepositoryAlbum, RepositoryAlbum>();
builder.Services.AddSingleton<IServiceAlbum, ServiceAlbum>();
builder.Services.AddSingleton<IRepositoryArtist, RepositoryArtist>();
builder.Services.AddSingleton<IServiceArtist, ServiceArtist>();
builder.Services.AddSingleton<IRepositoryGenre, RepositoryGenre>();
builder.Services.AddSingleton<IServiceGenre, ServiceGenre>();
builder.Services.AddSingleton<IRepositoryTrack, RepositoryTrack>();
builder.Services.AddSingleton<IServiceTrack, ServiceTrack>();
builder.Services.AddSingleton<IRepositoryParticipationArtistGenre, RepositoryParticipationArtistGenre>();
builder.Services.AddSingleton<IServiceParticipationArtistGenre, ServiceParticipationArtistGenre>();
builder.Services.AddAutoMapper(typeof(Mapping));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();