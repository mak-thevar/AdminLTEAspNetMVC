using AspMVCAdminLTE.Entity;
using AspMVCAdminLTE.Entity.Enums;
using AspMVCAdminLTE.Infrastructure;
using AspMVCAdminLTE.Repository;
using System;
using System.Linq;
using System.Web.Http;

namespace AspMVCAdminLTE.ApiControllers
{
    public class AccountController : BaseApiController
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public AccountController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpPost]
        public IHttpActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.UserRole = UserRole.Normal; //Make sure the userType is not set to admin.
                    var result = repositoryWrapper.User.Create(user);
                    if (result != null)
                        return Success(result);
                    else
                        return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.InnerException.InnerException.Message);
            }
            return ModelError();
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Get()
        {
            return Success(repositoryWrapper.User.FindAll().ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Normal")]
        public IHttpActionResult GetProfile()
        {
            return Success(repositoryWrapper.User.FindByCondition(x => x.Id == GetUserId()));
        }
    }
}