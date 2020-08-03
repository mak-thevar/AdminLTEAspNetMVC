using AspMVCAdminLTE.Entity;
using AspMVCAdminLTE.Repository.Infra;

namespace AspMVCAdminLTE.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string userName, string password);

        User ValidateAdminUser(string userName, string password);
    }
}