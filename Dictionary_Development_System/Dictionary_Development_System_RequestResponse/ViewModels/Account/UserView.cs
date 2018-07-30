using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dictionary_Development_System_RequestResponse.ViewModels.Account
{
  public class UserView
  {
    public UserView()
    {
      this.Id = Id;
      this.Name = Name;
      this.Email = Email;
      this.Surname = Surname;
      this.RoleName = RoleName;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Surname { get; set; }
    public string RoleName { get; set; }

  }
}