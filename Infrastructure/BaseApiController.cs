using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace AspMVCAdminLTE.Infrastructure
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult CreateResponse<T>(T content)
        {
            if (!ModelState.IsValid)
                return ModelError();
            else
                return Success(content);
        }

        protected int GetUserId()
        {
            return Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.SingleOrDefault(x => x.Type == "Id").Value);
        }

        protected IHttpActionResult ModelError()
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
        }

        protected IHttpActionResult Success<T>(T content)
        {
            return Ok(content);
        }
    }
}