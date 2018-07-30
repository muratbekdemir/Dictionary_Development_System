using Dictionary_Development_System_RequestResponse.ViewModels.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Word
{
  public class NotFoundResponse
  {
    public string Word { get; set; }
    public List<InterestView> Interests{ get; set; }
  }
}
