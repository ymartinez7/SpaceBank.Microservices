using MediatR;

namespace SpaceBank.Microservices.Media.Application.Features.Video.Queries.GetVideoList
{
    public class GetVideosListQuery : IRequest<IEnumerable<VideoViewModel>>
    {
        public string? UserName { get; set; }

        public GetVideosListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
