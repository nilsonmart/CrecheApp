using CrecheApp.Domain.Entity;

namespace CrecheApp.Domain.Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Authenticate(string email, string password);
    }
}
