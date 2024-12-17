
namespace MediaLibrary.Client.Api
{
    public interface IMediaLibraryApiWrapper
    {
        Task DeleteAlbum(int id);
        Task DeleteArtist(int id);
        Task DeleteGenre(int id);
        Task DeleteParticipationArtistGenre(int genreId, int artistId, string id);
        Task DeleteTrack(int id);
        Task<DtoAlbumDetails> GetAlbum(int id);
        Task<ICollection<DtoAlbumDetails>> GetAllAlbum();
        Task<ICollection<DtoArtistDetails>> GetAllArtist();
        Task<ICollection<DtoGenreDetails>> GetAllGenre();
        Task<ICollection<DtoParticipationDetails>> GetAllParticipationArtistGenre();
        Task<ICollection<DtoTrackDetails>> GetAllTrack();
        Task<DtoArtistDetails> GetArtist(int id);
        Task<DtoGenreDetails> GetGenre(int id);
        Task<DtoParticipationDetails> GetParticipationArtistGenre(int? genreId, int? artistId, string id);
        Task<DtoTrackDetails> GetTrack(int id);
        Task PosArtist(DtoArtistCreateUpdate artist);
        Task PostAlbum(DtoAlbumCreateUpdate album);
        Task PostGenre(DtoGenreCreateUpdate genre);
        Task PostParticipationArtistGenre(DtoParticipationDetails participation);
        Task PostTrack(DtoTrackCreateUpdate track);
        Task PutAlbum(int id, DtoAlbumCreateUpdate album);
        Task PutArtist(int id, DtoArtistCreateUpdate artist);
        Task PutGenre(int id, DtoGenreCreateUpdate genre);
        Task PutParticipationArtistGenre(int genreId, int artistId, string id, DtoParticipationDetails participation);
        Task PutTrack(int id, DtoTrackCreateUpdate track);
    }
}