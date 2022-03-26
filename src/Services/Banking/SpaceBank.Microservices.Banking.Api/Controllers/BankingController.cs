using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceBank.Microservices.Banking.Application.Interfaces;
using SpaceBank.Microservices.Banking.Domain.Entities;

namespace SpaceBank.Microservices.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public ActionResult Post(AccountTransfer accountTranfer)
        {
            _accountService.Transfer(accountTranfer);
            return Ok(accountTranfer);
        }
    }
}
