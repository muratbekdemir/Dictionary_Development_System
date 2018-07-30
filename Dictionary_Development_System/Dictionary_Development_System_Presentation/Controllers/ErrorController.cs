using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  public class ErrorController : Controller
  {
    // GET: Error
    public ActionResult NotAuthorization()
    {
      return View();
    }
  }
}