using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IAccountService
    {
        void Add(Account entity);
        Account GetById(int id);
        Account GetByGlobalId(Guid globalId);
        IEnumerable<Account> GetAll();
        void Update(Account entity);
        void Delete(Guid globalId);
    }
}
