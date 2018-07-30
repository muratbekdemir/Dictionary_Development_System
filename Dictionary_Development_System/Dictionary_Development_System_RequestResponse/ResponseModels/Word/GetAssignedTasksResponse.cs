using Dictionary_Development_System_RequestResponse.ResponseModels.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Word
{
  public class GetAssignedTasksResponse
  {
    public GetAssignedTasksResponse()
    {
      Interest = new GetInterestResponse();
    }

    public int WordId { get; set; }
    public string Word { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
    public string  UserName { get; set; }
    public string UserSurname { get; set; }
    public string DeveloperName { get; set; }
    public string DeveloperSurname { get; set; }
    public GetInterestResponse Interest { get; set; }
  }
}
