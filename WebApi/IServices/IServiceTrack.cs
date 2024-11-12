using WebApi.Dto;
using MediaLibrary.Classes;

public interface IServiceTrack
{
    public IEnumerable<Track> GetEnum();
    public Track? Get(int id);
    public bool Post(DtoTrack dtoTrack);
    public bool Put(int id, DtoTrack dtoTrack);
    public bool Delete(int id);
}