using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

public class RepositoryParticipationArtistGenre : IRepositoryParticipationArtistGenre { 
    private readonly List<ParticipationArtistGenre> participations = [];
    public IEnumerable<ParticipationArtistGenre> GetEnum() => participations;

    public ParticipationArtistGenre? Get(int idGenre, int idArtist) => participations.Find(t => t.IdGenre == idGenre && t.IdArtist == idArtist);

    public bool Delete(int idGenre, int idArtist)
    {
        var participation = Get(idGenre, idArtist);
        if (participation != null)
        {
            participations.Remove(participation);
            return true;
        }
        return false;
    }

    public bool Post(ParticipationArtistGenre participation)
    {
        if (Get(participation.IdGenre, participation.IdArtist) == null)
        {
            participations.Add(participation);
            return true;
        }
        return false;
    }

    public bool Put(int IdGenre, int IdArtist, ParticipationArtistGenre participation)
    {
        var oldValue = Get(IdGenre, IdArtist);
        if (oldValue == null)
            return false;
        oldValue.IdGenre = participation.IdGenre;
        oldValue.IdArtist = participation.IdArtist;
        return true;
    }
}