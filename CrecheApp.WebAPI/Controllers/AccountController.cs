using AutoMapper;
using CrecheApp.Domain.Dto;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using Microsoft.AspNetCore.Mvc;

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
    }
}
