using AutoMapper;
using MediaLibrary.Classes;
using WebApi.Dto;

namespace WebApi;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Album, DtoAlbum>().ReverseMap();
    }
}
