using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.RequestModels.Word
{
  public class ReportRequest
  {
    public string Word { get; set; }
    public int InterestId { get; set; }
    public int UserId { get; set; }
  }
}
