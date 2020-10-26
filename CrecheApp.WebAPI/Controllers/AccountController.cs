using CrecheApp.Domain.Model;
using CrecheApp.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrecheApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController( IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Create(AccountModel account)
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
        public IActionResult Update(Guid? globalId, [FromBody]AccountModel account)
        {
            if (globalId == null)
            {
                return BadRequest("GlobalId is empty");
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
                return BadRequest("GlobalId is empty");
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
                return BadRequest("GlobalId is empty");
            }
            return Ok(_accountService.GetByGlobalId(globalId.Value));
        }
    }
}
