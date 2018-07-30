using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Word
{
  public class SendTaskFromAdminRequest
  {
    public int Id { get; set; } /*wordId*/
    public int UserId { get; set; }
  }
}
