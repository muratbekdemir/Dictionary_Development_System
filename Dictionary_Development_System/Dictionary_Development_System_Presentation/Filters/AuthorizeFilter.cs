using Dictionary_Development_System_Presentation.Principal;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dictionary_Development_System_Presentation.Filters
{
  public class AuthorizationFilter : FilterAttribute, IAuthorizationFilter
  {
    public void OnAuthorization(AuthorizationContext filterContext)
    {
      if (CustomPrincipal.SessionAuthentication() == false)
      {
        if (filterContext.HttpContext.Request.IsAjaxRequest())
        {

          UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
          filterContext.Result = new JsonResult
          {
            Data = new BaseResponse()
            {
              IsSucceed = false,
              Message = "Oturumunuz sonlanmıştır. Lütfen tekrar giriş yapınız.",
            },
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
          };
        }
        else
        {
          filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new
          {
            action = "UserIndex", //"Login",
            controller = "Home",//"Account",
            ReturnUrl = filterContext.HttpContext.Request.Url.AbsolutePath + filterContext.HttpContext.Request.Url.Query,
          }));

        }
      }
    }
  }
}