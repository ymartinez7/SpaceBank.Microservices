using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpaceBank.Microservices.Media.Application.Features.Streamers.Commands;
using SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.DeleteStreamer;
using SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.UpdateStreamer;
using System.Net;

namespace SpaceBank.Microservices.Media.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StreamersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StreamersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Post(CreateStreamerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put (UpdateStreamerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteStreamerCommand
            {
                Id = id
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
