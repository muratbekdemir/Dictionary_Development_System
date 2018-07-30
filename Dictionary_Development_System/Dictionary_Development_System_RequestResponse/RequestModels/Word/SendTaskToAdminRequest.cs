using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.RequestModels.Word
{
  public class SendTaskToAdminRequest
  {
    public int WordId { get; set; }
    public int DeveloperId { get; set; }
    public string Content { get; set; }
  }
}
