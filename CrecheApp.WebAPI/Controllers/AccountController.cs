using CrecheApp.Domain.Dto;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CrecheApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountService _accountService;
        public AccountController(IAccountRepository accountRepository, IAccountService accountService)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Create(AccountDto account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _accountService.Add(account);
            return Ok();
        }

        [HttpPut]
        [Route("{globalId:guid}")]
        public IActionResult Update(Guid? globalId, [FromBody]AccountDto account)
        {
            if (globalId == null)
            {
                return BadRequest("globalId");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _accountService.Update(account);
            return Ok();
        }

        [HttpDelete]
        [Route("{globalId:guid}")]
        public IActionResult Delete(Guid? globalId)
        {
            if (globalId == null)
            {
                return BadRequest("globalId empty");
            }
            _accountService.Delete(globalId.Value);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_accountService.GetAll());
        }

        [HttpGet]
        [Route("{globalId:guid}")]
        public IActionResult GetByGlobalId(Guid? globalId)
        {
            if (globalId == null)
            {
                return BadRequest("globalId empty");
            }
            return Ok(_accountService.GetByGlobalId(globalId.Value));
        }
    }
}
