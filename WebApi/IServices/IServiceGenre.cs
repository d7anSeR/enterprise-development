using WebApi.Dto;
using MediaLibrary.Classes;

public interface IServiceGenre
{
    public IEnumerable<Genre> GetEnum();
    public Genre? Get(int id);
    public bool Post(DtoGenre dtoGenre);
    public bool Put(int id, DtoGenre dtoGenre);
    public bool Delete(int id);
    public bool GenreExists(int id);
}