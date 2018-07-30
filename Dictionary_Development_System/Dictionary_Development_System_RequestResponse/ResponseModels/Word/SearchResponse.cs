using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_RequestResponse.ResponseModels.Word
{
  public class SearchResponse : BaseResponse
  {
    public int Id { get; set; }
    public string Word { get; set; }
    public string Content { get; set; }
    public int DeveloperId { get; set; }
    public int InterestId { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
  }
}
