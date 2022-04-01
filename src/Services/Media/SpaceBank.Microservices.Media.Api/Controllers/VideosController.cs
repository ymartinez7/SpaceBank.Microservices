using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpaceBank.Microservices.Media.Application.Features.Video.Queries.GetVideoList;
using System.Net;

namespace SpaceBank.Microservices.Media.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetVideoByUsername")]
        [ProducesResponseType(typeof(IEnumerable<VideoViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VideoViewModel>>> GetVideoByUsername(string username)
        {
            var query = new GetVideosListQuery(username);
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }
}
