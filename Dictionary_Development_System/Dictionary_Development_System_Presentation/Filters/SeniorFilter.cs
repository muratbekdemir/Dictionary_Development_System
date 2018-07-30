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
  public class SeniorFilter : AuthorizeAttribute
  {
    public override void OnAuthorization(AuthorizationContext filterContext)
    {

      if ((CustomPrincipal.SessionAuthentication()))
      {
        if (!(CustomPrincipal.SessionRole() == Role.Senior.ToString()))
        {
          var httpContext = filterContext.HttpContext;
          var request = httpContext.Request;
          if (request.IsAjaxRequest())
          {
            filterContext.Result = new JsonResult
            {
              Data = new BaseResponse()
              {
                IsSucceed = false,
                Message = "İşlem yetkiniz bulunmamaktadır.",
                StatusCode = 503
              },
              JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
          }
          else
          {
            filterContext.Result = new RedirectToRouteResult("Default",
            new RouteValueDictionary
            {
                            { "action", "NotAuthorization" },
                            { "controller", "Error" }
            });
          }
        }
      }
      else
        base.OnAuthorization(filterContext);
    }
  }
}