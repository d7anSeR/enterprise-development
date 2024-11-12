using AutoMapper;
using MediaLibrary.Classes;
using WebApi.Dto;

namespace WebApi;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Album, DtoAlbum>().ReverseMap();
        CreateMap<Artist, DtoArtist>().ReverseMap();
        CreateMap<Genre, DtoGenre>().ReverseMap();
        CreateMap<Track, DtoTrack>().ReverseMap();
        CreateMap<ParticipationArtistGenre, DtoParticipationArtistGenre>().ReverseMap();
    }
}