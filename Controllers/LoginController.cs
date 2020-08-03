using AspMVCAdminLTE.Models;
using AspMVCAdminLTE.Repository;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace AspMVCAdminLTE.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public LoginController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = repositoryWrapper.User.ValidateAdminUser(userLoginModel.UserName, userLoginModel.Password);
                if (user != null)
                {
                    //SessionManager.User = Mapper.Map<UserModel>(user);
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("SimpleTables", "Default");
                }
                else
                {
                    ViewBag.Message = "Invalid username or password !";
                }
            }
            return View("Index");
        }

        public ActionResult ForgetPassword()
        {
            ViewBag.Success = false;
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(UserLoginModel userLoginModel)
        {
            //Add reset password logic here
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            Session.RemoveAll();
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}