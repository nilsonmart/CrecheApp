using CrecheApp.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IAccountService
    {
        void Add(AccountDto entity);
        AccountDto GetById(int id);
        AccountDto GetByGlobalId(Guid globalId);
        IEnumerable<AccountDto> GetAll();
        void Update(AccountDto entity);
        void Delete(Guid globalId);
    }
}
