using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.ResponseModels.Developer;
using Dictionary_Development_System_RequestResponse.ResponseModels.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Word
{
  public class GetReportedWordResponse : BaseResponse
  {
    public GetReportedWordResponse()
    {
      Developers = new List<InterestsDevelopersResponse>();
      Interest = new GetInterestResponse();
    }
    public int Id { get; set; }
    public string Word { get; set; }
    public int WordId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
    public GetInterestResponse Interest { get; set; }
    public List<InterestsDevelopersResponse> Developers { get; set; }

  }
}
