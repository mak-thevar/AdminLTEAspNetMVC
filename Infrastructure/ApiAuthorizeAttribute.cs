using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AspMVCAdminLTE.Infrastructure
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            HttpContext.Current.Response.SuppressFormsAuthenticationRedirect = true;
            var response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { error = "UnAuthorized Access" });
            actionContext.Response = response;
        }
    }
}