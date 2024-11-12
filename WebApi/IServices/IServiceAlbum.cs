using WebApi.Dto;
using MediaLibrary.Classes;

public interface IServiceAlbum
{
    public IEnumerable<Album> GetEnum();
    public Album? Get(int id);
    public bool Post(DtoAlbum dtoAlbum);
    public bool Put(int id, DtoAlbum dtoAlbum);
    public bool Delete(int id);
    public bool AlbumExists(int id);
}