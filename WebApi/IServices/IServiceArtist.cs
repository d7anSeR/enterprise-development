using WebApi.Dto;
using MediaLibrary.Classes;

public interface IServiceArtist
{
    public IEnumerable<Artist> GetEnum();
    public Artist? Get(int id);
    public bool Post(DtoArtist dtoArtist);
    public bool Put(int id, DtoArtist dtoArtist);
    public bool Delete(int id);
    public bool ArtistExists(int id);
}