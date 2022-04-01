using AutoMapper;
using MediatR;
using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;

namespace SpaceBank.Microservices.Media.Application.Features.Video.Queries.GetVideoList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, IEnumerable<VideoViewModel>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VideoViewModel>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideoByUsername(request.UserName);
            return _mapper.Map<IEnumerable<VideoViewModel>>(videoList);
        }
    }
}
