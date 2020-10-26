using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IUserService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model);
        void Add(UserModel entity);
        UserModel GetById(int id);
        UserModel GetByGlobalId(Guid globalId);
        IEnumerable<UserModel> GetAll();
        void Update(UserModel entity);
        void Delete(Guid globalId);
    }
}
