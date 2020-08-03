using AspMVCAdminLTE.Entity;
using System.Data.Entity;

namespace AspMVCAdminLTE.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
            : base("DefaultContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}