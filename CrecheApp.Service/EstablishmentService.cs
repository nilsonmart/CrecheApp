using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Domain.Interface.Service;
using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrecheApp.Service
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }
        public void Add(Establishment establishment)
        {
            establishment.GlobalId = Guid.NewGuid();
            establishment.CreationUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            establishment.CreationDate = DateTime.UtcNow;
            _establishmentRepository.Add(establishment);
        }

        public void Delete(Guid globalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Establishment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Establishment GetByGlobalId(Guid globalId)
        {
            throw new NotImplementedException();
        }

        public Establishment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Establishment entity)
        {
            throw new NotImplementedException();
        }
    }
}
