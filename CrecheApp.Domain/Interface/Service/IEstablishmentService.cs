using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Interface.Service
{
    public interface IEstablishmentService
    {
        void Add(Establishment entity);
        Establishment GetById(int id);
        Establishment GetByGlobalId(Guid globalId);
        IEnumerable<Establishment> GetAll();
        void Update(Establishment entity);
        void Delete(Guid globalId);
    }
}
