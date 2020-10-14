using CrecheApp.Domain.Dto;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
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
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult Create(AccountDto account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = ConvertToEntity(account);
            entity.GlobalId = Guid.NewGuid();
            entity.CreationUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            entity.CreationDate = DateTime.UtcNow;
            _accountRepository.Add(entity);
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

            var entity =ConvertToEntity(account);
            _accountRepository.Update(entity);
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var domain = _accountRepository.GetAll();
            if (domain == null)
            {
                return BadRequest();
            }
            domain.ToList().ForEach(account => ConvertToDomain(account));
            return Ok(domain);
        }

        private Account ConvertToEntity(AccountDto accountDto)
        {
            return new Account
            {
                Id = accountDto.Id,
                GlobalId = accountDto.GlobalId,
                Name = accountDto.Name,
                CreationUser = accountDto.CreationUser,
                CreationDate = accountDto.CreationDate,
                LastChangeUser = accountDto.LastChangeUser,
                LastChangeDate = accountDto.LastChangeDate,
            };
        }

        private AccountDto ConvertToDomain(Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                GlobalId = account.GlobalId,
                Name = account.Name,
                CreationUser = account.CreationUser,
                CreationDate = account.CreationDate,
                LastChangeUser = account.LastChangeUser,
                LastChangeDate = account.LastChangeDate,
            };
        }
    }
}
