using AspMVCAdminLTE.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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