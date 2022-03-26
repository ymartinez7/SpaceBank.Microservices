using Microsoft.AspNetCore.Mvc;
using SpaceBank.Microservices.Transfer.Application.Interfaces;
using SpaceBank.Microservices.Transfer.Domain.Entities;

namespace SpaceBank.Microservices.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
