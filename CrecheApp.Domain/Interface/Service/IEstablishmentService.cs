using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IEstablishmentService
    {
        void Add(EstablishmentModel entity);
        EstablishmentModel GetById(int id);
        EstablishmentModel GetByGlobalId(Guid globalId);
        IEnumerable<EstablishmentModel> GetAll();
        void Update(EstablishmentModel entity);
        void Delete(Guid globalId);
    }
}
