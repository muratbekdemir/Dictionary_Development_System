using Dictionary_Development_System_RequestResponse.ResponseModels.Account;

namespace Dictionary_Development_System_Presentation.Principal
{
  public class CustomIdentity : ICustomIdentity
  {
    private static CustomIdentity idnty;
    public static CustomIdentity GetCustomIdentity(LoginResponse usr)
    {
      CustomIdentity identity = new CustomIdentity
      {
        IsAuthenticated = true,
        UserEmail = usr.UserView.Email,
        UserName = usr.UserView.Name,
        UserSurname = usr.UserView.Surname,
        RoleName = usr.UserView.RoleName,
        UserId = usr.UserView.Id
      };
      return identity;
    }

    public int UserId { get; set; }
    public string UserEmail { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string RoleName { get; set; }
    public string AuthenticationType { get { return "Custom Web"; } }
    public bool IsAuthenticated { get; set; }//giriş yapıp yapmadığını, yani authenticate olup olmadığını sorgular
    public string Name { get; }

   
  }
}