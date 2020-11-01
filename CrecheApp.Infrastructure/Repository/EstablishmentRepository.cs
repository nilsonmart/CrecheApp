using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Infrastructure.Context;

namespace CrecheApp.Infrastructure.Repository
{
    public class EstablishmentRepository : BaseRepository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(CrecheAppContext crecheAppContext) : base(crecheAppContext)
        {

        }
    }
}
