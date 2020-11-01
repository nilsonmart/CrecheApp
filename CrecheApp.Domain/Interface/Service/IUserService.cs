using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IUserService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model);
        void Add(User entity);
        User GetById(int id);
        User GetByGlobalId(Guid globalId);
        IEnumerable<User> GetAll();
        void Update(User entity);
        void Delete(Guid globalId);
    }
}
