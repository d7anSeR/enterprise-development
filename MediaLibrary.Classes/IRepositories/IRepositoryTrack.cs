namespace MediaLibrary.Classes.IRepositories;

public interface IRepositoryTrack
{
    public IEnumerable<Track> GetEnum();
    public Track? Get(int id);
    public bool Post(Track track);
    public bool Delete(int id);
    public bool Put(int id, Track track);
}