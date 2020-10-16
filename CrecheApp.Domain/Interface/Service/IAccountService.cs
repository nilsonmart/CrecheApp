using CrecheApp.Domain.Dto;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IAccountService
    {
        void Add(AccountModel entity);
        AccountModel GetById(int id);
        AccountModel GetByGlobalId(Guid globalId);
        IEnumerable<AccountModel> GetAll();
        void Update(AccountModel entity);
        void Delete(Guid globalId);
    }
}
