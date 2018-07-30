using Dictionary_Development_System_Presentation.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Dictionary_Development_System_Presentation.Filters
{
  public class AuthenticationFilter : FilterAttribute, IAuthenticationFilter
  {
    public void OnAuthentication(AuthenticationContext filterContext)
    {
      if (!CustomPrincipal.SessionAuthentication())
      { 
        filterContext.Result = new HttpUnauthorizedResult();
      }
    }

    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
    {
      if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
      {
        filterContext.Result = new RedirectToRouteResult("Default",
            new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Account"},
                        {"action", "Login"},
                        {"ReturnUrl", filterContext.HttpContext.Request.RawUrl},
                        {"area" , "" }
            });
      }
    }
  }
}