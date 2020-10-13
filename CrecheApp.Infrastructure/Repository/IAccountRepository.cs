using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Infrastructure.Context;

namespace CrecheApp.Infrastructure.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(CrecheAppContext crecheAppContext) : base(crecheAppContext)
        {

        }
    }
}
