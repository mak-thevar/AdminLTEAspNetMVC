using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMVCAdminLTE.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}