using AutoMapper;
using MediaLibrary.Classes;
using WebApi.Dto;

namespace WebApi;

/// <summary>
/// Профиль маппинга для AutoMapper, используемый для настройки преобразований между объектами
/// </summary>
public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Album, DtoAlbumCreateUpdate>().ReverseMap();
        CreateMap<DtoAlbumDetails, Album>().ReverseMap();
        CreateMap<Artist, DtoArtistCreateUpdate>().ReverseMap();
        CreateMap<DtoArtistDetails, Artist>().ReverseMap();
        CreateMap<Genre, DtoGenreCreateUpdate>().ReverseMap();
        CreateMap<DtoGenreDetails, Genre>().ReverseMap();
        CreateMap<Track, DtoTrackCreateUpdate>().ReverseMap();
        CreateMap<DtoTrackDetails, Track>().ReverseMap();
        CreateMap<DtoParticipationDetails, ParticipationArtistGenre>().ReverseMap();
    }
}