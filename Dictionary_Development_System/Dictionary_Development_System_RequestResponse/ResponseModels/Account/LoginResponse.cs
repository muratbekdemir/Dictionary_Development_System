using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.ViewModels.Account;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Account
{
  public class LoginResponse : BaseResponse
  {
    public UserView UserView { get; set; }
  }
}