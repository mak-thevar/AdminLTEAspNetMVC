using AspMVCAdminLTE.Entity;
using AspMVCAdminLTE.Repository.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMVCAdminLTE.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string userName, string password);
    }
}