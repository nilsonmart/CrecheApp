using CrecheApp.Domain.Dto;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrecheApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Add(AccountDto entity)
        {
            var retval = ConvertToEntity(entity);
            retval.GlobalId = Guid.NewGuid();
            retval.CreationUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            retval.CreationDate = DateTime.UtcNow;
            _accountRepository.Add(retval);
        }

        public void Delete(Guid globalId)
        {
            var model = _accountRepository.GetByGlobalId(globalId);
            if (model == null)
            {
                throw  new NullReferenceException("object not found.");
            }
            _accountRepository.Delete(model);
        }

        public IEnumerable<AccountDto> GetAll()
        {
            var retval = _accountRepository.GetAll().ToList();
            if (retval == null)
            {
                return null;
            }
            return retval.Select(account => ConvertToDomain(account));
        }

        public AccountDto GetByGlobalId(Guid globalId)
        {
            var entity = _accountRepository.GetByGlobalId(globalId);
            if (entity == null)
            {
                return null;
            }
           return ConvertToDomain(entity);
        }

        public AccountDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountDto entity)
        {
            var retval = ConvertToEntity(entity);
            _accountRepository.Update(retval);
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
