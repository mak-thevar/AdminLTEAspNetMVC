using AspMVCAdminLTE.Entity;
using AspMVCAdminLTE.Repository.Infra;
using AspMVCAdminLTE.Utils;
using System.Linq;

namespace AspMVCAdminLTE.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private RepositoryContext repositoryContext;
        public UserRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public User ValidateUser(string userName, string password)
        {
            //var compareHash = Encryption.CompareHash(x.Password, password);
            return repositoryContext.Users.Where(x => x.UserName == userName || x.Mobile == userName).AsEnumerable().Where(x => Encryption.CompareHash(x.Password, password)).FirstOrDefault();
        }
    }
}