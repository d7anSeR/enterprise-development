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
        CreateMap<Album, DtoAlbum>().ReverseMap();
        CreateMap<Artist, DtoArtist>().ReverseMap();
        CreateMap<Genre, DtoGenre>().ReverseMap();
        CreateMap<Track, DtoTrack>().ReverseMap();
    }
}