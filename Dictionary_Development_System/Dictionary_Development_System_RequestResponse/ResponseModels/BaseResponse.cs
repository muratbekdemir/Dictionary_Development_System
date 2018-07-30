using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dictionary_Development_System_RequestResponse.Models.ResponseModels
{
  public class BaseResponse
  {
    public int StatusCode { get; set; } = 200;
    public string Message { get; set; } = "";
    public bool IsSucceed { get; set; } = true;
  }
}