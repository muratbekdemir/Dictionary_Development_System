using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.RequestModels.Word
{
  public class GetRatingWordsRequest
  {
    public int UserId { get; set; }/*DeveloperId*/
    public int InterestId { get; set; }
  }
}
