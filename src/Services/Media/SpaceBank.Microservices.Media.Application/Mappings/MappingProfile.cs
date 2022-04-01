using AutoMapper;
using SpaceBank.Microservices.Media.Application.Features.Streamers.Commands;
using SpaceBank.Microservices.Media.Application.Features.Video.Queries.GetVideoList;
using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideoViewModel>();
            CreateMap<CreateStreamerCommand, Streamer>();
        }
    }
}
