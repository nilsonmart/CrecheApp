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

        public void Add(Account account)
        {
            account.GlobalId = Guid.NewGuid();
            account.CreationUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            account.CreationDate = DateTime.UtcNow;
            _accountRepository.Add(account);
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

        public IEnumerable<Account> GetAll()
        {
            var account = _accountRepository.GetAll().ToList();
            if (account == null)
            {
                return null;
            }
            return account;
        }

        public Account GetByGlobalId(Guid globalId)
        {
            var account = _accountRepository.GetByGlobalId(globalId);
            if (account == null)
            {
                return null;
            }
           return account;
        }

        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            _accountRepository.Update(account);
        }
    }
}
