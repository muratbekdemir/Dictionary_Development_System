using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Account
{
  public class GetUserResponse
  {
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string Email { get; set; }
    public string InterestName { get; set; }
    public int InterestId { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public string Password { get; set; }
  }
}
