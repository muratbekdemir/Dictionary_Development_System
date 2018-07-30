using Dictionary_Development_System_RequestResponse.ResponseModels.Account;
using SessionLayer;
using System;
using System.Security.Principal;
using System.Web;

namespace Dictionary_Development_System_Presentation.Principal
{
  public class CustomPrincipal : IPrincipal
  {
    private CustomPrincipal() { }
    public IIdentity Identity { get; private set; }
    private CustomPrincipal(ICustomIdentity identity)
    {
      this.Identity = identity;
    }

    public static bool Login(LoginResponse usr)
    {
      var identity = CustomIdentity.GetCustomIdentity(usr);

      HttpContext.Current.User = new CustomPrincipal(identity);

      SessionManager.Instance().SetValue<int>("UserId", identity.UserId);
      SessionManager.Instance().SetValue<string>("UserEmail", identity.UserEmail);
      SessionManager.Instance().SetValue<string>("UserName", identity.UserName);
      SessionManager.Instance().SetValue<string>("UserSurname", identity.UserSurname);
      SessionManager.Instance().SetValue<string>("RoleName", identity.RoleName);
      SessionManager.Instance().SetValue<bool>("IsAuthentication", identity.IsAuthenticated);
      return identity.IsAuthenticated;
    }
   
    public static bool SessionAuthentication()
    {
      return SessionManager.Instance().GetValue<bool>("IsAuthentication");
    }

    public static string SessionRole()
    {
      return SessionManager.Instance().GetValue<string>("RoleName");
    }

    public static void Logout()
    {
      HttpContext.Current.User =  new GenericPrincipal(new GenericIdentity(""), new string[] { });
      SessionManager.Instance().Abandon();
    }

    public bool IsInRole(string role)
    {
      throw new NotImplementedException();
    }
  }
}