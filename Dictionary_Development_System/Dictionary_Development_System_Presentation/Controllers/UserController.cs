using Dictionary_Development_System_Business.Word;
using Dictionary_Development_System_Presentation.Filters;
using Dictionary_Development_System_RequestResponse.RequestModels.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  [AuthenticationFilter]
  public class UserController : BaseController
  {
    // GET: User
    public ActionResult Index()
    {
      return View();
    }
  }
}