namespace MediaLibrary.Client.Api;

public class MediaLibraryApiWrapper(IConfiguration configuration) : IMediaLibraryApiWrapper
{
    public readonly MediaLibraryApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    //Работа с сущностью "альбом"
    public async Task<ICollection<DtoAlbumDetails>> GetAllAlbum() => await _client.ControllerAlbumAllAsync();
    public async Task PostAlbum(DtoAlbumCreateUpdate album) => await _client.ControllerAlbumPOSTAsync(album);
    public async Task<DtoAlbumDetails> GetAlbum(int id) => await _client.ControllerAlbumGETAsync(id);
    public async Task PutAlbum(int id, DtoAlbumCreateUpdate album) => await _client.ControllerAlbumPUTAsync(id, album);
    public async Task DeleteAlbum(int id) => await _client.ControllerAlbumDELETEAsync(id);
    //Работа с сущностью "артиста"
    public async Task<ICollection<DtoArtistDetails>> GetAllArtist() => await _client.ControllerArtistAllAsync();
    public async Task PostArtist(DtoArtistCreateUpdate artist) => await _client.ControllerArtistPOSTAsync(artist);
    public async Task<DtoArtistDetails> GetArtist(int id) => await _client.ControllerArtistGETAsync(id);
    public async Task PutArtist(int id, DtoArtistCreateUpdate artist) => await _client.ControllerArtistPUTAsync(id, artist);
    public async Task DeleteArtist(int id) => await _client.ControllerArtistDELETEAsync(id);
    //Работа с сущностью "жанр"
    public async Task<ICollection<DtoGenreDetails>> GetAllGenre() => await _client.ControllerGenreAllAsync();
    public async Task PostGenre(DtoGenreCreateUpdate genre) => await _client.ControllerGenrePOSTAsync(genre);
    public async Task<DtoGenreDetails> GetGenre(int id) => await _client.ControllerGenreGETAsync(id);
    public async Task PutGenre(int id, DtoGenreCreateUpdate genre) => await _client.ControllerGenrePUTAsync(id, genre);
    public async Task DeleteGenre(int id) => await _client.ControllerGenreDELETEAsync(id);
    //Работа с сущностью "связь артиста и жанра"
    public async Task<ICollection<DtoParticipationDetails>> GetAllParticipationArtistGenre() => await _client.ControllerParticipationArtistGenreAllAsync();
    public async Task PostParticipationArtistGenre(DtoParticipationDetails participation) => await _client.ControllerParticipationArtistGenrePOSTAsync(participation);
    public async Task<DtoParticipationDetails> GetParticipationArtistGenre(int? genreId, int? artistId, string id) => await _client.ControllerParticipationArtistGenreGETAsync(genreId, artistId, id);
    public async Task PutParticipationArtistGenre(int genreId, int artistId, string id, DtoParticipationDetails participation) => await _client.ControllerParticipationArtistGenrePUTAsync(genreId, artistId, id, participation);
    public async Task DeleteParticipationArtistGenre(int genreId, int artistId, string id) => await _client.ControllerParticipationArtistGenreDELETEAsync(genreId, artistId, id);
    //Работа с сущностью "музыкальный трек"
    public async Task<ICollection<DtoTrackDetails>> GetAllTrack() => await _client.ControllerTrackAllAsync();
    public async Task PostTrack(DtoTrackCreateUpdate track) => await _client.ControllerTrackPOSTAsync(track);
    public async Task<DtoTrackDetails> GetTrack(int id) => await _client.ControllerTrackGETAsync(id);
    public async Task PutTrack(int id, DtoTrackCreateUpdate track) => await _client.ControllerTrackPUTAsync(id, track);
    public async Task DeleteTrack(int id) => await _client.ControllerTrackDELETEAsync(id);
}