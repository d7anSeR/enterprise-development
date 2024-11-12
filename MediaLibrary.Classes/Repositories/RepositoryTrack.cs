using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

public class RepositoryTrack : IRepositoryTrack
{
    private readonly List<Track> tracks = [];
    private int trackId = 1;
    public IEnumerable<Track> GetEnum() => tracks;

    public Track? Get(int id) => tracks.Find(t => t.Id == id);

    public bool Delete(int id)
    {
        var track = Get(id);
        if (track != null)
        {
            tracks.Remove(track);
            return true;
        }
        return false;
    }

    public bool Post(Track track)
    {
        track.Id = trackId++;
        if (Get(track.Id) == null)
        {
            tracks.Add(track);
            return true;
        }
        return false;
    }

    public bool Put(int id, Track track)
    {
        var oldValue = Get(id);
        if (oldValue == null)
            return false;
        oldValue.Id = track.Id;
        oldValue.TrackNum = track.TrackNum;
        oldValue.Title = track.Title;
        oldValue.Duration = track.Duration;
        oldValue.IdAlbum = track.IdAlbum;
        return true;
    }
}