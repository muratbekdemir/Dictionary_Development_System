using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.RequestModels.Account
{
  public class AddUserRequest
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int  Role { get; set; }
    public int InterestId { get; set; }
  }
}
