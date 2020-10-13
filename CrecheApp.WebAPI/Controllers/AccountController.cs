using AutoMapper;
using CrecheApp.Domain.Dto;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrecheApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public AccountController(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult Create(AccountDto account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Account>(account);
            _accountRepository.Add(model);
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

            var model = _mapper.Map<Account>(account);
            _accountRepository.Update(model);
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
            var model = _accountRepository.GetByGlobalId(globalId.Value);
            if (model == null)
            {
                return NotFound($"Account: {globalId} not found.");
            }
            _accountRepository.Delete(model);
            return Ok();
        }
    }
}
