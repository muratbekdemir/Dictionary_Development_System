using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.RequestModels.Word
{
  public class AssignWordToDeveloperRequest
  {
    public int DeveloperId { get; set; }
    public int WordId { get; set; }

  }
}
