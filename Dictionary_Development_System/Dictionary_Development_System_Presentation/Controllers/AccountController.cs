using Dictionary_Development_System_Business.Account;
using Dictionary_Development_System_Presentation.Principal;
using Dictionary_Development_System_RequestResponse.RequestModels.Account;
using Dictionary_Development_System_RequestResponse.ResponseModels.Account;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  public class AccountController : Controller
  {
    protected override void OnAuthorization(AuthorizationContext filterContext)
    {
      CustomPrincipal.SessionAuthentication();
      base.OnAuthorization(filterContext);
    }
    // GET: Account
    public ActionResult Login()
    {
      if (CustomPrincipal.SessionAuthentication())
      {
        return RedirectToHomePage();
      }
      return View();
    }

    [HttpPost]
    public ActionResult Login(LoginRequest request)
    {
      Account_Service account_Service = new Account_Service();
      LoginResponse response = account_Service.Login(request);
      if (response.IsSucceed)
      {
        CustomPrincipal.Login(response);
        if (response.UserView.RoleName == Role.User.ToString())
          return RedirectToUserHomePage();
        if (response.UserView.RoleName == Role.Developer.ToString() || response.UserView.RoleName == Role.Senior.ToString())
          return RedirectToDeveloperHomePage();
        if (response.UserView.RoleName == Role.Admin.ToString())
          return RedirectToAdminHomePage();
      }
      return View(response.Message);
    }

    public ActionResult Logout()
    {
      CustomPrincipal.Logout();
      return RedirectToHomePage();
    }

    private RedirectToRouteResult RedirectToHomePage()
    {
      string returnUrl = Request.QueryString["ReturnUrl"] == null ? "" : Request.QueryString["ReturnUrl"].ToString();
      if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        Response.Redirect(returnUrl);
      return RedirectToAction("Index", "Home");
    }

    private RedirectToRouteResult RedirectToAdminHomePage()
    {
      string returnUrl = Request.QueryString["ReturnUrl"] == null ? "" : Request.QueryString["ReturnUrl"].ToString();
      if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        Response.Redirect(returnUrl);
      return RedirectToAction("Index", "Admin");
    }

    private RedirectToRouteResult RedirectToDeveloperHomePage()
    {
      string returnUrl = Request.QueryString["ReturnUrl"] == null ? "" : Request.QueryString["ReturnUrl"].ToString();
      if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        Response.Redirect(returnUrl);
      return RedirectToAction("Index", "Developer");
    }

    private RedirectToRouteResult RedirectToUserHomePage()
    {
      string returnUrl = Request.QueryString["ReturnUrl"] == null ? "" : Request.QueryString["ReturnUrl"].ToString();
      if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        Response.Redirect(returnUrl);
      return RedirectToAction("Index", "User");
    }
  }
}