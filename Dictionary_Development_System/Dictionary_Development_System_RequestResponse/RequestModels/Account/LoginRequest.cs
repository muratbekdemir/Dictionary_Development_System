using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dictionary_Development_System_RequestResponse.RequestModels.Account
{
  public class LoginRequest
  {
    public string Email { get; set; }
    public string Password { get; set; }

  }
}