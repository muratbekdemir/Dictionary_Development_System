using Dictionary_Development_System_RequestResponse.ResponseModels.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Word
{
  public class GetPendingWordsResponse
  {
    public GetPendingWordsResponse()
    {
      Interest = new GetInterestResponse();
    }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
    public string Word { get; set; }
    public int WordId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string DeveloperName { get; set; }
    public string DeveloperSurname { get; set; }
    public GetInterestResponse Interest { get; set; }
    public string Content { get; set; }
  }
}
