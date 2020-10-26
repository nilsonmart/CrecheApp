using CrecheApp.Domain.Model;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrecheApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Add(AccountModel entity)
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

        public IEnumerable<AccountModel> GetAll()
        {
            var retval = _accountRepository.GetAll().ToList();
            if (retval == null)
            {
                return null;
            }
            return retval.Select(account => ConvertToDomain(account));
        }

        public AccountModel GetByGlobalId(Guid globalId)
        {
            var entity = _accountRepository.GetByGlobalId(globalId);
            if (entity == null)
            {
                return null;
            }
           return ConvertToDomain(entity);
        }

        public AccountModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountModel entity)
        {
            var retval = ConvertToEntity(entity);
            _accountRepository.Update(retval);
        }


        private Account ConvertToEntity(AccountModel accountDto)
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

        private AccountModel ConvertToDomain(Account account)
        {
            return new AccountModel
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
