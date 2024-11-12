namespace MediaLibrary.Classes.IRepositories;

public interface IRepositoryParticipationArtistGenre
{
    public IEnumerable<ParticipationArtistGenre> GetEnum();
    public ParticipationArtistGenre? Get(int idGenre, int idArtist);
    public bool Post(ParticipationArtistGenre participation);
    public bool Delete(int idGenre, int idArtist);
    public bool Put(int idGenre, int idArtist, ParticipationArtistGenre track);
}