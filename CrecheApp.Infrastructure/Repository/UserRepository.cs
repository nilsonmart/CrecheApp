using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Infrastructure.Context;

namespace CrecheApp.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CrecheAppContext crecheAppContext) : base(crecheAppContext)
        {

        }

        public User Authenticate(string email, string password)
        {
            return _crecheAppContext.Users.Find(email, password);
        }
    }
}
